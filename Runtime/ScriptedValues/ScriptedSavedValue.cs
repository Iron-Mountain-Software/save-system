using System;
using UnityEngine;

namespace IronMountain.SaveSystem
{
    public abstract class ScriptedSavedValue<T> : ScriptableObject
    {
        public event Action OnValueChanged;

        [SerializeField] protected string directory;
        [SerializeField] protected string file;

        public virtual string Directory => directory;
        public virtual string File => file;

        public abstract T Value { get; set; }
        public abstract T DefaultValue { get; set; }

        public virtual void ResetValue()
        {
            Value = DefaultValue;
        }

        protected virtual void OnEnable()
        {
            InitializeSavedData();
            InvokeOnValueChanged();
        }
        
        protected abstract void InitializeSavedData();
        
        protected void InvokeOnValueChanged()
        {
            OnValueChanged?.Invoke();
        }

#if UNITY_EDITOR
        
        private void OnValidate()
        {
            InitializeSavedData();
            InvokeOnValueChanged();
        }
        
#endif
    }
}