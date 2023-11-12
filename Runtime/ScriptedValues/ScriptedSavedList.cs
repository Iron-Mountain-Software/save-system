using System.Collections.Generic;
using UnityEngine;

namespace IronMountain.SaveSystem
{
    [CreateAssetMenu(menuName = "Save System/Scripted Values/List<string>")]
    public class ScriptedSavedList : ScriptedSavedValue<List<string>>
    {
        [SerializeField] private List<string> defaultValue;
        
        private SavedList _savedFloat;

        public override List<string> Value
        {
            get => _savedFloat.Data;
            set => _savedFloat.Data = value;
        }

        public override List<string> DefaultValue
        {
            get => defaultValue;
            set => defaultValue = value;
        }

        public void Add(string value) => Value.Add(value);
        public void AddRange(List<string> values) => Value.AddRange(values);
        public void Remove(string value) => Value.Remove(value);
        public void Clear() => Value.Clear();
        public bool Contains(string value) => Value.Contains(value);

        public override void ResetValue()
        {
            Value = new List<string>(DefaultValue);
        }

        protected override void InitializeSavedData()
        {
            _savedFloat = new SavedList(Directory, file, defaultValue, InvokeOnValueChanged);
        }
    }
}