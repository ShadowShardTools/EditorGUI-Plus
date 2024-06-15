using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    internal class ToggleEditor
    {
        private readonly PropertyService _propertyService;
        private readonly GroupEditor _groupEditor;

        internal ToggleEditor(PropertyService propertyService, GroupEditor groupEditor)
        {
            _propertyService = propertyService;
            _groupEditor = groupEditor;
        }
        
        public bool DrawToggle<TProperty>(GUIContent label, TProperty property, int indentLevel = 0)
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
                    _propertyService.SetBool(property, newValue);
            }
        }
        
        
        public bool DrawShaderGlobalKeywordToggle<TProperty>(GUIContent label, TProperty property, string shaderGlobalKeyword, int indentLevel = 0)
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
                    RPUtils.SetGlobalKeyword(shaderGlobalKeyword, newValue);
                }
            }
        }
    }
}