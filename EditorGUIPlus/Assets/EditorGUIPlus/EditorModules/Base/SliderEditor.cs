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

        internal float DrawSlider(GUIContent label, float sliderValue, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return sliderValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                float newValue = EditorGUILayout.Slider(label, sliderValue, range.Min, range.Max);

                if (EditorGUI.EndChangeCheck())
                {
                    sliderValue = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector2 DrawFromVector2ParamSlider(GUIContent label, Vector2 vector2, Vector2Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector2;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                float channelValue = vector2[(int)vectorParam];
                float newValue = EditorGUILayout.Slider(label, channelValue, range.Min, range.Max);

                if(EditorGUI.EndChangeCheck())
                {
                    vector2[(int)vectorParam] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }

        internal Vector3 DrawFromVector3ParamSlider(GUIContent label, Vector3 vector3, Vector3Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector3;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                float channelValue = vector3[(int)vectorParam];
                float newValue = EditorGUILayout.Slider(label, channelValue, range.Min, range.Max);

                if(EditorGUI.EndChangeCheck())
                {
                    vector3[(int)vectorParam] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawFromVector4ParamSlider(GUIContent label, Vector4 vector4, Vector4Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector4;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                float channelValue = vector4[(int)vectorParam];
                float newValue = EditorGUILayout.Slider(label, channelValue, range.Min, range.Max);

                if(EditorGUI.EndChangeCheck())
                {
                    vector4[(int)vectorParam] = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3 DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, Vector3 vector3, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            vector3 = DrawFromVector3ParamSlider(labelX, vector3, Vector3Param.X, range, indentLevel, onChangedCallback);
            vector3 = DrawFromVector3ParamSlider(labelY, vector3, Vector3Param.Y, range, indentLevel, onChangedCallback);
            vector3 = DrawFromVector3ParamSlider(labelZ, vector3, Vector3Param.Z, range, indentLevel, onChangedCallback);

            return vector3;
        }
        
        internal FloatRange DrawMinMaxSlider(GUIContent label, ref float minProperty, ref float maxProperty, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null)
        {
            float minPropertyTemp = minProperty;
            float maxPropertyTemp = maxProperty;
            _groupEditor.DrawIndented(indentLevel, Draw);
            
            if (!minProperty.Equals(minPropertyTemp) || !maxProperty.Equals(maxPropertyTemp))
            {
                minProperty = minPropertyTemp;
                maxProperty = maxPropertyTemp;
            }
            
            return new FloatRange(minProperty, maxProperty);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.MinMaxSlider(label, ref minPropertyTemp, ref maxPropertyTemp, range.Min, range.Max);
                
                if (EditorGUI.EndChangeCheck()) 
                    onChangedCallback?.Invoke();
            }
        }
        
        internal Vector4 DrawMinMaxVector4StartSlider(GUIContent label, Vector4 vector4, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector4;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.MinMaxSlider(label, ref vector4.x, ref vector4.y, range.Min, range.Max);

                if (EditorGUI.EndChangeCheck()) 
                    onChangedCallback?.Invoke();
            }
        }

        internal Vector4 DrawMinMaxVector4EndSlider(GUIContent label, Vector4 vector4, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return vector4;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.MinMaxSlider(label, ref vector4.z, ref vector4.w, range.Min, range.Max);

                if (EditorGUI.EndChangeCheck()) 
                    onChangedCallback?.Invoke();
            }
        }
    }
}