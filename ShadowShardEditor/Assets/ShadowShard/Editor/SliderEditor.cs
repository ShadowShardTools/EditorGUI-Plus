﻿using ShadowShard.Editor.Enums;
using ShadowShard.Editor.Range;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    internal class SliderEditor
    {
        private readonly PropertyService _propertyService;
        private readonly GroupEditor _groupEditor;

        internal SliderEditor(PropertyService propertyService, GroupEditor groupEditor)
        {
            _propertyService = propertyService;
            _groupEditor = groupEditor;
        }

        internal float DrawSlider<TProperty>(GUIContent label, TProperty property, FloatRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetFloat(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                float propertyValue = _propertyService.GetFloat(property);
                float newValue = EditorGUILayout.Slider(label, propertyValue, range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    _propertyService.SetFloat(property, newValue);
            }
        }
        
        internal int DrawIntSlider<TProperty>(GUIContent label, TProperty property, IntRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetInt(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                int propertyValue = _propertyService.GetInt(property);
                int newValue = EditorGUILayout.IntSlider(label, propertyValue, range.Min, range.Max);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                    _propertyService.SetInt(property, newValue);
            }
        }

        internal void DrawFromVector3ParamSlider<TProperty>(GUIContent label, TProperty property, Vector3Param vectorParam, FloatRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector3 propertyValue = _propertyService.GetVector3(property);
                float channelValue = propertyValue[(int)vectorParam];
                float newValue = EditorGUILayout.Slider(label, channelValue, range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if(EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vectorParam] = newValue;
                    _propertyService.SetVector3(property, propertyValue);
                }
            }
        }
        
        internal void DrawVector3Sliders<TProperty>(GUIContent labelX, GUIContent labelY, GUIContent labelZ, TProperty property, FloatRange range, int indentLevel = 0)
        {
            DrawFromVector3ParamSlider(labelX, property, Vector3Param.X, range, indentLevel);
            DrawFromVector3ParamSlider(labelY, property, Vector3Param.Y, range, indentLevel);
            DrawFromVector3ParamSlider(labelZ, property, Vector3Param.Z, range, indentLevel);
        }
        
        internal FloatRange DrawMinMaxSlider<TProperty>(GUIContent label, TProperty minProperty, TProperty maxProperty, FloatRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return new FloatRange(_propertyService.GetFloat(minProperty), _propertyService.GetFloat(maxProperty));

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                float minValue = _propertyService.GetFloat(minProperty);
                float maxValue = _propertyService.GetFloat(maxProperty);
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(minProperty) || _propertyService.HasMixedValue(maxProperty);
                EditorGUILayout.MinMaxSlider(label, ref minValue, ref maxValue, range.Min, range.Max);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetFloat(minProperty, minValue);
                    _propertyService.SetFloat(maxProperty, maxValue);
                }
            }
        }
        
        internal FloatRange DrawMinMaxVector4StartSlider<TProperty>(GUIContent label, TProperty property, FloatRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return new FloatRange(_propertyService.GetVector4(property).x, _propertyService.GetVector4(property).y);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyValue = _propertyService.GetVector4(property);
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                EditorGUILayout.MinMaxSlider(label, ref propertyValue.x, ref propertyValue.y, range.Min, range.Max);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck()) 
                    _propertyService.SetVector4(property, propertyValue);
            }
        }
        
        internal FloatRange DrawMinMaxVector4StartSlider<TProperty>(GUIContent label, TProperty property, int indentLevel = 0) =>
            DrawMinMaxVector4StartSlider(label, property, FloatRange.Normalized, indentLevel);

        internal FloatRange DrawMinMaxVector4EndSlider<TProperty>(GUIContent label, TProperty property, FloatRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return new FloatRange(_propertyService.GetVector4(property).z, _propertyService.GetVector4(property).w);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyValue = _propertyService.GetVector4(property);
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                EditorGUILayout.MinMaxSlider(label, ref propertyValue.z, ref propertyValue.w, range.Min, range.Max);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck()) 
                    _propertyService.SetVector4(property, propertyValue);
            }
        }
        
        internal FloatRange DrawMinMaxVector4EndSlider<TProperty>(GUIContent label, TProperty property, int indentLevel = 0) =>
            DrawMinMaxVector4EndSlider(label, property, FloatRange.Normalized, indentLevel);
    }
}