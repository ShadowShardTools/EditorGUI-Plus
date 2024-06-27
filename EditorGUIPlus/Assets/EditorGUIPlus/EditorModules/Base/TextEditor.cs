using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.Base
{
    internal sealed class TextEditor
    {
        private readonly GroupEditor _groupEditor;

        internal TextEditor(GroupEditor groupEditor) =>
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
        
        internal string DrawTextField(GUIContent label, string text, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return text;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                string newValue = EditorGUILayout.TextField(label, text);

                if (EditorGUI.EndChangeCheck())
                {
                    text = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal string DrawTextArea(GUIContent label, string text, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return text;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                if(!string.IsNullOrEmpty(label.text))
                    EditorGUILayout.PrefixLabel(label);
                
                string newValue = EditorGUILayout.TextArea(text);

                if (EditorGUI.EndChangeCheck())
                {
                    text = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal string DrawPasswordField(GUIContent label, string password, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return password;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                string newValue = EditorGUILayout.PasswordField(label, password);

                if (EditorGUI.EndChangeCheck())
                {
                    password = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal string DrawFolderPathField(GUIContent label, string path, string defaultDirectory, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return path;
            
            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                string tempPath = path;
                using (new GUILayout.HorizontalScope())
                {
                    const float buttonWidth = 24f;
                    const float spacing = 7f;
                    EditorGUILayout.LabelField(label, GUILayout.Width(EditorGUIUtility.labelWidth - (buttonWidth + spacing)));
                    tempPath = EditorGUILayout.TextField(tempPath);

                    if (GUILayout.Button(" ... ", GUILayout.Width(buttonWidth), GUILayout.Height(EditorGUIUtility.singleLineHeight)))
                    {
                        tempPath = SelectFolder(tempPath, defaultDirectory);
                    }
                }
            
                if (EditorGUI.EndChangeCheck())
                {
                    path = tempPath;
                    onChangedCallback?.Invoke();
                }
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