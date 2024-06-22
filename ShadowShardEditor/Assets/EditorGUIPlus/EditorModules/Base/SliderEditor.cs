using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.Base
{
    internal sealed class SliderEditor
    {
        private readonly GroupEditor _groupEditor;

        internal SliderEditor(GroupEditor groupEditor)
        {
            _groupEditor = groupEditor;
        }

        internal float DrawSlider(GUIContent label, ref float sliderValue, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            float tempSliderValue = sliderValue;
            _groupEditor.DrawIndented(indentLevel, Draw);
            sliderValue = tempSliderValue;
            
            return sliderValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                float newValue = EditorGUILayout.Slider(label, tempSliderValue, range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    tempSliderValue = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }

        internal Vector3 DrawFromVector3ParamSlider(GUIContent label, ref Vector3 vector3, Vector3Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            Vector3 tempVector3 = vector3;
            _groupEditor.DrawIndented(indentLevel, Draw);
            vector3 = tempVector3;
            
            return vector3;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                float channelValue = tempVector3[(int)vectorParam];
                float newValue = EditorGUILayout.Slider(label, channelValue, range.Min, range.Max);

                if(EditorGUI.EndChangeCheck())
                {
                    tempVector3[(int)vectorParam] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, ref Vector3 property, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            DrawFromVector3ParamSlider(labelX, ref property, Vector3Param.X, range, indentLevel, onChangedCallback);
            DrawFromVector3ParamSlider(labelY, ref property, Vector3Param.Y, range, indentLevel, onChangedCallback);
            DrawFromVector3ParamSlider(labelZ, ref property, Vector3Param.Z, range, indentLevel, onChangedCallback);
        }
        
        internal FloatRange DrawMinMaxSlider(GUIContent label, ref float minProperty, ref float maxProperty, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            float minPropertyTemp = minProperty;
            float maxPropertyTemp = maxProperty;
            _groupEditor.DrawIndented(indentLevel, Draw);
            minProperty = minPropertyTemp;
            maxProperty = maxPropertyTemp;
            
            return new FloatRange(minProperty, maxProperty);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.MinMaxSlider(label, ref minPropertyTemp, ref maxPropertyTemp, range.Min, range.Max);
                
                if (EditorGUI.EndChangeCheck()) 
                    onChangedCallback?.Invoke();
            }
        }
        
        internal FloatRange DrawMinMaxVector4StartSlider(GUIContent label, ref Vector4 vector4, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            Vector4 tempVector4 = vector4;
            _groupEditor.DrawIndented(indentLevel, Draw);
            vector4 = tempVector4;
            
            return new FloatRange(vector4.x, vector4.y);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.MinMaxSlider(label, ref tempVector4.x, ref tempVector4.y, range.Min, range.Max);

                if (EditorGUI.EndChangeCheck()) 
                    onChangedCallback?.Invoke();
            }
        }

        internal FloatRange DrawMinMaxVector4EndSlider(GUIContent label, ref Vector4 vector4, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            Vector4 tempVector4 = vector4;
            _groupEditor.DrawIndented(indentLevel, Draw);
            vector4 = tempVector4;
            
            return new FloatRange(vector4.z, vector4.w);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.MinMaxSlider(label, ref tempVector4.z, ref tempVector4.w, range.Min, range.Max);

                if (EditorGUI.EndChangeCheck()) 
                    onChangedCallback?.Invoke();
            }
        }
    }
}