using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.Base
{
    internal sealed class VectorEditor
    {
        private readonly GroupEditor _groupEditor;

        internal VectorEditor(GroupEditor groupEditor)
        {
            _groupEditor = groupEditor;
        }
        
        internal float DrawFloat(GUIContent label, ref float property, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            float tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;
            
            return property;
            
            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, tempProperty), range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal double DrawDouble(GUIContent label, ref double property, DoubleRange range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            double tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;
            
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                double newValue = Math.Clamp(EditorGUILayout.DoubleField(label, tempProperty), range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }

        internal Vector2 DrawVector2(GUIContent label, ref Vector2 property, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            Vector2 tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;
            
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector2 newValue = EditorGUILayout.Vector2Field(label, tempProperty).Clamp(range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3 DrawVector3(GUIContent label, ref Vector3 property, Vector3Range range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            Vector3 tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;
            
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector3 newValue = EditorGUILayout.Vector3Field(label, tempProperty).Clamp(range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawVector4(GUIContent label, ref Vector4 property, Vector4Range range, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            Vector4 tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;
            
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector4 newValue = EditorGUILayout.Vector4Field(label, tempProperty).Clamp(range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector2 DrawFloatFromVector2(GUIContent label, ref Vector2 property, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            Vector2 tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;

            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                float val = tempProperty[(int)vector2Param];
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, val), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty[(int)vector2Param] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3 DrawFloatFromVector3<TProperty>(GUIContent label, ref Vector3 property, Vector3Param vector3Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            Vector3 tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;

            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                float val = tempProperty[(int)vector3Param];
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, val), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty[(int)vector3Param] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawFloatFromVector4<TProperty>(GUIContent label, ref Vector4 property, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            Vector4 tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;

            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                float val = tempProperty[(int)vector4Param];
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, val), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty[(int)vector4Param] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawVector4Start(GUIContent label, ref Vector4 property, Vector2Range range, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            Vector4 tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;

            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                Vector2 propertyValue = new(tempProperty.x, tempProperty.y);
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue).Clamp(range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    Vector4 newVector4Value = new(newValue.x, newValue.y, tempProperty.z, tempProperty.w);
                    tempProperty = newVector4Value;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawVector4End(GUIContent label, ref Vector4 property, Vector2Range range, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            Vector4 tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;

            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                Vector2 propertyValue = new(tempProperty.z, tempProperty.w);
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue).Clamp(range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    Vector4 newVector4Value = new(tempProperty.x, tempProperty.y, newValue.x, newValue.y);
                    tempProperty = newVector4Value;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Bounds DrawBoundsField(GUIContent label, ref Bounds property, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            Bounds tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;

            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Bounds newValue = EditorGUILayout.BoundsField(label, tempProperty);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Rect DrawRectField(GUIContent label, ref Rect property, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            Rect tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;

            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Rect newValue = EditorGUILayout.RectField(label, tempProperty);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}