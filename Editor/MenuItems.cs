using UnityEditor;
using UnityEngine;

namespace IronMountain.SaveSystem.Editor
{
    public static class MenuItems
    {
        [MenuItem("Save System/Open Persistent Data Path %#O")]
        private static void OpenPersistentDataPathRunner()
        {
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }
    
        [MenuItem("Save System/Copy New GUID to Clipboard %#I")]
        private static void CopyNewGuidToClipboard()
        {
            EditorGUIUtility.systemCopyBuffer = GUID.Generate().ToString(); 
        }
    }
}