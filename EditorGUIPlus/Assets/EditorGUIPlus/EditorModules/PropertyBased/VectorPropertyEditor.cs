using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.PropertyBased
{
    internal sealed class VectorPropertyEditor
    {
        private readonly PropertyService _propertyService;
        private readonly GroupEditor _groupEditor;

        internal VectorPropertyEditor(PropertyService propertyService, GroupEditor groupEditor)
        {
            _propertyService = propertyService;
            _groupEditor = groupEditor;
        }
        
        internal float DrawFloat<TProperty>(GUIContent label, TProperty property, FloatRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null)
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
                {
                    _propertyService.SetFloat(property, newValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal double DrawDouble(GUIContent label, SerializedProperty property, DoubleRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.doubleValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                double propertyValue = property.doubleValue;
                double newValue = Math.Clamp(EditorGUILayout.DoubleField(label, propertyValue), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    property.doubleValue = newValue;
                    if (applyModifiedProperties)
                        property.serializedObject.ApplyModifiedProperties();
                    onChangedCallback?.Invoke();
                }
            }
        }

        internal Vector2 DrawVector2<TProperty>(GUIContent label, TProperty property, Vector2Range range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector2(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector2 propertyValue = _propertyService.GetVector2(property);
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue).Clamp(range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetVector2(property, newValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3 DrawVector3<TProperty>(GUIContent label, TProperty property, Vector3Range range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector3(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector3 propertyValue = _propertyService.GetVector3(property);
                Vector3 newValue = EditorGUILayout.Vector3Field(label, propertyValue).Clamp(range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetVector3(property, newValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawVector4<TProperty>(GUIContent label, TProperty property, Vector4Range range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector4(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector4 propertyValue = _propertyService.GetVector4(property);
                Vector4 newValue = EditorGUILayout.Vector4Field(label, propertyValue).Clamp(range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetVector4(property, newValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector2 DrawFloatFromVector2<TProperty>(GUIContent label, TProperty property, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
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
                    _propertyService.SetVector2(property, propertyValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3 DrawFloatFromVector3<TProperty>(GUIContent label, TProperty property, Vector3Param vector3Param, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
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
                    _propertyService.SetVector3(property, propertyValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawFloatFromVector4<TProperty>(GUIContent label, TProperty property, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
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
                    _propertyService.SetVector4(property, propertyValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawVector4Start<TProperty>(GUIContent label, TProperty property, Vector2Range range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector4(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector4 propertyVector4Value = _propertyService.GetVector4(property);
                Vector2 propertyValue = new(propertyVector4Value.x, propertyVector4Value.y);
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue).Clamp(range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    Vector4 newVector4Value = new(newValue.x, newValue.y, propertyVector4Value.z, propertyVector4Value.w);
                    _propertyService.SetVector4(property, newVector4Value, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawVector4End<TProperty>(GUIContent label, TProperty property, Vector2Range range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector4(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector4 propertyVector4Value = _propertyService.GetVector4(property);
                Vector2 propertyValue = new(propertyVector4Value.z, propertyVector4Value.w);
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue).Clamp(range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    Vector4 newVector4Value = new(propertyVector4Value.x, propertyVector4Value.y, newValue.x, newValue.y);
                    _propertyService.SetVector4(property, newVector4Value, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Bounds DrawBoundsField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.boundsValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Bounds newValue = EditorGUILayout.BoundsField(label, property.boundsValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    property.boundsValue = newValue;
                    if (applyModifiedProperties)
                        property.serializedObject.ApplyModifiedProperties();
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Rect DrawRectField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.rectValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Rect newValue = EditorGUILayout.RectField(label, property.rectValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    property.rectValue = newValue;
                    if (applyModifiedProperties)
                        property.serializedObject.ApplyModifiedProperties();
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}