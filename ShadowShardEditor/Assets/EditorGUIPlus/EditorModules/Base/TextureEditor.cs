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

        internal Texture DrawTexture(GUIContent label, Texture texture, int indentLevel = 0, Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return texture;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                Texture newValue = EditorGUILayout.ObjectField(label, texture, typeof(Texture), false) as Texture;

                if (EditorGUI.EndChangeCheck())
                {
                    texture = newValue;
                    onChangedCallback?.Invoke();
                }
            }
        }
    }
}