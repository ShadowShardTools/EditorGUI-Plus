using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class VectorEditor
    {
        private readonly EditorUtils _editorUtils;

        public VectorEditor(EditorUtils editorUtils) =>
            _editorUtils = editorUtils;
        
        public void DrawFloat<T>(GUIContent label, T property, Vector2 minMax, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                var propertyValue = _editorUtils.GetPropertyValue<float>(property);
                
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                var newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, propertyValue), minMax.x, minMax.y);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck()) 
                    _editorUtils.SetPropertyValue(property, newValue);
            });
        }
        
        public void DrawFloat<T>(GUIContent label, T property, int indentLevel = 0) where T : class =>
            DrawFloat(label, property, new Vector2(float.MinValue, float.MaxValue), indentLevel);
        
        public void DrawClampedFloat<T>(GUIContent label, T property, int indentLevel = 0) where T : class =>
            DrawFloat(label, property, new Vector2(0.0f, 1.0f), indentLevel);
        
        public void DrawMinFloat<T>(GUIContent label, T property, float min = 0.0f, int indentLevel = 0) where T : class =>
            DrawFloat(label, property, new Vector2(min, float.MaxValue), indentLevel);
        
        public void DrawVectorFloat<T>(GUIContent label, T property, VectorParam vectorParam, Vector2 minMax, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyValue = _editorUtils.GetPropertyValue<Vector4>(property);
                
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                var val = propertyValue[(int)vectorParam];
                var newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, val), minMax.x, minMax.y);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vectorParam] = newValue;
                    _editorUtils.SetPropertyValue(property, propertyValue);
                }
            });
        }
        
        public void DrawClampedVectorFloat<T>(GUIContent label, T property, VectorParam vectorParam, int indentLevel = 0) where T : class =>
            DrawVectorFloat(label, property, vectorParam, new Vector2(0.0f, 1.0f), indentLevel);
        
        public void DrawMinVectorFloat<T>(GUIContent label, T property, VectorParam vectorParam, float min = 0.0f, int indentLevel = 0) where T : class =>
            DrawVectorFloat(label, property, vectorParam,new Vector2(min, float.MaxValue), indentLevel);

        public void DrawVector2<T>(GUIContent label, T property, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyValue = _editorUtils.GetVectorPropertyValue(property);
                
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                    _editorUtils.SetPropertyValue(property, newValue);
            });
        }
        
        public void DrawVector3<T>(GUIContent label, T property, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                Vector3 propertyValue = _editorUtils.GetPropertyValue<Vector3>(property);
                
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                Vector3 newValue = EditorGUILayout.Vector3Field(label, propertyValue);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                    _editorUtils.SetPropertyValue(property, newValue);
            });
        }
        
        public void DrawVector4<T>(GUIContent label, T property, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyValue = _editorUtils.GetPropertyValue<Vector4>(property);
                
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                Vector3 newValue = EditorGUILayout.Vector3Field(label, propertyValue);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                    _editorUtils.SetPropertyValue(property, newValue);
            });
        }
        
        public void DrawVector2XY<T>(GUIContent label, T property, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyVector4Value = _editorUtils.GetVectorPropertyValue(property);

                // Extract X and Y values from Vector4
                Vector2 propertyValue = new(propertyVector4Value.x, propertyVector4Value.y);

                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                // Display Vector2 field for Z and W
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    // Update Vector4 with new Z and W values
                    Vector4 newVector4Value = new(newValue.x, newValue.y, propertyVector4Value.z, propertyVector4Value.w);
                    _editorUtils.SetPropertyValue(property, newVector4Value);
                }
            });
        }
        
        public void DrawVector2ZW<T>(GUIContent label, T property, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyVector4Value = _editorUtils.GetVectorPropertyValue(property);

                // Extract Z and W values from Vector4
                Vector2 propertyValue = new(propertyVector4Value.z, propertyVector4Value.w);

                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                // Display Vector2 field for Z and W
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    // Update Vector4 with new Z and W values
                    Vector4 newVector4Value = new(propertyVector4Value.x, propertyVector4Value.y, newValue.x, newValue.y);
                    _editorUtils.SetPropertyValue(property, newVector4Value);
                }
            });
        }
        
        public void DrawColor<T>(GUIContent label, T property, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                Color propertyValue = _editorUtils.GetPropertyValue<Color>(property);

                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                Color newValue = EditorGUILayout.ColorField(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck()) 
                    _editorUtils.SetPropertyValue(property, newValue);
            });
        }
    }
}