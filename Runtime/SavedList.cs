using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IronMountain.SaveSystem
{
    [Serializable]
    public struct SavedList
    {
        public Action OnValueChanged;
            
        [SerializeField] private string directory;
        [SerializeField] private string file;
        [SerializeField] private List<string> data;
            
        public List<string> Data
        {
            get
            {
                Load();
                return data;
            }
            set
            {
                data = value;
                Save();
            }
        }
        
        public void Add(string s)
        {
            Load();
            data.Add(s);
            Save();
        }
        
        public void AddRange(List<string> s)
        {
            Load();
            data.AddRange(s);
            Save();
        }

        public void Remove(string s)
        {
            Load();
            data.Remove(s);
            Save();
        }

        public SavedList Load()
        {
            string savedValue = SaveSystem.LoadFile(directory, file);
            if (savedValue == null) return this;
            data = savedValue.Split('|').ToList();
            return this;
        }

        public SavedList Save()
        {
            SaveSystem.SaveFile(directory, file, string.Join('|', data));
            OnValueChanged?.Invoke();
            return this;
        }
        
        public void Delete()
        {
            SaveSystem.DeleteFile(directory, file);
        }
        
        public bool Saved => SaveSystem.FileExists(directory, file);

        public SavedList(string directory, string file, List<string> defaultData, Action onValueChanged)
        {
            this.directory = directory;
            this.file = file;
            data = defaultData;
            OnValueChanged = onValueChanged;
            Load();
        }
    }
}
