﻿using System;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor.EditorModules
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
                    const float labelDelta = 16;
                    EditorGUILayout.LabelField(label, GUILayout.Width(EditorGUIUtility.labelWidth - (labelDelta)));
                    propertyValue = EditorGUILayout.TextField(propertyValue);
                    if(GUILayout.Button(" ... ", GUILayout.ExpandWidth(false), GUILayout.Height(EditorGUIUtility.singleLineHeight)))
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