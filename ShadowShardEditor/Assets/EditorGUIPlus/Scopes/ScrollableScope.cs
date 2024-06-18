using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.Scopes
{
    public sealed class ScrollableScope : IDisposable
    {
        public ScrollableScope(ref Vector2 scrollPosition, params GUILayoutOption[] options)
        {
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, options);
        }

        public void Dispose() =>
            EditorGUILayout.EndScrollView();
    }
}