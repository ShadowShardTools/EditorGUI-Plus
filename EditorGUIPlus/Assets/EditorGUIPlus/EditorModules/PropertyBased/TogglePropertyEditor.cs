using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.MaterialEditor;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.PropertyBased
{
    internal sealed class TogglePropertyEditor
    {
        private readonly PropertyService _propertyService;
        private readonly GroupEditor _groupEditor;

        internal TogglePropertyEditor(PropertyService propertyService, GroupEditor groupEditor)
        {
            _propertyService = propertyService;
            _groupEditor = groupEditor;
        }
        
        internal bool DrawToggle<TProperty>(GUIContent label, TProperty property, 
            ToggleAlign toggleAlign = ToggleAlign.Right, int indentLevel = 0, bool applyModifiedProperties = false, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetBool(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                bool propertyValue = _propertyService.GetBool(property);

                bool isRightAlign = toggleAlign == ToggleAlign.Right;
                bool newValue = isRightAlign ? 
                    EditorGUILayout.Toggle(label, propertyValue) : 
                    EditorGUILayout.ToggleLeft(label, propertyValue);
                
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetBool(property, newValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal bool DrawShaderLocalKeywordToggle<TProperty>(GUIContent label, Material material, TProperty property, 
            string shaderLocalKeyword, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetBool(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                bool propertyValue = _propertyService.GetBool(property);
                
                bool isRightAlign = toggleAlign == ToggleAlign.Right;
                bool newValue = isRightAlign ? 
                    EditorGUILayout.Toggle(label, propertyValue) : 
                    EditorGUILayout.ToggleLeft(label, propertyValue);
                
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetBool(property, newValue, applyModifiedProperties);
                    KeywordsService.SetKeyword(material, shaderLocalKeyword, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal bool DrawShaderGlobalKeywordToggle<TProperty>(GUIContent label, TProperty property, 
            string shaderGlobalKeyword, ToggleAlign toggleAlign = ToggleAlign.Right,
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetBool(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                bool propertyValue = _propertyService.GetBool(property);
                
                bool isRightAlign = toggleAlign == ToggleAlign.Right;
                bool newValue = isRightAlign ? 
                    EditorGUILayout.Toggle(label, propertyValue) : 
                    EditorGUILayout.ToggleLeft(label, propertyValue);
                
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetBool(property, newValue, applyModifiedProperties);
                    KeywordsService.SetGlobalKeyword(shaderGlobalKeyword, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}