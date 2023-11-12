using UnityEngine;

namespace IronMountain.SaveSystem
{
    [CreateAssetMenu(menuName = "Save System/Scripted Values/String")]
    public class ScriptedSavedString : ScriptedSavedValue<string>
    {
        [SerializeField] private string defaultValue;
        
        private SavedString _savedString;

        public override string Value
        {
            get => _savedString.Value;
            set => _savedString.Value = value;
        }

        public override string DefaultValue
        {
            get => defaultValue;
            set => defaultValue = value;
        }

        protected override void InitializeSavedData()
        {
            _savedString = new SavedString(Directory, file, defaultValue, InvokeOnValueChanged);
        }
    }
}
