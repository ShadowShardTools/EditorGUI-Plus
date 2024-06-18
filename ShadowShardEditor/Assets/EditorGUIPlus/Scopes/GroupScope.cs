using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.Scopes
{
    public sealed class GroupScope : IDisposable
    {
        public GroupScope(GUIContent label, bool isDisabled)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField(label, EditorStyles.boldLabel);
            EditorGUI.BeginDisabledGroup(isDisabled);
        }

        public void Dispose()
        {
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndVertical();
        }
    }
}