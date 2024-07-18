﻿using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.PropertyBased
{
    internal sealed class SliderPropertyEditor
    {
        private readonly PropertyService _propertyService;
        private readonly GroupEditor _groupEditor;

        internal SliderPropertyEditor(PropertyService propertyService, GroupEditor groupEditor)
        {
            _propertyService = propertyService;
            _groupEditor = groupEditor;
        }

        internal float DrawSlider<TProperty>(GUIContent label, TProperty property, FloatRange range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
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
                {
                    _propertyService.SetFloat(property, newValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector2 DrawFromVector2ParamSlider<TProperty>(GUIContent label, TProperty property, 
            Vector2Param vectorParam, FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector2(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector2 propertyValue = _propertyService.GetVector2(property);
                float channelValue = propertyValue[(int)vectorParam];
                float newValue = EditorGUILayout.Slider(label, channelValue, range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if(EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vectorParam] = newValue;
                    _propertyService.SetVector2(property, propertyValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }

        internal Vector3 DrawFromVector3ParamSlider<TProperty>(GUIContent label, TProperty property, 
            Vector3Param vectorParam, FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector3(property);

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
                    _propertyService.SetVector3(property, propertyValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawFromVector4ParamSlider<TProperty>(GUIContent label, TProperty property, 
            Vector4Param vectorParam, FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector4(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector4 propertyValue = _propertyService.GetVector4(property);
                float channelValue = propertyValue[(int)vectorParam];
                float newValue = EditorGUILayout.Slider(label, channelValue, range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if(EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vectorParam] = newValue;
                    _propertyService.SetVector4(property, propertyValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector2 DrawVector2Sliders<TProperty>(GUIContent labelX, GUIContent labelY, TProperty property, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            DrawFromVector2ParamSlider(labelX, property, Vector2Param.X, range, indentLevel, applyModifiedProperties, onChangedCallback);
            DrawFromVector2ParamSlider(labelY, property, Vector2Param.Y, range, indentLevel, applyModifiedProperties, onChangedCallback);

            return _propertyService.GetVector2(property);
        }
        
        internal Vector3 DrawVector3Sliders<TProperty>(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            TProperty property, FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, 
            Action onChangedCallback = null)
        {
            DrawFromVector3ParamSlider(labelX, property, Vector3Param.X, range, indentLevel, applyModifiedProperties, onChangedCallback);
            DrawFromVector3ParamSlider(labelY, property, Vector3Param.Y, range, indentLevel, applyModifiedProperties, onChangedCallback);
            DrawFromVector3ParamSlider(labelZ, property, Vector3Param.Z, range, indentLevel, applyModifiedProperties, onChangedCallback);

            return _propertyService.GetVector3(property);
        }
        
        internal FloatRange DrawMinMaxSlider<TProperty>(GUIContent label, TProperty minProperty, TProperty maxProperty, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
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
                    _propertyService.SetFloat(minProperty, minValue, applyModifiedProperties);
                    _propertyService.SetFloat(maxProperty, maxValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector4 DrawMinMaxVector4StartSlider<TProperty>(GUIContent label, TProperty property, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector4(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyValue = _propertyService.GetVector4(property);
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                EditorGUILayout.MinMaxSlider(label, ref propertyValue.x, ref propertyValue.y, range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetVector4(property, propertyValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }

        internal Vector4 DrawMinMaxVector4EndSlider<TProperty>(GUIContent label, TProperty property, FloatRange range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector4(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Vector4 propertyValue = _propertyService.GetVector4(property);
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                EditorGUILayout.MinMaxSlider(label, ref propertyValue.z, ref propertyValue.w, range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetVector4(property, propertyValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}