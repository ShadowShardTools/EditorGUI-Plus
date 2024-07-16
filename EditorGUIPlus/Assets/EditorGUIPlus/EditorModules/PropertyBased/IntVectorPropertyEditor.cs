using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.PropertyBased
{
    public sealed class IntVectorPropertyEditor
    {
        private readonly PropertyService _propertyService;
        private readonly GroupEditor _groupEditor;

        internal IntVectorPropertyEditor(PropertyService propertyService, GroupEditor groupEditor)
        {
            _propertyService = propertyService;
            _groupEditor = groupEditor;
        }
        
        internal int DrawInt<TProperty>(GUIContent label, TProperty property, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetInt(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                int propertyValue = _propertyService.GetInt(property);
                int newValue = Mathf.Clamp(EditorGUILayout.IntField(label, propertyValue), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetInt(property, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal long DrawLong(GUIContent label, SerializedProperty property, LongRange range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.longValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                long propertyValue = property.longValue;
                long newValue = Math.Clamp(EditorGUILayout.LongField(label, propertyValue), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    property.longValue = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }

        internal Vector2Int DrawVector2Int<TProperty>(GUIContent label, TProperty property, Vector2IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector2Int(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector2Int propertyValue = _propertyService.GetVector2Int(property);
                Vector2Int newValue = EditorGUILayout.Vector2IntField(label, propertyValue).ClampInt(range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetVector2Int(property, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3Int DrawVector3Int<TProperty>(GUIContent label, TProperty property, Vector3IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector3Int(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector3Int propertyValue = _propertyService.GetVector3Int(property);
                Vector3Int newValue = EditorGUILayout.Vector3IntField(label, propertyValue).ClampInt(range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetVector3Int(property, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector2Int DrawIntFromVector2Int<TProperty>(GUIContent label, TProperty property, 
            Vector2Param vector2Param, IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector2Int(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector2Int propertyValue = _propertyService.GetVector2Int(property);
                int val = propertyValue[(int)vector2Param];
                int newValue = Mathf.Clamp(EditorGUILayout.IntField(label, val), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vector2Param] = newValue;
                    _propertyService.SetVector2Int(property, propertyValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3Int DrawIntFromVector3Int<TProperty>(GUIContent label, TProperty property, 
            Vector3Param vector3Param, IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector3Int(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector3Int propertyValue = _propertyService.GetVector3Int(property);
                int val = propertyValue[(int)vector3Param];
                int newValue = Mathf.Clamp(EditorGUILayout.IntField(label, val), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vector3Param] = newValue;
                    _propertyService.SetVector3Int(property, propertyValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal BoundsInt DrawIntBoundsField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.boundsIntValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                BoundsInt newValue = EditorGUILayout.BoundsIntField(label, property.boundsIntValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    property.boundsIntValue = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal RectInt DrawIntRectField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.rectIntValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                RectInt newValue = EditorGUILayout.RectIntField(label, property.rectIntValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    property.rectIntValue = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}