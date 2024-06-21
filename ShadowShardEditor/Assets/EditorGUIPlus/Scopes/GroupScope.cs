using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.Scopes
{
    public sealed class GroupScope : GUI.Scope
    {
        public GroupScope(GUIContent label, bool isDisabled)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField(label, EditorStyles.boldLabel);
            EditorGUI.BeginDisabledGroup(isDisabled);
        }

        protected override void CloseScope()
        {
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndVertical();
        }
    }
}