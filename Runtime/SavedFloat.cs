using System;
using UnityEngine;

namespace IronMountain.SaveSystem
{
    [Serializable]
    public struct SavedFloat
    {
        public event Action OnValueChanged;
            
        [SerializeField] private string directory;
        [SerializeField] private string file;
        [SerializeField] private float value;
            
        public float Value
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

        public SavedFloat Load()
        {
            string savedValue = SaveSystem.LoadFile(directory, file);
            if (savedValue == null) return this;
            float.TryParse(savedValue, out value);
            return this;
        }

        public SavedFloat Save()
        {
            SaveSystem.SaveFile(directory, file, value.ToString());
            return this;
        }
        
        public void Delete()
        {
            SaveSystem.DeleteFile(directory, file);
        }

        public bool Saved => SaveSystem.FileExists(directory, file);

        public SavedFloat(string directory, string file, float defaultValue, Action onValueChanged)
        {
            this.directory = directory;
            this.file = file;
            if (!float.TryParse(SaveSystem.LoadFile(this.directory, this.file), out value))
            {
                value = defaultValue;
            }
            OnValueChanged = onValueChanged;
        }
    }
}
