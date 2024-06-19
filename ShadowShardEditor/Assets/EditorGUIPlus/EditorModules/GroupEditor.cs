﻿using System;
using EditorGUIPlus.Scopes;
using EditorGUIPlus.Scopes.Section;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules
{
    internal sealed class GroupEditor
    {
        internal EditorGUILayout.HorizontalScope HorizontalScope(GUIStyle style = null, params GUILayoutOption[] options) =>
            style != null 
                ? new EditorGUILayout.HorizontalScope(style, options)
                : new EditorGUILayout.HorizontalScope(options);
        
        internal EditorGUILayout.VerticalScope VerticalScope(GUIStyle style = null, params GUILayoutOption[] options) =>
            style != null 
                ? new EditorGUILayout.VerticalScope(style, options)
                : new EditorGUILayout.VerticalScope(options);
        
        internal ScrollableScope ScrollViewScope(ref Vector2 scrollPosition, params GUILayoutOption[] options) =>
            new(ref scrollPosition, options);
        
        internal EditorGUILayout.ToggleGroupScope ToggleGroupScope(GUIContent label, ref bool toggle) =>
            new(label, toggle);
        
        internal EditorGUILayout.FadeGroupScope FadeGroupScope(float value) =>
            new(value);
        
        internal HeaderScope HeaderScope(ISection section, bool spaceAtEnd = true, bool subHeader = false) =>
            new(section, spaceAtEnd, subHeader);
        
        internal IntendedScope IntendedScope(int indentLevel) =>
            new(indentLevel);
        
        internal DisabledScope DisabledScope(bool isDisabled) =>
            new(isDisabled);
        
        internal IntendedDisabledScope IndentedDisabledScope(int indentLevel, bool isDisabled) =>
            new(indentLevel, isDisabled);
        
        internal GroupScope GroupScope(GUIContent label, bool isDisabled) =>
            new(label, isDisabled);
        
        internal BuildTargetSelectionScope BuildTargetSelectionScope() => new();
        
        internal void DrawScrollView(Action drawCall, ref Vector2 scrollPosition, params GUILayoutOption[] options)
        {
            using EditorGUILayout.ScrollViewScope scrollViewScope = new(scrollPosition, options);
            scrollPosition = scrollViewScope.scrollPosition;
            drawCall.Invoke();
        }
        
        internal void DrawVertical(GUIStyle styles, Action drawCall)
        {
            EditorGUILayout.BeginVertical(styles);
            drawCall.Invoke();
            EditorGUILayout.EndVertical();
        }
        
        internal void DrawIndented(int indentLevel, Action drawCall)
        {
            EditorGUI.indentLevel += indentLevel;
            drawCall.Invoke();
            EditorGUI.indentLevel -= indentLevel;
        }
        
        internal void DrawDisabled(bool isDisabled, Action drawCall)
        {
            EditorGUI.BeginDisabledGroup(isDisabled);
            drawCall.Invoke();
            EditorGUI.EndDisabledGroup();
        }

        internal void DrawIndentedDisabled(int indentLevel, bool isDisabled, Action drawCall)
        {
            DrawDisabled(isDisabled, Draw);
            return;

            void Draw() => 
                DrawIndented(indentLevel, drawCall);
        }
        
        internal void DrawGroup(bool isDisabled, Action drawCall)
        {
            DrawVertical(EditorStyles.helpBox, Draw);
            return;

            void Draw() => 
                DrawDisabled(isDisabled, drawCall);
        }
        
        internal void DrawGroup(GUIContent label, bool isDisabled, Action drawCall)
        {
            DrawVertical(EditorStyles.helpBox, Draw);
            return;

            void Draw()
            {
                EditorGUILayout.LabelField(label, EditorStyles.boldLabel);
                DrawDisabled(isDisabled, drawCall);
            }
        }
    }
}