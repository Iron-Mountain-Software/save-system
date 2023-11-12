using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace IronMountain.SaveSystem.Editor
{
    [CustomEditor(typeof(ScriptedSavedList), true)]
    public class ScriptedSavedListInspector : UnityEditor.Editor
    {
        private ScriptedSavedList _scriptedSavedList;
        private string _valueToAdd;
        
        private void OnEnable()
        {
            _scriptedSavedList = (ScriptedSavedList) target;
        }

        public override void OnInspectorGUI()
        {
            if (!_scriptedSavedList || _scriptedSavedList.Value == null) return;

            EditorGUILayout.PropertyField(serializedObject.FindProperty("directory"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("file"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("defaultValue"));
            
            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Current Value: ", GUILayout.Width(100));
            EditorGUILayout.BeginVertical();
            foreach (var value in _scriptedSavedList.Value)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label(value);
                if (GUILayout.Button("Remove", GUILayout.Width(75)))
                {
                    _scriptedSavedList.Remove(value);
                    return;
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
            if (GUILayout.Button("Reset", GUILayout.Width(75))) _scriptedSavedList.ResetValue();
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Set New Value: ", GUILayout.Width(100));
            _valueToAdd = EditorGUILayout.TextField(_valueToAdd);
            if (GUILayout.Button("Add", GUILayout.Width(75))) _scriptedSavedList.Add(_valueToAdd);
            EditorGUILayout.EndHorizontal();

            serializedObject.ApplyModifiedProperties();
        }
    }
}