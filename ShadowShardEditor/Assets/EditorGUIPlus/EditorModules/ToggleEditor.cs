using System;
using EditorGUIPlus.MaterialEditor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace EditorGUIPlus.EditorModules
{
    internal sealed class ToggleEditor
    {
        private readonly PropertyService _propertyService;
        private readonly GroupEditor _groupEditor;

        internal ToggleEditor(PropertyService propertyService, GroupEditor groupEditor)
        {
            _propertyService = propertyService;
            _groupEditor = groupEditor;
        }
        
        internal bool DrawToggle<TProperty>(GUIContent label, TProperty property, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetBool(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                bool propertyValue = _propertyService.GetBool(property);
                bool newValue = EditorGUILayout.Toggle(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetBool(property, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal bool DrawShaderLocalKeywordToggle<TProperty>(GUIContent label, Material material, TProperty property, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetBool(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                bool propertyValue = _propertyService.GetBool(property);
                bool newValue = EditorGUILayout.Toggle(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetBool(property, newValue);
                    KeywordsService.SetKeyword(material, shaderGlobalKeyword, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal bool DrawShaderGlobalKeywordToggle<TProperty>(GUIContent label, TProperty property, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetBool(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                bool propertyValue = _propertyService.GetBool(property);
                bool newValue = EditorGUILayout.Toggle(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetBool(property, newValue);
                    KeywordsService.SetGlobalKeyword(shaderGlobalKeyword, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}