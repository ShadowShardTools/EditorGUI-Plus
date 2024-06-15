using System;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

namespace ShadowShard.Editor.Section
{
    public class HeaderScope : IDisposable
    {
        public readonly bool Expanded;

        private readonly bool _spaceAtEnd;
#if !UNITY_2020_1_OR_NEWER
        private int oldIndentLevel;
#endif

        public HeaderScope(ISection section, bool spaceAtEnd = true, bool subHeader = false)
        {
            if (section.Label == null)
                throw new ArgumentNullException(nameof(section.Label));

            bool beforeExpanded = section.IsExpanded;

            _spaceAtEnd = spaceAtEnd;
            #if !UNITY_2020_1_OR_NEWER
            int oldIndentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = subHeader ? 1 : 0;
            #endif

            if (!subHeader)
                CoreEditorUtils.DrawSplitter();
            GUILayout.BeginVertical();

            bool saveChangeState = GUI.changed;
            Expanded = subHeader
                ? CoreEditorUtils.DrawSubHeaderFoldout(section.Label, beforeExpanded, false)
                : CoreEditorUtils.DrawHeaderFoldout(section.Label, beforeExpanded);
            if (Expanded != beforeExpanded)
            {
                section.IsExpanded = Expanded;
                saveChangeState = true;
            }

            GUI.changed = saveChangeState;
        }

        void IDisposable.Dispose()
        {
            if (Expanded && _spaceAtEnd &&
                (Event.current.type == EventType.Repaint || Event.current.type == EventType.Layout))
                EditorGUILayout.Space();

#if !UNITY_2020_1_OR_NEWER
            EditorGUI.indentLevel = oldIndentLevel;
#endif
            GUILayout.EndVertical();
        }
    }
}