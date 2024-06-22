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
        
        internal string DrawTextField(GUIContent label, ref string text, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            string tempText = text;
            _groupEditor.DrawIndented(indentLevel, Draw);
            text = tempText;
            
            return text;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                string newValue = EditorGUILayout.TextField(label, tempText);

                if (EditorGUI.EndChangeCheck())
                {
                    tempText = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal string DrawTextArea(GUIContent label, ref string text, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            string tempText = text;
            _groupEditor.DrawIndented(indentLevel, Draw);
            text = tempText;
            
            return text;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                if(!string.IsNullOrEmpty(label.text))
                    EditorGUILayout.PrefixLabel(label);
                
                string newValue = EditorGUILayout.TextArea(tempText);

                if (EditorGUI.EndChangeCheck())
                {
                    tempText = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal string DrawPasswordField(GUIContent label, ref string password, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            string tempPassword = password;
            _groupEditor.DrawIndented(indentLevel, Draw);
            password = tempPassword;
            
            return password;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                string newValue = EditorGUILayout.PasswordField(label, tempPassword);

                if (EditorGUI.EndChangeCheck())
                {
                    tempPassword = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal string DrawFolderPathField(GUIContent label, ref string path, string defaultDirectory, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            string tempPath = path;
            _groupEditor.DrawIndented(indentLevel, () => DrawPathField(ref tempPath, label, defaultDirectory));

            if (path != tempPath)
            {
                path = tempPath;
                onChangedCallback?.Invoke();
            }

            return path;
        }
        
        private void DrawPathField(ref string tempPath, GUIContent label, string defaultDirectory)
        {
            EditorGUI.BeginChangeCheck();

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

            EditorGUI.EndChangeCheck();
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