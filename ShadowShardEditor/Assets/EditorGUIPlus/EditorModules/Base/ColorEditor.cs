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
        
        internal Color DrawColor(GUIContent label, ref Color color, bool showAlpha = true,
            bool hdr = false, int indentLevel = 0, Action onChangedCallback = null)
        {
            Color tempColor = color;
            _groupEditor.DrawIndented(indentLevel, Draw);
            color = tempColor;
    
            return color;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Color newValue = EditorGUILayout.ColorField(label, tempColor, true, showAlpha, hdr);

                if (EditorGUI.EndChangeCheck())
                {
                    tempColor = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal Gradient DrawGradient(GUIContent label, ref Gradient gradient, bool hdr = false, 
            int indentLevel = 0, Action onChangedCallback = null)
        {
            Gradient tempGradient = gradient;
            _groupEditor.DrawIndented(indentLevel, Draw);
            gradient = tempGradient;
            
            return gradient;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Gradient newValue = EditorGUILayout.GradientField(label, tempGradient, hdr);
                
                if (EditorGUI.EndChangeCheck())
                {
                    tempGradient = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}