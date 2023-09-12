using System;
using UnityEngine;

namespace IronMountain.SaveSystem
{
    [Serializable]
    public struct SavedInt
    {
        public event Action OnValueChanged;
            
        [SerializeField] private string directory;
        [SerializeField] private string file;
        [SerializeField] private int value;
            
        public int Value
        {
            get
            {
                Load();
                return value;
            }
            set
            {
                if (this.value == value) return;
                this.value = value;
                Save();
                OnValueChanged?.Invoke();
            }
        }

        public SavedInt Load()
        {
            string savedValue = SaveSystem.LoadFile(directory, file);
            if (savedValue == null) return this;
            int.TryParse(savedValue, out value);
            return this;
        }

        public SavedInt Save()
        {
            SaveSystem.SaveFile(directory, file, value.ToString());
            return this;
        }
        
        public void Delete()
        {
            SaveSystem.DeleteFile(directory, file);
        }
        
        public bool Saved => SaveSystem.FileExists(directory, file);

        public SavedInt(string directory, string file, int defaultValue, Action onValueChanged)
        {
            this.directory = directory;
            this.file = file;
            if (!int.TryParse(SaveSystem.LoadFile(this.directory, this.file), out value))
            {
                value = defaultValue;
            }
            OnValueChanged = onValueChanged;
        }
    }
}
