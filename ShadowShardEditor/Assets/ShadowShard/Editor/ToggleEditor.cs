using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class ToggleEditor
    {
        private readonly GroupEditor _groupEditor;

        public ToggleEditor(GroupEditor groupEditor) =>
            _groupEditor = groupEditor;
        
        public bool DrawToggle(GUIContent label, SerializedProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                bool newValue = EditorGUILayout.Toggle(label, property.boolValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    property.boolValue = newValue;
            });

            return property.boolValue;
        }
        
        
        public bool DrawShaderGlobalKeywordToggle(GUIContent label, SerializedProperty property, string shaderGlobalKeyword, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                bool newValue = EditorGUILayout.Toggle(label, property.boolValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    property.boolValue = newValue;
                    RPUtils.SetGlobalKeyword(shaderGlobalKeyword, newValue);
                }
            });

            return property.boolValue;
        }
    }
}