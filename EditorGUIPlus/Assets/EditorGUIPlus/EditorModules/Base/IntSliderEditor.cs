using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.Base
{
    internal sealed class IntSliderEditor
    {
        private readonly GroupEditor _groupEditor;

        internal IntSliderEditor(GroupEditor groupEditor)
        {
            _groupEditor = groupEditor;
        }
        
        internal int DrawIntSlider(GUIContent label, int sliderValue, IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return sliderValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int newValue = EditorGUILayout.IntSlider(label, sliderValue, range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    sliderValue = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector2Int DrawFromVector2IntParamSlider(GUIContent label, Vector2Int vector2Int, 
            Vector2Param vectorParam, IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector2Int;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int channelValue = vector2Int[(int)vectorParam];
                int newValue = EditorGUILayout.IntSlider(label, channelValue, range.Min, range.Max);

                if(EditorGUI.EndChangeCheck())
                {
                    vector2Int[(int)vectorParam] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3Int DrawFromVector3IntParamSlider(GUIContent label, Vector3Int vector3Int, 
            Vector3Param vectorParam, IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector3Int;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int channelValue = vector3Int[(int)vectorParam];
                int newValue = EditorGUILayout.IntSlider(label, channelValue, range.Min, range.Max);

                if(EditorGUI.EndChangeCheck())
                {
                    vector3Int[(int)vectorParam] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector2Int DrawVector2IntSliders(GUIContent labelX, GUIContent labelY, Vector2Int vector2Int, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            vector2Int = DrawFromVector2IntParamSlider(labelX, vector2Int, Vector2Param.X, range, indentLevel, onChangedCallback);
            vector2Int = DrawFromVector2IntParamSlider(labelY, vector2Int, Vector2Param.Y, range, indentLevel, onChangedCallback);
            
            return vector2Int;
        }
        
        internal Vector3Int DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            Vector3Int vector3Int, IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            vector3Int = DrawFromVector3IntParamSlider(labelX, vector3Int, Vector3Param.X, range, indentLevel, onChangedCallback);
            vector3Int = DrawFromVector3IntParamSlider(labelY, vector3Int, Vector3Param.Y, range, indentLevel, onChangedCallback);
            vector3Int = DrawFromVector3IntParamSlider(labelZ, vector3Int, Vector3Param.Z, range, indentLevel, onChangedCallback);
            
            return vector3Int;
        }
        
        internal IntRange DrawMinMaxIntSlider(GUIContent label, ref int minProperty, ref int maxProperty, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            int minPropertyTemp = minProperty;
            int maxPropertyTemp = maxProperty;
            _groupEditor.DrawIndented(indentLevel, Draw);
            
            if (!minProperty.Equals(minPropertyTemp) || !maxProperty.Equals(maxPropertyTemp))
            {
                minProperty = minPropertyTemp;
                maxProperty = maxPropertyTemp;
            }
            
            return new IntRange(minProperty, maxProperty);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                float minValue = minPropertyTemp;
                float maxValue = maxPropertyTemp;
                EditorGUILayout.MinMaxSlider(label, ref minValue, ref maxValue, range.Min, range.Max);
                
                if (EditorGUI.EndChangeCheck())
                {
                    minPropertyTemp = (int)minValue;
                    maxPropertyTemp = (int)maxValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}