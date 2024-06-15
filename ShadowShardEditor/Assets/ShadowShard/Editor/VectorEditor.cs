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
                Vector4 newValue = EditorGUILayout.Vector4Field(label, property.vector4Value);
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
    }
}