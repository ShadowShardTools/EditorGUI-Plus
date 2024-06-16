using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules
{
    internal sealed class GroupEditor
    {
        internal void ScrollView(Action drawCall, ref Vector2 scrollPosition, params GUILayoutOption[] options)
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