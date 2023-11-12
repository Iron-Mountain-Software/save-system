using UnityEngine;

namespace IronMountain.SaveSystem
{
    [CreateAssetMenu(menuName = "Save System/Scripted Values/Float")]
    public class ScriptedSavedFloat : ScriptedSavedValue<float>
    {
        [SerializeField] private float defaultValue;
        
        private SavedFloat _savedFloat;

        public override float Value
        {
            get => _savedFloat.Value;
            set => _savedFloat.Value = value;
        }

        public override float DefaultValue
        {
            get => defaultValue;
            set => defaultValue = value;
        }

        public void Increment() => Value++;
        public void Decrement() => Value--;
        public void Add(float value) => Value += value;
        public void Subtract(float value) => Value -= value;
        public void MultiplyBy(float value) => Value *= value;
        public void DivideBy(float value) => Value /= value;

        protected override void InitializeSavedData()
        {
            _savedFloat = new SavedFloat(Directory, file, defaultValue, InvokeOnValueChanged);
        }
    }
}
