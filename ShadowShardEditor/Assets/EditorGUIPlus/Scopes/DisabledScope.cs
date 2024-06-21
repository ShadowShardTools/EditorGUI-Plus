using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.Scopes
{
    public sealed class DisabledScope : GUI.Scope
    {
        public DisabledScope(bool isDisabled)
        {
            EditorGUI.BeginDisabledGroup(isDisabled);
        }

        protected override void CloseScope()
        {
            EditorGUI.EndDisabledGroup();
        }
    }
}