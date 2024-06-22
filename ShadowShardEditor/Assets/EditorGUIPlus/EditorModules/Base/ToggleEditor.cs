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
        
        internal bool DrawToggle(GUIContent label, ref bool toggle, 
            ToggleAlign toggleAlign = ToggleAlign.Right, int indentLevel = 0, Action onChangedCallback = null)
        {
            bool tempToggle = toggle;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!toggle.Equals(tempToggle)) 
                toggle = tempToggle;
            
            return toggle;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                bool isRightAlign = toggleAlign == ToggleAlign.Right;
                bool newValue = isRightAlign ? 
                    EditorGUILayout.Toggle(label, tempToggle) : 
                    EditorGUILayout.ToggleLeft(label, tempToggle);

                if (EditorGUI.EndChangeCheck())
                {
                    tempToggle = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, ref bool toggle, 
            string shaderLocalKeyword, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            bool tempToggle = toggle;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!toggle.Equals(tempToggle)) 
                toggle = tempToggle;
            
            return toggle;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                bool isRightAlign = toggleAlign == ToggleAlign.Right;
                bool newValue = isRightAlign ? 
                    EditorGUILayout.Toggle(label, tempToggle) : 
                    EditorGUILayout.ToggleLeft(label, tempToggle);

                if (EditorGUI.EndChangeCheck())
                {
                    tempToggle = newValue;
                    KeywordsService.SetKeyword(material, shaderLocalKeyword, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal bool DrawShaderGlobalKeywordToggle(GUIContent label, ref bool toggle, 
            string shaderGlobalKeyword, ToggleAlign toggleAlign = ToggleAlign.Right,
            int indentLevel = 0, Action onChangedCallback = null)
        {
            bool tempToggle = toggle;
            _groupEditor.DrawIndented(indentLevel, Draw);
            if(!toggle.Equals(tempToggle)) 
                toggle = tempToggle;
            
            return toggle;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                bool isRightAlign = toggleAlign == ToggleAlign.Right;
                bool newValue = isRightAlign ? 
                    EditorGUILayout.Toggle(label, tempToggle) : 
                    EditorGUILayout.ToggleLeft(label, tempToggle);
                
                if (EditorGUI.EndChangeCheck())
                {
                    tempToggle = newValue;
                    KeywordsService.SetGlobalKeyword(shaderGlobalKeyword, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}