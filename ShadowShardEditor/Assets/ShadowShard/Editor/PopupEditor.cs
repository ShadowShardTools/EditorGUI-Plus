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
        
        public int DrawPopup<T>(GUIContent label, T property, string[] displayedOptions, int indentLevel = 0) where T : class
        {
            if (property is null)
                return 0;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                var propertyValue = _editorUtils.GetEnumPropertyValue(property);

                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                var newValue = EditorGUILayout.Popup(label, propertyValue, displayedOptions);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck()) 
                    _editorUtils.SetEnumPropertyValue(property, newValue);
            });
            
            return _editorUtils.GetEnumPropertyValue(property);
        }
        
        public bool DrawBooleanPopup<T>(GUIContent label, T property, string[] displayedOptions, int indentLevel = 0) where T : class
        {
            if (property is null)
                return false;

            if (displayedOptions.Length != 2)
            {
                EditorGUILayout.HelpBox(BooleanDisplayedOptionsError, MessageType.Error);
                return false;
            }
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                var propertyValue = _editorUtils.GetEnumPropertyValue(property);
            
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                var newValue = EditorGUILayout.Popup(label, propertyValue, displayedOptions);
                EditorGUI.showMixedValue = false;
            
                if (EditorGUI.EndChangeCheck())
                    _editorUtils.SetEnumPropertyValue(property, newValue);
            });
            
            return _editorUtils.GetEnumPropertyValue(property) > 0;
        }
        
        public bool DrawBooleanPopup<T>(GUIContent label, T property, string[] displayedOptions, string keyword, int indentLevel = 0) where T : class
        {
            if (property is null)
                return false;

            if (displayedOptions.Length != 2)
            {
                EditorGUILayout.HelpBox(BooleanDisplayedOptionsError, MessageType.Error);
                return false;
            }
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                var propertyValue = _editorUtils.GetEnumPropertyValue(property);
            
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                var newValue = EditorGUILayout.Popup(label, propertyValue, displayedOptions);
                EditorGUI.showMixedValue = false;
            
                if (EditorGUI.EndChangeCheck())
                {
                    var val = newValue > 0;
                    _editorUtils.SetPropertyValue(property, val);
                    RPUtils.SetGlobalKeyword(keyword, val);
                }
            });

            return _editorUtils.GetEnumPropertyValue(property) > 0;
        }
    }
}