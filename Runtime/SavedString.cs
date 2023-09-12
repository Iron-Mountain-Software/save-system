using System;
using UnityEngine;

namespace IronMountain.SaveSystem
{
    [Serializable]
    public struct SavedString
    {
        public event Action OnValueChanged;
            
        [SerializeField] private string directory;
        [SerializeField] private string file;
        [SerializeField] private string value;
            
        public string Value
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

        public SavedString Load()
        {
            string savedValue = SaveSystem.LoadFile(directory, file);
            if (savedValue == null) return this;
            value = savedValue;
            return this;
        }

        public SavedString Save()
        {
            SaveSystem.SaveFile(directory, file, value);
            return this;
        }
        
        public void Delete()
        {
            SaveSystem.DeleteFile(directory, file);
        }
        
        public bool Saved => SaveSystem.FileExists(directory, file);

        public SavedString(string directory, string file, string defaultValue, Action onValueChanged)
        {
            this.directory = directory;
            this.file = file;
            value = SaveSystem.LoadFile(this.directory, this.file) ?? defaultValue;
            OnValueChanged = onValueChanged;
        }
    }
}
