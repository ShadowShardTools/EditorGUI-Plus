using ShadowShard.Editor.Enums;
using ShadowShard.Editor.Range;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    internal class VectorEditor
    {
        private readonly PropertyService _propertyService;
        private readonly GroupEditor _groupEditor;

        internal VectorEditor(PropertyService propertyService, GroupEditor groupEditor)
        {
            _propertyService = propertyService;
            _groupEditor = groupEditor;
        }
        
        internal float DrawFloat<TProperty>(GUIContent label, TProperty property, FloatRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetFloat(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                float propertyValue = _propertyService.GetFloat(property);
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, propertyValue), range.Min, range.Max);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck()) 
                    _propertyService.SetFloat(property, newValue);
            }
        }

        internal Vector2 DrawVector2<TProperty>(GUIContent label, TProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector2(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector2 propertyValue = _propertyService.GetVector2(property);
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    _propertyService.SetVector2(property, newValue);
            }
        }
        
        internal Vector3 DrawVector3<TProperty>(GUIContent label, TProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector3(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector3 propertyValue = _propertyService.GetVector3(property);
                Vector3 newValue = EditorGUILayout.Vector3Field(label, propertyValue);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                    _propertyService.SetVector3(property, newValue);
            }
        }
        
        internal Vector4 DrawVector4<TProperty>(GUIContent label, TProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector4(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector4 propertyValue = _propertyService.GetVector4(property);
                Vector4 newValue = EditorGUILayout.Vector4Field(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    _propertyService.SetVector4(property, newValue);
            }
        }
        
        internal Vector2 DrawFloatFromVector2<TProperty>(GUIContent label, TProperty property, Vector2Param vector2Param, FloatRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector2(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector2 propertyValue = _propertyService.GetVector2(property);
                float val = propertyValue[(int)vector2Param];
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, val), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vector2Param] = newValue;
                    _propertyService.SetVector2(property, propertyValue);
                }
            }
        }
        
        internal Vector3 DrawFloatFromVector3<TProperty>(GUIContent label, TProperty property, Vector3Param vector3Param, FloatRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector3(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector3 propertyValue = _propertyService.GetVector3(property);
                float val = propertyValue[(int)vector3Param];
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, val), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vector3Param] = newValue;
                    _propertyService.SetVector3(property, propertyValue);
                }
            }
        }
        
        internal Vector4 DrawFloatFromVector4<TProperty>(GUIContent label, TProperty property, Vector4Param vector4Param, FloatRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector4(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector4 propertyValue = _propertyService.GetVector4(property);
                float val = propertyValue[(int)vector4Param];
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, val), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vector4Param] = newValue;
                    _propertyService.SetVector4(property, propertyValue);
                }
            }
        }
        
        internal Vector4 DrawVector4Start<TProperty>(GUIContent label, TProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector4(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector4 propertyVector4Value = _propertyService.GetVector4(property);
                Vector2 propertyValue = new(propertyVector4Value.x, propertyVector4Value.y);
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    Vector4 newVector4Value = new(newValue.x, newValue.y, propertyVector4Value.z, propertyVector4Value.w);
                    _propertyService.SetVector4(property, newVector4Value);
                }
            }
        }
        
        internal Vector4 DrawVector4End<TProperty>(GUIContent label, TProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector4(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector4 propertyVector4Value = _propertyService.GetVector4(property);
                Vector2 propertyValue = new(propertyVector4Value.z, propertyVector4Value.w);
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    Vector4 newVector4Value = new(propertyVector4Value.x, propertyVector4Value.y, newValue.x, newValue.y);
                    _propertyService.SetVector4(property, newVector4Value);
                }
            }
        }

        internal Color DrawColor<TProperty>(GUIContent label, TProperty property, bool showAlpha = true, bool hdr = false, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetColor(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Color propertyValue = _propertyService.GetColor(property);
                Color newValue = EditorGUILayout.ColorField(label, propertyValue, true, showAlpha, hdr);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    _propertyService.SetColor(property, newValue);
            }
        }
    }
}