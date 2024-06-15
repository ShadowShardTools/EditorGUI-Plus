using ShadowShard.Editor.Range;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class VectorEditor
    {
        private readonly GroupEditor _groupEditor;

        public VectorEditor(GroupEditor groupEditor) =>
            _groupEditor = groupEditor;
        
        public float DrawFloat(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.floatValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                float propertyValue = property.floatValue;
                
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, propertyValue), range.Min, range.Max);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck()) 
                    property.floatValue = newValue;
            }
        }

        public Vector2 DrawVector2(GUIContent label, SerializedProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.vector2Value;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                Vector2 newValue = EditorGUILayout.Vector2Field(label, property.vector2Value);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    property.vector2Value = newValue;
            }
        }
        
        public Vector3 DrawVector3(GUIContent label, SerializedProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.vector3Value;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                Vector3 newValue = EditorGUILayout.Vector3Field(label, property.vector3Value);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                    property.vector3Value = newValue;
            }
        }
        
        public Vector4 DrawVector4(GUIContent label, SerializedProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.vector4Value;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                Vector3 newValue = EditorGUILayout.Vector4Field(label, property.vector4Value);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    property.vector4Value = newValue;
            }
        }

        public Color DrawColor(GUIContent label, SerializedProperty property, bool showAlpha = true, bool hdr = false, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.colorValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                Color newValue = EditorGUILayout.ColorField(label, property.colorValue, true, showAlpha, hdr);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    property.colorValue = newValue;
            }
        }
        
        //TODO: move to MaterialEditor
        /*public void DrawVectorFloat<T>(GUIContent label, T property, Vector4Param vector4Param, Vector2 minMax, int indentLevel = 0) where T : class
        {
            _groupEditor.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyValue = _groupEditor.GetPropertyValue<Vector4>(property);
                
                EditorGUI.showMixedValue = _groupEditor.HasMixedValue(property);
                var val = propertyValue[(int)vector4Param];
                var newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, val), minMax.x, minMax.y);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vector4Param] = newValue;
                    _groupEditor.SetPropertyValue(property, propertyValue);
                }
            });
        }
        
        public void DrawClampedVectorFloat<T>(GUIContent label, T property, Vector4Param vector4Param, int indentLevel = 0) where T : class =>
            DrawVectorFloat(label, property, vector4Param, new Vector2(0.0f, 1.0f), indentLevel);
        
        public void DrawMinVectorFloat<T>(GUIContent label, T property, Vector4Param vector4Param, float min = 0.0f, int indentLevel = 0) where T : class =>
            DrawVectorFloat(label, property, vector4Param,new Vector2(min, float.MaxValue), indentLevel);
        
        public void DrawVector2XY<T>(GUIContent label, T property, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;
            
            _groupEditor.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyVector4Value = _groupEditor.GetVectorPropertyValue(property);

                // Extract X and Y values from Vector4
                Vector2 propertyValue = new(propertyVector4Value.x, propertyVector4Value.y);

                EditorGUI.showMixedValue = _groupEditor.HasMixedValue(property);
                // Display Vector2 field for Z and W
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    // Update Vector4 with new Z and W values
                    Vector4 newVector4Value = new(newValue.x, newValue.y, propertyVector4Value.z, propertyVector4Value.w);
                    _groupEditor.SetPropertyValue(property, newVector4Value);
                }
            });
        }
        
        public void DrawVector2ZW<T>(GUIContent label, T property, int indentLevel = 0) where T : class
        {
            if (property is null)
                return;
            
            _groupEditor.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyVector4Value = _groupEditor.GetVectorPropertyValue(property);

                // Extract Z and W values from Vector4
                Vector2 propertyValue = new(propertyVector4Value.z, propertyVector4Value.w);

                EditorGUI.showMixedValue = _groupEditor.HasMixedValue(property);
                // Display Vector2 field for Z and W
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    // Update Vector4 with new Z and W values
                    Vector4 newVector4Value = new(propertyVector4Value.x, propertyVector4Value.y, newValue.x, newValue.y);
                    _groupEditor.SetPropertyValue(property, newVector4Value);
                }
            });
        }*/
    }
}