using ShadowShard.Editor.Range;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class SliderEditor
    {
        private readonly EditorUtils _editorUtils;

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
            DrawSlider(label, property, FloatRange.Normalized, indentLevel);
        
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
            DrawIntSlider(label, property, IntRange.Normalized, indentLevel);

        public void DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, FloatRange range, int indentLevel = 0)
        {
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                Vector3 propertyValue = property.vector3Value;
                float channelValue = propertyValue[(int)vectorParam];
                float newValue = EditorGUILayout.Slider(label, channelValue, range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if(EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vectorParam] = newValue;
                    _editorUtils.SetPropertyValue(property, propertyValue);
                }
            });
        }

        public void DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, int indentLevel = 0) =>
            DrawFromVector3ParamSlider(label, property, vectorParam, FloatRange.Normalized, indentLevel);
        
        public void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, SerializedProperty property, FloatRange range, int indentLevel = 0)
        {
            DrawFromVector3ParamSlider(labelX, property, Vector3Param.X, range, indentLevel);
            DrawFromVector3ParamSlider(labelY, property, Vector3Param.Y, range, indentLevel);
            DrawFromVector3ParamSlider(labelZ, property, Vector3Param.Z, range, indentLevel);
        }

        public void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, SerializedProperty property, int indentLevel = 0) =>
            DrawVector3Sliders(labelX, labelY, labelZ, property, FloatRange.Normalized, indentLevel);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, SerializedProperty maxProperty, FloatRange range, int indentLevel = 0)
        {
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                float minValue = minProperty.floatValue;
                float maxValue = maxProperty.floatValue;
                
                EditorGUI.showMixedValue = minProperty.hasMultipleDifferentValues || maxProperty.hasMultipleDifferentValues;
                EditorGUILayout.MinMaxSlider(label, ref minValue, ref maxValue, range.Min, range.Max);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                {
                    minProperty.floatValue = minValue;
                    maxProperty.floatValue = maxValue;
                }
            });

            return new FloatRange(minProperty.floatValue, maxProperty.floatValue);
        }

        public FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, SerializedProperty maxProperty, int indentLevel = 0) =>
            DrawMinMaxSlider(label, minProperty, maxProperty, FloatRange.Normalized, indentLevel);
        
        //TODO: move to MaterialEditor
        public FloatRange DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0)
        {
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyValue = property.vector4Value;
                
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                EditorGUILayout.MinMaxSlider(label, ref propertyValue.x, ref propertyValue.y, range.Min, range.Max);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                {
                    property.vector4Value = propertyValue;
                }
            });

            return new FloatRange(property.vector4Value.x, property.vector4Value.y);
        }
        
        public FloatRange DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            DrawMinMaxVector4StartSlider(label, property, FloatRange.Normalized, indentLevel);

        public FloatRange DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0)
        {
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyValue = property.vector4Value;
                
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                EditorGUILayout.MinMaxSlider(label, ref propertyValue.z, ref propertyValue.w, range.Min, range.Max);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                {
                    property.vector4Value = propertyValue;
                }
            });

            return new FloatRange(property.vector4Value.x, property.vector4Value.y);
        }
        
        public FloatRange DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            DrawMinMaxVector4EndSlider(label, property, FloatRange.Normalized, indentLevel);
    }
}