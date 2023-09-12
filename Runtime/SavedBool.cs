using System;
using UnityEngine;

namespace IronMountain.SaveSystem
{
    [Serializable]
    public struct SavedBool
    {
        public Action OnValueChanged;
            
        [SerializeField] private string directory;
        [SerializeField] private string file;
        [SerializeField] private bool value;
            
        public bool Value
        {
            get
            {
                Load();
                return value;
            }
            set
            {
                this.value = value;
                Save();
                OnValueChanged?.Invoke();
            }
        }
        
        public SavedBool Load()
        {
            string savedValue = SaveSystem.LoadFile(directory, file);
            if (savedValue == null) return this;
            bool.TryParse(savedValue, out value);
            return this;
        }

        public SavedBool Save()
        {
            SaveSystem.SaveFile(directory, file, value.ToString());
            return this;
        }

        public void Delete()
        {
            SaveSystem.DeleteFile(directory, file);
        }

        public bool Saved => SaveSystem.FileExists(directory, file);

        public SavedBool(string directory, string file, bool defaultValue, Action onValueChanged)
        {
            this.directory = directory;
            this.file = file;
            if (!bool.TryParse(SaveSystem.LoadFile(this.directory, this.file), out value))
            {
                value = defaultValue;
            }
            OnValueChanged = onValueChanged;
        }
    }
}
