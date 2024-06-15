using ShadowShard.Editor.Range;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor.MaterialEditor
{
    public class VectorEditor
    {
        private readonly GroupEditor _groupEditor;

        public VectorEditor(GroupEditor groupEditor) =>
            _groupEditor = groupEditor;
        
        public float DrawFloat(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.floatValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                float propertyValue = property.floatValue;
                
                EditorGUI.showMixedValue = property.hasMixedValue;
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, propertyValue), range.Min, range.Max);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck()) 
                    property.floatValue = newValue;
            }
        }

        public Vector2 DrawVector2(GUIContent label, MaterialProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.vectorValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = property.hasMixedValue;
                Vector2 propertyValue = property.vectorValue;
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    property.vectorValue = new Vector4(newValue.x, newValue.y, property.vectorValue.z, property.vectorValue.w);
            }
        }
        
        public Vector3 DrawVector3(GUIContent label, MaterialProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.vectorValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = property.hasMixedValue;
                Vector3 propertyValue = property.vectorValue;
                Vector3 newValue = EditorGUILayout.Vector3Field(label, propertyValue);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                    property.vectorValue = new Vector4(newValue.x, newValue.y, newValue.z, property.vectorValue.w);
            }
        }
        
        public Vector4 DrawVector4(GUIContent label, MaterialProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.vectorValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = property.hasMixedValue;
                Vector4 newValue = EditorGUILayout.Vector4Field(label, property.vectorValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    property.vectorValue = newValue;
            }
        }
        
        public Vector4 DrawFloatFromVector4(GUIContent label, MaterialProperty property, Vector4Param vector4Param, FloatRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.vectorValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyValue = property.vectorValue;
                
                EditorGUI.showMixedValue = property.hasMixedValue;
                float val = propertyValue[(int)vector4Param];
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, val), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vector4Param] = newValue;
                    property.vectorValue = propertyValue;
                }
            }
        }
        
        public Vector4 DrawNormalizedFloatFromVector4(GUIContent label, MaterialProperty property, Vector4Param vector4Param, int indentLevel = 0) =>
            DrawFloatFromVector4(label, property, vector4Param, FloatRange.Normalized, indentLevel);
        
        public Vector4 DrawMinFloatFromVector4(GUIContent label, MaterialProperty property, Vector4Param vector4Param, float min = 0.0f, int indentLevel = 0) =>
            DrawFloatFromVector4(label, property, vector4Param, FloatRange.ToMaxFrom(min), indentLevel);
        
        public Vector4 DrawVector4Start(GUIContent label, MaterialProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.vectorValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = property.hasMixedValue;
                Vector4 propertyVector4Value = property.vectorValue;
                Vector2 propertyValue = new(propertyVector4Value.x, propertyVector4Value.y);
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    Vector4 newVector4Value = new(newValue.x, newValue.y, propertyVector4Value.z, propertyVector4Value.w);
                    property.vectorValue = newVector4Value;
                }
            }
        }
        
        public Vector4 DrawVector4End(GUIContent label, MaterialProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.vectorValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = property.hasMixedValue;
                Vector4 propertyVector4Value = property.vectorValue;
                Vector2 propertyValue = new(propertyVector4Value.z, propertyVector4Value.w);
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    Vector4 newVector4Value = new(propertyVector4Value.x, propertyVector4Value.y, newValue.x, newValue.y);
                    property.vectorValue = newVector4Value;
                }
            }
        }

        public Color DrawColor(GUIContent label, MaterialProperty property, bool showAlpha = true, bool hdr = false, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.colorValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = property.hasMixedValue;
                Color newValue = EditorGUILayout.ColorField(label, property.colorValue, true, showAlpha, hdr);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    property.colorValue = newValue;
            }
        }
    }
}