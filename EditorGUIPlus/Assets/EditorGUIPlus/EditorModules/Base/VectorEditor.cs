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
        
        internal float DrawFloat(GUIContent label, float property, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property;
            
            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, property), range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    property = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal double DrawDouble(GUIContent label, double property, DoubleRange range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                double newValue = Math.Clamp(EditorGUILayout.DoubleField(label, property), range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    property = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }

        internal Vector2 DrawVector2(GUIContent label, Vector2 vector2, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector2;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector2 newValue = EditorGUILayout.Vector2Field(label, vector2).Clamp(range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    vector2 = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3 DrawVector3(GUIContent label, Vector3 vector3, Vector3Range range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector3;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector3 newValue = EditorGUILayout.Vector3Field(label, vector3).Clamp(range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    vector3 = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawVector4(GUIContent label, Vector4 vector4, Vector4Range range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector4;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector4 newValue = EditorGUILayout.Vector4Field(label, vector4).Clamp(range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    vector4 = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector2 DrawFloatFromVector2(GUIContent label, Vector2 vector2, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector2;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                float val = vector2[(int)vector2Param];
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, val), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    vector2[(int)vector2Param] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3 DrawFloatFromVector3(GUIContent label, Vector3 vector3, Vector3Param vector3Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector3;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                float val = vector3[(int)vector3Param];
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, val), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    vector3[(int)vector3Param] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawFloatFromVector4(GUIContent label, Vector4 vector4, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector4;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                float val = vector4[(int)vector4Param];
                float newValue = Mathf.Clamp(EditorGUILayout.FloatField(label, val), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    vector4[(int)vector4Param] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawVector4Start(GUIContent label, Vector4 vector4, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector4;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                Vector2 propertyValue = new Vector2(vector4.x, vector4.y);
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue).Clamp(range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    vector4 = new Vector4(newValue.x, newValue.y, vector4.z, vector4.w);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawVector4End(GUIContent label, Vector4 vector4, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector4;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                Vector2 propertyValue = new Vector2(vector4.z, vector4.w);
                Vector2 newValue = EditorGUILayout.Vector2Field(label, propertyValue).Clamp(range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    vector4 = new Vector4(vector4.x, vector4.y, newValue.x, newValue.y);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Bounds DrawBoundsField(GUIContent label, Bounds bounds, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return bounds;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Bounds newValue = EditorGUILayout.BoundsField(label, bounds);

                if (EditorGUI.EndChangeCheck())
                {
                    bounds = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Rect DrawRectField(GUIContent label, Rect rect, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return rect;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Rect newValue = EditorGUILayout.RectField(label, rect);

                if (EditorGUI.EndChangeCheck())
                {
                    rect = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}