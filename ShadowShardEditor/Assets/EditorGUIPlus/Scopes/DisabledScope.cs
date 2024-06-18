using System;
using UnityEditor;

namespace EditorGUIPlus.Scopes
{
    public sealed class DisabledScope : IDisposable
    {
        public DisabledScope(bool isDisabled)
        {
            EditorGUI.BeginDisabledGroup(isDisabled);
        }

        public void Dispose() =>
            EditorGUI.EndDisabledGroup();
    }
}