using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules
{
    internal sealed class ColorEditor
    {
        private readonly PropertyService _propertyService;
        private readonly GroupEditor _groupEditor;

        internal ColorEditor(PropertyService propertyService, GroupEditor groupEditor)
        {
            _propertyService = propertyService;
            _groupEditor = groupEditor;
        }
        
        internal Color DrawColor<TProperty>(GUIContent label, TProperty property, bool showAlpha = true,
            bool hdr = false, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetColor(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Color propertyValue = _propertyService.GetColor(property);
                Color newValue = EditorGUILayout.ColorField(label, propertyValue, true, showAlpha, hdr);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetColor(property, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Gradient DrawGradient(GUIContent label, SerializedProperty property, bool hdr = false, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.gradientValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Gradient propertyValue = property.gradientValue;
                Gradient newValue = EditorGUILayout.GradientField(label, propertyValue, hdr);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                {
                    property.gradientValue = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}