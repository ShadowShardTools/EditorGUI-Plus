using System;
using UnityEditor;

namespace EditorGUIPlus.Scopes
{
    public sealed class IntendedScope : IDisposable
    {
        private readonly int _indentLevel;

        public IntendedScope(int indentLevel)
        {
            _indentLevel = indentLevel;
            EditorGUI.indentLevel += indentLevel;
        }

        public void Dispose() =>
            EditorGUI.indentLevel -= _indentLevel;
    }
}