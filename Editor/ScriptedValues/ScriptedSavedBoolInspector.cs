using System;
using UnityEditor;
using UnityEngine;

namespace IronMountain.SaveSystem.Editor
{
    [CustomEditor(typeof(ScriptedSavedValue<bool>), true)]
    public class ScriptedSavedBoolInspector : UnityEditor.Editor
    {
        private ScriptedSavedValue<bool> _scriptedSavedInt;
        private bool _valueToSet;
        
        private void OnEnable()
        {
            _scriptedSavedInt = (ScriptedSavedValue<bool>) target;
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
            _valueToSet = EditorGUILayout.Toggle(_valueToSet);
            if (GUILayout.Button("Set", GUILayout.Width(75))) _scriptedSavedInt.Value = _valueToSet;
            EditorGUILayout.EndHorizontal();

            serializedObject.ApplyModifiedProperties();
        }
    }
}