using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.Base
{
    public sealed class VectorIntEditor
    {
        private readonly GroupEditor _groupEditor;

        internal VectorIntEditor(GroupEditor groupEditor)
        {
            _groupEditor = groupEditor;
        }
        
        internal int DrawInt(GUIContent label, int property, IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int newValue = Mathf.Clamp(EditorGUILayout.IntField(label, property), range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    property = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal long DrawLong(GUIContent label, long property, LongRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                long newValue = Math.Clamp(EditorGUILayout.LongField(label, property), range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    property = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }

        internal Vector2Int DrawVector2Int(GUIContent label, Vector2Int vector2Int, Vector2IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector2Int;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector2Int newValue = EditorGUILayout.Vector2IntField(label, vector2Int).ClampInt(range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    vector2Int = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3Int DrawVector3Int(GUIContent label, Vector3Int vector3Int, Vector3IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector3Int;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector3Int newValue = EditorGUILayout.Vector3IntField(label, vector3Int).ClampInt(range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    vector3Int = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector2Int DrawIntFromVector2Int(GUIContent label, Vector2Int vector2Int, Vector2Param vector2Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector2Int;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int val = vector2Int[(int)vector2Param];
                int newValue = Mathf.Clamp(EditorGUILayout.IntField(label, val), range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    vector2Int[(int)vector2Param] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3Int DrawIntFromVector3Int(GUIContent label, Vector3Int vector3Int, Vector3Param vector3Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector3Int;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int val = vector3Int[(int)vector3Param];
                int newValue = Mathf.Clamp(EditorGUILayout.IntField(label, val), range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    vector3Int[(int)vector3Param] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal BoundsInt DrawIntBoundsField(GUIContent label, BoundsInt boundsInt, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return boundsInt;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                BoundsInt newValue = EditorGUILayout.BoundsIntField(label, boundsInt);

                if (EditorGUI.EndChangeCheck())
                {
                    boundsInt = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal RectInt DrawIntRectField(GUIContent label, RectInt rectInt, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return rectInt;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                RectInt newValue = EditorGUILayout.RectIntField(label, rectInt);

                if (EditorGUI.EndChangeCheck())
                {
                    rectInt = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}