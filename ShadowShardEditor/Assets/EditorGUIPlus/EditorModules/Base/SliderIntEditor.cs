using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.Base
{
    internal sealed class SliderIntEditor
    {
        private readonly GroupEditor _groupEditor;

        internal SliderIntEditor(GroupEditor groupEditor)
        {
            _groupEditor = groupEditor;
        }
        
        internal int DrawIntSlider(GUIContent label, ref int sliderValue, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            int tempSliderValue = sliderValue;
            _groupEditor.DrawIndented(indentLevel, Draw);
            sliderValue = tempSliderValue;
            
            return sliderValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int newValue = EditorGUILayout.IntSlider(label, tempSliderValue, range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    tempSliderValue = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3Int DrawFromVector3IntParamSlider(GUIContent label, ref Vector3Int vector3Int, 
            Vector3Param vectorParam, IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            Vector3Int tempVector3Int = vector3Int;
            _groupEditor.DrawIndented(indentLevel, Draw);
            vector3Int = tempVector3Int;
            
            return vector3Int;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                int channelValue = tempVector3Int[(int)vectorParam];
                int newValue = EditorGUILayout.IntSlider(label, channelValue, range.Min, range.Max);

                if(EditorGUI.EndChangeCheck())
                {
                    tempVector3Int[(int)vectorParam] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal void DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            ref Vector3Int property, IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            DrawFromVector3IntParamSlider(labelX, ref property, Vector3Param.X, range, indentLevel, onChangedCallback);
            DrawFromVector3IntParamSlider(labelY, ref property, Vector3Param.Y, range, indentLevel, onChangedCallback);
            DrawFromVector3IntParamSlider(labelZ, ref property, Vector3Param.Z, range, indentLevel, onChangedCallback);
        }
        
        internal IntRange DrawMinMaxIntSlider(GUIContent label, ref int minProperty, ref int maxProperty, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            int minPropertyTemp = minProperty;
            int maxPropertyTemp = maxProperty;
            _groupEditor.DrawIndented(indentLevel, Draw);
            minProperty = minPropertyTemp;
            maxProperty = maxPropertyTemp;
            
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