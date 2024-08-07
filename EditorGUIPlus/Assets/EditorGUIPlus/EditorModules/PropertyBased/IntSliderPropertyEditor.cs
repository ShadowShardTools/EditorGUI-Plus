﻿using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.PropertyBased
{
    internal sealed class IntSliderPropertyEditor
    {
        private readonly PropertyService _propertyService;
        private readonly GroupEditor _groupEditor;

        internal IntSliderPropertyEditor(PropertyService propertyService, GroupEditor groupEditor)
        {
            _propertyService = propertyService;
            _groupEditor = groupEditor;
        }
        
        internal int DrawIntSlider<TProperty>(GUIContent label, TProperty property, IntRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null)
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
                {
                    _propertyService.SetInt(property, newValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector2Int DrawFromVector2IntParamSlider<TProperty>(GUIContent label, TProperty property, 
            Vector2Param vectorParam, IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector2Int(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector2Int propertyValue = _propertyService.GetVector2Int(property);
                int channelValue = propertyValue[(int)vectorParam];
                int newValue = EditorGUILayout.IntSlider(label, channelValue, range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if(EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vectorParam] = newValue;
                    _propertyService.SetVector2Int(property, propertyValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector3Int DrawFromVector3IntParamSlider<TProperty>(GUIContent label, TProperty property, 
            Vector3Param vectorParam, IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector3Int(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector3Int propertyValue = _propertyService.GetVector3Int(property);
                int channelValue = propertyValue[(int)vectorParam];
                int newValue = EditorGUILayout.IntSlider(label, channelValue, range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if(EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vectorParam] = newValue;
                    _propertyService.SetVector3Int(property, propertyValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Vector2Int DrawVector2IntSliders<TProperty>(GUIContent labelX, GUIContent labelY, TProperty property,
            IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            DrawFromVector2IntParamSlider(labelX, property, Vector2Param.X, range, indentLevel, applyModifiedProperties, onChangedCallback);
            DrawFromVector2IntParamSlider(labelY, property, Vector2Param.Y, range, indentLevel, applyModifiedProperties, onChangedCallback);
            
            return _propertyService.GetVector2Int(property);
        }
        
        internal Vector3Int DrawVector3IntSliders<TProperty>(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            TProperty property, IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, 
            Action onChangedCallback = null)
        {
            DrawFromVector3IntParamSlider(labelX, property, Vector3Param.X, range, indentLevel, applyModifiedProperties, onChangedCallback);
            DrawFromVector3IntParamSlider(labelY, property, Vector3Param.Y, range, indentLevel, applyModifiedProperties, onChangedCallback);
            DrawFromVector3IntParamSlider(labelZ, property, Vector3Param.Z, range, indentLevel, applyModifiedProperties, onChangedCallback);
            
            return _propertyService.GetVector3Int(property);
        }
        
        internal IntRange DrawMinMaxIntSlider<TProperty>(GUIContent label, TProperty minProperty, TProperty maxProperty, 
            IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return new IntRange(_propertyService.GetInt(minProperty), _propertyService.GetInt(maxProperty));

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                float minValue = _propertyService.GetInt(minProperty);
                float maxValue = _propertyService.GetInt(maxProperty);
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(minProperty) || _propertyService.HasMixedValue(maxProperty);
                EditorGUILayout.MinMaxSlider(label, ref minValue, ref maxValue, range.Min, range.Max);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                {
                    _propertyService.SetInt(minProperty, (int)minValue, applyModifiedProperties);
                    _propertyService.SetInt(maxProperty, (int)maxValue, applyModifiedProperties);
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}