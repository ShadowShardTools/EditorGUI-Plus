using System;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class PopupEditor
    {
        private readonly EditorUtils _editorUtils;

        private const string BooleanDisplayedOptionsError = "The displayedOptions array should contain exactly two options.";

        public PopupEditor(EditorUtils editorUtils) =>
            _editorUtils = editorUtils;
        
        public TEnum DrawEnumPopup<TEnum>(SerializedProperty property, int indentLevel = 0)
            where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            GUIContent label = new(ObjectNames.NicifyVariableName(enumType.Name));
            
            int enumOption = DrawPopup(label, property, Enum.GetNames(enumType), indentLevel);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }
        
        public TEnum DrawEnumPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0)
            where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            
            int enumOption = DrawPopup(label, property, Enum.GetNames(enumType), indentLevel);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }
        
        public int DrawPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, int indentLevel = 0)
        {
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                int newValue = EditorGUILayout.Popup(label, property.enumValueIndex, displayedOptions);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    property.enumValueIndex = newValue;
            });
            
            return property.enumValueIndex;
        }
        
        public bool DrawBooleanPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, int indentLevel = 0)
        {
            if (!IsDisplayedBooleanErrorMessage(displayedOptions)) 
                return false;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
            
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                int newValue = EditorGUILayout.Popup(label, property.enumValueIndex, displayedOptions);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    property.enumValueIndex = newValue;
            });
            
            return property.enumValueIndex > 0;
        }
        
        public bool DrawShaderGlobalKeywordBooleanPopup(GUIContent label, SerializedProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0)
        {
            if (!IsDisplayedBooleanErrorMessage(displayedOptions)) 
                return false;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
            
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                int newValue = EditorGUILayout.Popup(label, property.enumValueIndex, displayedOptions);
                EditorGUI.showMixedValue = false;
            
                if (EditorGUI.EndChangeCheck())
                {
                    property.enumValueIndex = newValue;
                    RPUtils.SetGlobalKeyword(shaderGlobalKeyword, newValue > 0);
                }
            });

            return property.enumValueIndex > 0;
        }

        private bool IsDisplayedBooleanErrorMessage(string[] displayedOptions)
        {
            if (displayedOptions.Length == 2) 
                return true;
            
            EditorGUILayout.HelpBox(BooleanDisplayedOptionsError, MessageType.Error);
            return false;
        }
    }
}