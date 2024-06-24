using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.Base
{
    internal sealed class ColorEditor
    {
        private readonly GroupEditor _groupEditor;

        internal ColorEditor(GroupEditor groupEditor)
        {
            _groupEditor = groupEditor;
        }
        
        internal Color DrawColor(GUIContent label, Color color, bool showAlpha = true,
            bool hdr = false, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
    
            return color;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Color newValue = EditorGUILayout.ColorField(label, color, true, showAlpha, hdr);

                if (EditorGUI.EndChangeCheck())
                {
                    color = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Gradient DrawGradient(GUIContent label, Gradient gradient, bool hdr = false, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            
            return gradient;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Gradient newValue = EditorGUILayout.GradientField(label, gradient, hdr);
                
                if (EditorGUI.EndChangeCheck())
                {
                    gradient = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}