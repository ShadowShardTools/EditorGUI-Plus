using System;
using ShadowShard.Editor.MaterialEditor;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor.EditorModules
{
    internal sealed class PopupEditor
    {
        private const string BooleanDisplayedOptionsError = "The displayedOptions array should contain exactly two options.";

        private readonly PropertyService _propertyService;
        private readonly GroupEditor _groupEditor;

        internal PopupEditor(PropertyService propertyService, GroupEditor groupEditor)
        {
            _propertyService = propertyService;
            _groupEditor = groupEditor;
        }
        
        internal TEnum DrawEnumPopup<TEnum, TProperty>(TProperty property, int indentLevel = 0)
            where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            GUIContent label = new(ObjectNames.NicifyVariableName(enumType.Name));
            
            return DrawEnumPopup<TEnum, TProperty>(label, property, indentLevel);
        }
        
        internal TEnum DrawEnumPopup<TEnum, TProperty>(GUIContent label, TProperty property, int indentLevel = 0)
            where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            int enumOption = DrawPopup(label, property, Enum.GetNames(enumType), indentLevel);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }
        
        internal TEnum DrawBooleanPopup<TEnum, TProperty>(TProperty property, int indentLevel = 0)
            where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            GUIContent label = new(ObjectNames.NicifyVariableName(enumType.Name));

            return DrawBooleanPopup<TEnum, TProperty>(label, property, indentLevel);
        }
        
        internal TEnum DrawBooleanPopup<TEnum, TProperty>(GUIContent label, TProperty property, int indentLevel = 0)
            where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            int enumOption = DrawBooleanPopup(label, property, Enum.GetNames(enumType), indentLevel);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }
        
        internal TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum, TProperty>(TProperty property, string shaderGlobalKeyword, int indentLevel = 0)
            where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            GUIContent label = new(ObjectNames.NicifyVariableName(enumType.Name));

            return DrawShaderGlobalKeywordBooleanPopup<TEnum, TProperty>(label, property, shaderGlobalKeyword, indentLevel);
        }
        
        internal TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum, TProperty>(GUIContent label, TProperty property, string shaderGlobalKeyword, int indentLevel = 0)
            where TEnum : Enum
        {
            Type enumType = typeof(TEnum);
            
            int enumOption = DrawShaderGlobalKeywordBooleanPopup(label, property, Enum.GetNames(enumType), shaderGlobalKeyword, indentLevel);

            return (TEnum)Enum
                .GetValues(enumType)
                .GetValue(enumOption);
        }
        
        internal int DrawPopup<TProperty>(GUIContent label, TProperty property, string[] displayedOptions, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetEnumIndex(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                int propertyValue = _propertyService.GetEnumIndex(property);
                int newValue = EditorGUILayout.Popup(label, propertyValue, displayedOptions);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    _propertyService.SetEnumIndex(property, newValue);
            }
        }
        
        internal int DrawBooleanPopup<TProperty>(GUIContent label, TProperty property, string[] displayedOptions, int indentLevel = 0)
        {
            if (!IsDisplayedBooleanErrorMessage(displayedOptions)) 
                return 0;
            
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetEnumIndex(property);
            
            void Draw()
            {
                EditorGUI.BeginChangeCheck();
            
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                int propertyValue = _propertyService.GetEnumIndex(property);
                int newValue = EditorGUILayout.Popup(label, propertyValue, displayedOptions);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    _propertyService.SetEnumIndex(property, newValue);
            }
        }
        
        internal int DrawShaderGlobalKeywordBooleanPopup<TProperty>(GUIContent label, TProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0)
        {
            if (!IsDisplayedBooleanErrorMessage(displayedOptions)) 
                return 0;
            
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetEnumIndex(property);
            
            void Draw()
            {
                EditorGUI.BeginChangeCheck();
            
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                int propertyValue = _propertyService.GetEnumIndex(property);
                int newValue = EditorGUILayout.Popup(label, propertyValue, displayedOptions);
                EditorGUI.showMixedValue = false;
            
                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetEnumIndex(property, newValue);
                    GlobalKeywordsService.SetGlobalKeyword(shaderGlobalKeyword, newValue > 0);
                }
            }
        }

        internal bool IsDisplayedBooleanErrorMessage(string[] displayedOptions)
        {
            if (displayedOptions.Length == 2) 
                return true;
            
            EditorGUILayout.HelpBox(BooleanDisplayedOptionsError, MessageType.Error);
            return false;
        }
    }
}