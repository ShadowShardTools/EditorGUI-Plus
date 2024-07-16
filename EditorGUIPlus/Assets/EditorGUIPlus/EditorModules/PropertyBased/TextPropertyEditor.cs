﻿using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.PropertyBased
{
    internal sealed class TextPropertyEditor
    {
        private readonly GroupEditor _groupEditor;

        internal TextPropertyEditor(GroupEditor groupEditor) =>
            _groupEditor = groupEditor;
        
        internal GUIContent DrawLabel(GUIContent label, GUIContent label2, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return label;

            void Draw()
            {
                if (string.IsNullOrEmpty(label2.text))
                    EditorGUILayout.LabelField(label);
                else
                    EditorGUILayout.LabelField(label, label2);
            }
        }
        
        internal bool DrawLinkText(GUIContent label, int indentLevel = 0)
        {
            bool pressed = false;
            _groupEditor.DrawIndented(indentLevel, Draw);
            return pressed;

            void Draw() => 
                pressed = EditorGUILayout.LinkButton(label);
        }
        
        internal bool DrawLinkText(GUIContent label, string url, int indentLevel = 0)
        {
            bool pressed = false;
            _groupEditor.DrawIndented(indentLevel, Draw);
            return pressed;

            void Draw()
            {
                pressed = EditorGUILayout.LinkButton(label);
                if(pressed)
                    Application.OpenURL(url);
            }
        }
        
        internal string DrawTextField(GUIContent label, SerializedProperty property, int indentLevel = 0,
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.stringValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                string propertyValue = property.stringValue;

                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                string newValue = EditorGUILayout.TextField(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    property.stringValue = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal string DrawTextArea(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.stringValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                string propertyValue = property.stringValue;

                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                if(!string.IsNullOrEmpty(label.text))
                    EditorGUILayout.PrefixLabel(label);
                string newValue = EditorGUILayout.TextArea(propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    property.stringValue = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal string DrawPasswordField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.stringValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                string propertyValue = property.stringValue;

                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                string newValue = EditorGUILayout.PasswordField(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    property.stringValue = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal string DrawFolderPathField(GUIContent label, SerializedProperty property, string defaultDirectory, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, () => 
                DrawPathField(property, label, defaultDirectory, onChangedCallback));
            
            return property.stringValue;
        }
        
        private void DrawPathField(SerializedProperty property, GUIContent label, string defaultDirectory, 
            Action onChangedCallback)
        {
            EditorGUI.BeginChangeCheck();
            string propertyValue = property.stringValue;

            using (new GUILayout.HorizontalScope())
            {
                const float buttonWidth = 24f;
                const float spacing = 7f;
                EditorGUILayout.LabelField(label, GUILayout.Width(EditorGUIUtility.labelWidth - (buttonWidth + spacing)));
                propertyValue = EditorGUILayout.TextField(propertyValue);

                if (GUILayout.Button(" ... ", GUILayout.Width(buttonWidth), GUILayout.Height(EditorGUIUtility.singleLineHeight)))
                {
                    propertyValue = SelectFolder(propertyValue, defaultDirectory);
                }
            }

            if (EditorGUI.EndChangeCheck())
            {
                property.stringValue = propertyValue;
                property.serializedObject.ApplyModifiedProperties();
                onChangedCallback?.Invoke();
            }
        }

        private string SelectFolder(string currentPath, string defaultDirectory)
        {
            if (!AssetDatabase.IsValidFolder(currentPath))
            {
                currentPath = defaultDirectory;
            }

            string chosenDirectory = EditorUtility.SaveFolderPanel("Choose folder to save", defaultDirectory, defaultDirectory);
            return !string.IsNullOrEmpty(chosenDirectory) ? chosenDirectory : currentPath;
        }
    }
}