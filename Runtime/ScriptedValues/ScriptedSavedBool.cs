using UnityEngine;

namespace IronMountain.SaveSystem
{
    [CreateAssetMenu(menuName = "Save System/Scripted Values/Bool")]
    public class ScriptedSavedBool : ScriptedSavedValue<bool>
    {
        [SerializeField] private bool defaultValue;
        
        private SavedBool _savedBool;

        public override bool Value
        {
            get => _savedBool.Value;
            set => _savedBool.Value = value;
        }

        public override bool DefaultValue
        {
            get => defaultValue;
            set => defaultValue = value;
        }

        public void Toggle()
        {
            Value = !Value;
        }

        protected override void InitializeSavedData()
        {
            _savedBool = new SavedBool(Directory, file, defaultValue, InvokeOnValueChanged);
        }
    }
}
