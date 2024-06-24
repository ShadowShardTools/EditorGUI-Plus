using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.MaterialEditor;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.Base
{
    internal sealed class ToggleEditor
    {
        private readonly GroupEditor _groupEditor;

        internal ToggleEditor(GroupEditor groupEditor)
        {
            _groupEditor = groupEditor;
        }
        
        internal bool DrawToggle(GUIContent label, bool toggle, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            
            return toggle;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                bool isRightAlign = toggleAlign == ToggleAlign.Right;
                bool newValue = isRightAlign ? 
                    EditorGUILayout.Toggle(label, toggle) : 
                    EditorGUILayout.ToggleLeft(label, toggle);

                if (EditorGUI.EndChangeCheck())
                {
                    toggle = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, bool toggle, 
            string shaderLocalKeyword, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            
            return toggle;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                bool isRightAlign = toggleAlign == ToggleAlign.Right;
                bool newValue = isRightAlign ? 
                    EditorGUILayout.Toggle(label, toggle) : 
                    EditorGUILayout.ToggleLeft(label, toggle);

                if (EditorGUI.EndChangeCheck())
                {
                    toggle = newValue;
                    KeywordsService.SetKeyword(material, shaderLocalKeyword, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal bool DrawShaderGlobalKeywordToggle(GUIContent label, bool toggle, string shaderGlobalKeyword, 
            ToggleAlign toggleAlign = ToggleAlign.Right, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            
            return toggle;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                bool isRightAlign = toggleAlign == ToggleAlign.Right;
                bool newValue = isRightAlign ? 
                    EditorGUILayout.Toggle(label, toggle) : 
                    EditorGUILayout.ToggleLeft(label, toggle);
                
                if (EditorGUI.EndChangeCheck())
                {
                    toggle = newValue;
                    KeywordsService.SetGlobalKeyword(shaderGlobalKeyword, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}