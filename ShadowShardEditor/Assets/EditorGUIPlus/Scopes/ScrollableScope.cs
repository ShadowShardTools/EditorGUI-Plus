using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.Scopes
{
    public sealed class ScrollableScope : GUI.Scope
    {
        public ScrollableScope(ref Vector2 scrollPosition, params GUILayoutOption[] options)
        {
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, options);
        }

        protected override void CloseScope()
        {
            EditorGUILayout.EndScrollView();
        }
    }
}