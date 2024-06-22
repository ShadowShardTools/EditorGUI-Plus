using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.Base
{
    internal sealed class TextureEditor
    {
        private readonly GroupEditor _groupEditor;

        internal TextureEditor(GroupEditor groupEditor)
        {
            _groupEditor = groupEditor;
        }

        internal Texture DrawTexture(GUIContent label, ref Texture texture, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            Texture tempTexture = texture;
            _groupEditor.DrawIndented(indentLevel, Draw);
            texture = tempTexture;
            
            return texture;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Texture newValue = EditorGUILayout.ObjectField(label, tempTexture, typeof(Texture), false) as Texture;

                if (EditorGUI.EndChangeCheck())
                {
                    tempTexture = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}