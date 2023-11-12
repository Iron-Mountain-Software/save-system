using UnityEngine;

namespace IronMountain.SaveSystem
{
    [CreateAssetMenu(menuName = "Save System/Scripted Values/Int")]
    public class ScriptedSavedInt : ScriptedSavedValue<int>
    {
        [SerializeField] private int defaultValue;
        
        private SavedInt _savedInt;

        public override int Value
        {
            get => _savedInt.Value;
            set => _savedInt.Value = value;
        }

        public override int DefaultValue
        {
            get => defaultValue;
            set => defaultValue = value;
        }

        public void Increment() => Value++;
        public void Decrement() => Value--;
        public void Add(int value) => Value += value;
        public void Subtract(int value) => Value -= value;
        public void MultiplyBy(int value) => Value *= value;
        public void DivideBy(int value) => Value /= value;
        
        protected override void InitializeSavedData()
        {
            _savedInt = new SavedInt(Directory, file, defaultValue, InvokeOnValueChanged);
        }
    }
}
