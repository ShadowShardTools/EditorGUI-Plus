using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class SliderEditor
    {
        private readonly EditorUtils _editorUtils;

        public SliderEditor(EditorUtils editorUtils) =>
            _editorUtils = editorUtils;
        
        public void DrawSlider<T>(GUIContent label, T property, Vector2 minMax, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;

            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                var propertyValue = _editorUtils.GetPropertyValue<float>(property);
                
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                var newValue = EditorGUILayout.Slider(label, propertyValue, minMax.x, minMax.y);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                    _editorUtils.SetPropertyValue(property, newValue);
            });
        }
        
        public void DrawSlider<T>(GUIContent label, T property, int indentLevel = 0) where T : class =>
            DrawSlider(label, property, new Vector2(0.0f, 1.0f), indentLevel);
        
        public void DrawSlider<T>(GUIContent label, T property, VectorParam vectorParam, Vector2 minMax, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                var propertyValue = _editorUtils.GetPropertyValue<Vector4>(property);
            
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                var val = propertyValue[(int)vectorParam];
                var newValue = EditorGUILayout.Slider(label, val, minMax.x, minMax.y);
                EditorGUI.showMixedValue = false;
            
                if (EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vectorParam] = newValue;
                    _editorUtils.SetPropertyValue(property, propertyValue);
                }
            });
        }
        
        public void DrawSlider<T>(GUIContent label, T property, VectorParam vectorParam, int indentLevel = 0) where T : class =>
            DrawSlider(label, property, vectorParam, new Vector2(0.0f, 1.0f), indentLevel);
        
        public void DrawIntSlider<T>(GUIContent label, T property, Vector2Int minMax, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;

            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                var propertyValue = _editorUtils.GetIntPropertyValue(property);
                
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                var newValue = EditorGUILayout.IntSlider(label, propertyValue, minMax.x, minMax.y);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                    _editorUtils.SetIntPropertyValue(property, newValue);
            });
        }
        
        public void DrawIntSlider<T>(GUIContent label, T property, int indentLevel = 0) where T : class =>
            DrawIntSlider(label, property, new Vector2Int(0, 1), indentLevel);
        
        public void DrawMinMaxShaderSlider<T>(GUIContent label, T min, T max, Vector2 minMax, int indentLevel = 0) where T : class
        {
            if (min is null || max is null)
                return;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                var minValue = _editorUtils.GetPropertyValue<float>(min);
                var maxValue = _editorUtils.GetPropertyValue<float>(max);
                
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(min) || _editorUtils.HasMixedValue(max);
                EditorGUILayout.MinMaxSlider(label, ref minValue, ref maxValue, minMax.x, minMax.y);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                {
                    _editorUtils.SetPropertyValue(min, minValue);
                    _editorUtils.SetPropertyValue(max, maxValue);
                }
            });
        }
        
        public void DrawMinMaxShaderSlider<T>(GUIContent label, T min, T max, int indentLevel = 0) where T : class =>
            DrawMinMaxShaderSlider(label, min, max, new Vector2(0.0f, 1.0f), indentLevel);
        
        public void DrawMinMaxSliderXY<T>(GUIContent label, T property, Vector2 minMax, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                var propertyValue = _editorUtils.GetPropertyValue<Vector4>(property);
                
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                EditorGUILayout.MinMaxSlider(label, ref propertyValue.x, ref propertyValue.y, minMax.x, minMax.y);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck()) 
                    _editorUtils.SetPropertyValue(property, propertyValue);
            });
        }
        
        public void DrawMinMaxSliderXY<T>(GUIContent label, T property, int indentLevel = 0) where T : class =>
            DrawMinMaxSliderXY(label, property, new Vector2(0.0f, 1.0f), indentLevel);

        public void DrawMinMaxSliderZW<T>(GUIContent label, T property, Vector2 minMax, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                var propertyValue = _editorUtils.GetPropertyValue<Vector4>(property);
                
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                EditorGUILayout.MinMaxSlider(label, ref propertyValue.z, ref propertyValue.w, minMax.x, minMax.y);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck()) 
                    _editorUtils.SetPropertyValue(property, propertyValue);
            });
        }
        
        public void DrawMinMaxSliderZW<T>(GUIContent label, T property, int indentLevel = 0) where T : class =>
            DrawMinMaxSliderZW(label, property, new Vector2(0.0f, 1.0f), indentLevel);
    }
}