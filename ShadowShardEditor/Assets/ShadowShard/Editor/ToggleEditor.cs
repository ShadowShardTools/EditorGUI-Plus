using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class ToggleEditor
    {
        private readonly EditorUtils _editorUtils;

        public const float BoolTolerance = 0.5f;

        public ToggleEditor(EditorUtils editorUtils) =>
            _editorUtils = editorUtils;
        
        public bool DrawToggle<T>(GUIContent label, T property, int indentLevel = 0) where T : class
        {
            if (property is null)
                return false;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                
                if(property is MaterialProperty matProperty)
                {
                    var propertyValue = _editorUtils.GetPropertyValue<float>(matProperty);
                    EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                    var newValue = EditorGUILayout.Toggle(label, propertyValue > BoolTolerance);
                    EditorGUI.showMixedValue = false;
                    
                    if (EditorGUI.EndChangeCheck())
                        _editorUtils.SetPropertyValue(matProperty, newValue ? 1.0f : 0.0f);
                }
                else if(property is SerializedProperty serializedProperty)
                {
                    var propertyValue = _editorUtils.GetPropertyValue<bool>(serializedProperty);
                    EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                    var newValue = EditorGUILayout.Toggle(label, propertyValue);
                    EditorGUI.showMixedValue = false;
                    
                    if (EditorGUI.EndChangeCheck())
                        _editorUtils.SetPropertyValue(serializedProperty, newValue);
                }
            });

            return property switch
            {
                MaterialProperty => _editorUtils.GetPropertyValue<float>(property) > BoolTolerance,
                SerializedProperty => _editorUtils.GetPropertyValue<bool>(property),
                _ => false
            };
        }
        
        public bool DrawToggle<T>(GUIContent label, T property, string keyword, int indentLevel = 0) where T : class
        {
            if (property is null)
                return false;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                var propertyValue = _editorUtils.GetPropertyValue<bool>(property);
                
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                var newValue = EditorGUILayout.Toggle(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _editorUtils.SetPropertyValue(property, newValue);
                    RPUtils.SetGlobalKeyword(keyword, newValue);
                }
            });
            
            return _editorUtils.GetPropertyValue<bool>(property);
        }
    }
}