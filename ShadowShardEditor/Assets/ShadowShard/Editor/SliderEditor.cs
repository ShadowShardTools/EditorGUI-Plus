using ShadowShard.Editor.Range;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class SliderEditor
    {
        private readonly EditorUtils _editorUtils;

        private readonly FloatRange _defaultFloatRange = new(0.0f, 1.0f);
        private readonly IntRange _defaultIntRange = new(0, 1);

        public SliderEditor(EditorUtils editorUtils) =>
            _editorUtils = editorUtils;
        
        public float DrawSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0)
        {
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                float newValue = EditorGUILayout.Slider(label, property.floatValue, range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    property.floatValue = newValue;
            });

            return property.floatValue;
        }
        
        public float DrawSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) => 
            DrawSlider(label, property, _defaultFloatRange, indentLevel);
        
        public int DrawIntSlider(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0)
        {
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                int newValue = EditorGUILayout.IntSlider(label, property.intValue, range.Min, range.Max);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                    property.intValue = newValue;
            });

            return property.intValue;
        }
        
        public int DrawIntSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            DrawIntSlider(label, property, _defaultIntRange, indentLevel);
        
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