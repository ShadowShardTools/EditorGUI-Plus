﻿using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules
{
    internal sealed class TextEditor
    {
        private readonly GroupEditor _groupEditor;

        internal TextEditor(GroupEditor groupEditor) =>
            _groupEditor = groupEditor;
        
        internal string DrawTextField(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)
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
        
        internal string DrawTextArea(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null)
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
        
        internal string DrawFolderPathField(GUIContent label, SerializedProperty property, string defaultDirectory, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return property.stringValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                string propertyValue = property.stringValue;

                using(new GUILayout.HorizontalScope())
                {
                    const float buttonWidth = 24f;
                    const float spacing = 7f;
                    EditorGUILayout.LabelField(label, GUILayout.Width(EditorGUIUtility.labelWidth - (buttonWidth + spacing)));
                    propertyValue = EditorGUILayout.TextField(propertyValue);
                    
                    if(GUILayout.Button(" ... ", GUILayout.Width(buttonWidth), GUILayout.Height(EditorGUIUtility.singleLineHeight)))
                    {
                        if(AssetDatabase.IsValidFolder(propertyValue))
                            propertyValue = defaultDirectory;
                    
                        string chosenDirectory = EditorUtility.SaveFolderPanel("Choose folder to save", defaultDirectory, defaultDirectory);
                    
                        if(!string.IsNullOrEmpty(chosenDirectory)) 
                            propertyValue = chosenDirectory;
                    }
                }

                if(EditorGUI.EndChangeCheck())
                {
                    property.stringValue = propertyValue;
                    property.serializedObject.ApplyModifiedProperties();
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}