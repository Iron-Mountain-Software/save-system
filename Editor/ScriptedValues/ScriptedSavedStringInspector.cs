using System;
using UnityEditor;
using UnityEngine;

namespace IronMountain.SaveSystem.Editor
{
    [CustomEditor(typeof(ScriptedSavedValue<string>), true)]
    public class ScriptedSavedStringInspector : UnityEditor.Editor
    {
        private ScriptedSavedValue<string> _scriptedSavedInt;
        private string _valueToSet;
        
        private void OnEnable()
        {
            _scriptedSavedInt = (ScriptedSavedValue<string>) target;
        }

        public override void OnInspectorGUI()
        {
            if (!_scriptedSavedInt) return;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("directory"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("file"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("defaultValue"));
            
            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Current Value: ", GUILayout.Width(100));
            GUILayout.Label(_scriptedSavedInt.Value.ToString());
            if (GUILayout.Button("Reset", GUILayout.Width(75))) _scriptedSavedInt.ResetValue();
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Set New Value: ", GUILayout.Width(100));
            _valueToSet = EditorGUILayout.TextField(_valueToSet);
            if (GUILayout.Button("Set", GUILayout.Width(75))) _scriptedSavedInt.Value = _valueToSet;
            EditorGUILayout.EndHorizontal();

            serializedObject.ApplyModifiedProperties();
        }
    }
}