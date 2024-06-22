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
        
        internal int DrawInt(GUIContent label, ref int property, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            int tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;
            
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int newValue = Mathf.Clamp(EditorGUILayout.IntField(label, tempProperty), range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal long DrawLong(GUIContent label, ref long property, LongRange range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            long tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;
            
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                long newValue = Math.Clamp(EditorGUILayout.LongField(label, tempProperty), range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }

        internal Vector2Int DrawVector2Int(GUIContent label, ref Vector2Int property, Vector2IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            Vector2Int tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;
            
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector2Int newValue = EditorGUILayout.Vector2IntField(label, tempProperty).ClampInt(range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3Int DrawVector3Int(GUIContent label, ref Vector3Int property, Vector3IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            Vector3Int tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;
            
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector3Int newValue = EditorGUILayout.Vector3IntField(label, tempProperty).ClampInt(range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector2Int DrawIntFromVector2Int(GUIContent label, ref Vector2Int property, Vector2Param vector2Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            Vector2Int tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;
            
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int val = tempProperty[(int)vector2Param];
                int newValue = Mathf.Clamp(EditorGUILayout.IntField(label, val), range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty[(int)vector2Param] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3Int DrawIntFromVector3Int(GUIContent label, ref Vector3Int property, Vector3Param vector3Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            Vector3Int tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;
            
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int val = tempProperty[(int)vector3Param];
                int newValue = Mathf.Clamp(EditorGUILayout.IntField(label, val), range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty[(int)vector3Param] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal BoundsInt DrawIntBoundsField(GUIContent label, ref BoundsInt property, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            BoundsInt tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;
            
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                BoundsInt newValue = EditorGUILayout.BoundsIntField(label, tempProperty);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal RectInt DrawIntRectField(GUIContent label, ref RectInt property, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            RectInt tempProperty = property;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!property.Equals(tempProperty)) 
                property = tempProperty;
            
            return property;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                RectInt newValue = EditorGUILayout.RectIntField(label, tempProperty);

                if (EditorGUI.EndChangeCheck())
                {
                    tempProperty = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}