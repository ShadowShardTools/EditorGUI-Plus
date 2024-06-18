using System;
using UnityEditor;

namespace EditorGUIPlus.Scopes
{
    public sealed class IntendedDisabledScope : IDisposable
    {
        private readonly int _indentLevel;

        public IntendedDisabledScope(int indentLevel, bool isDisabled)
        {
            _indentLevel = indentLevel;
            EditorGUI.indentLevel += _indentLevel;
            EditorGUI.BeginDisabledGroup(isDisabled);
        }

        public void Dispose()
        {
            EditorGUI.EndDisabledGroup();
            EditorGUI.indentLevel -= _indentLevel;
        }
    }
}