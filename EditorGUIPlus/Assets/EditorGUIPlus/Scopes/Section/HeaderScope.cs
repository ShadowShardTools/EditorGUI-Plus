using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.Scopes.Section
{
    public class HeaderScope : GUI.Scope
    {
        private const float IndentMargin = 15.0f;
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
            oldIndentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = subHeader ? 1 : 0;
            #endif

            if (!subHeader)
                DrawSplitter();
            GUILayout.BeginVertical();

            bool saveChangeState = GUI.changed;
            Expanded = subHeader
                ? DrawSubHeaderFoldout(section.Label, beforeExpanded, false)
                : DrawHeaderFoldout(section.Label, beforeExpanded);
            if (Expanded != beforeExpanded)
            {
                section.IsExpanded = Expanded;
                saveChangeState = true;
            }

            GUI.changed = saveChangeState;
        }

        protected override void CloseScope()
        {
            if (Expanded && _spaceAtEnd && (Event.current.type == EventType.Repaint || Event.current.type == EventType.Layout))
                EditorGUILayout.Space();

#if !UNITY_2020_1_OR_NEWER
            EditorGUI.indentLevel = oldIndentLevel;
#endif
            GUILayout.EndVertical();
        }

        private static bool DrawHeaderFoldout(GUIContent title, bool state, bool isBoxed = false, 
            Func<bool> hasMoreOptions = null, Action toggleMoreOptions = null, string documentationURL = "", 
            Action<Vector2> contextAction = null)
        {
            const float height = 17f;
            Rect backgroundRect = GUILayoutUtility.GetRect(1f, height);
            if (backgroundRect.xMin != 0) // Fix for material editor
                backgroundRect.xMin = 1 + 15f * (EditorGUI.indentLevel + 1);
            float xMin = backgroundRect.xMin;

            Rect labelRect = backgroundRect;
            labelRect.xMin += 16f;
            labelRect.xMax -= 20f;

            Rect foldoutRect = backgroundRect;
            foldoutRect.y += 1f;
            foldoutRect.width = 13f;
            foldoutRect.height = 13f;
            foldoutRect.x = labelRect.xMin + IndentMargin * (EditorGUI.indentLevel - 1); //fix for presset

            // Background rect should be full-width
            backgroundRect = ToFullWidth(backgroundRect);

            if (isBoxed)
            {
                labelRect.xMin += 5;
                foldoutRect.xMin += 5;
                backgroundRect.xMin = Mathf.Approximately(xMin, 7.0f) ? 4.0f : EditorGUIUtility.singleLineHeight;
                backgroundRect.width -= 1;
            }

            DrawBackground(backgroundRect);

            // Title
            EditorGUI.LabelField(labelRect, title, EditorStyles.boldLabel);

            // Active checkbox
            state = GUI.Toggle(foldoutRect, state, GUIContent.none, EditorStyles.foldout);

            // Context menu
            Rect menuRect = new Rect(labelRect.xMax + 3f, labelRect.y + 1f, 16, 16);

            // Add context menu for "Additional Properties"
            if (contextAction == null && hasMoreOptions != null)
            {
                contextAction = pos => OnContextClick(pos, hasMoreOptions, toggleMoreOptions);
            }

            if (contextAction != null)
            {
                if (GUI.Button(menuRect, EditorGUIUtility.IconContent("_Menu")))
                    contextAction(new Vector2(menuRect.x, menuRect.yMax));
            }

            // Documentation button
            ShowHelpButton(menuRect, documentationURL, title);

            Event e = Event.current;

            if (e.type != EventType.MouseDown) 
                return state;
            
            if (!backgroundRect.Contains(e.mousePosition)) 
                return state;
                
            if (e.button != 0 && contextAction != null)
                contextAction(e.mousePosition);
            else if (e.button == 0)
            {
                state = !state;
                e.Use();
            }

            e.Use();

            return state;
        }

        private static bool DrawSubHeaderFoldout(GUIContent title, bool state, bool isBoxed = false)
        {
            const float height = 17f;
            Rect backgroundRect = GUILayoutUtility.GetRect(1f, height);

            Rect labelRect = backgroundRect;
            labelRect.xMin += 16f;
            labelRect.xMax -= 20f;

            Rect foldoutRect = backgroundRect;
            foldoutRect.y += 1f;
            foldoutRect.x += IndentMargin * EditorGUI.indentLevel; //GUI do not handle indent. Handle it here
            foldoutRect.width = 13f;
            foldoutRect.height = 13f;

            // Background rect should be full-width
            backgroundRect = ToFullWidth(backgroundRect);

            if (isBoxed)
            {
                labelRect.xMin += 5;
                foldoutRect.xMin += 5;
                backgroundRect.xMin = EditorGUIUtility.singleLineHeight;
                backgroundRect.width -= 3;
            }

            // Title
            EditorGUI.LabelField(labelRect, title, EditorStyles.boldLabel);

            // Active checkbox
            state = GUI.Toggle(foldoutRect, state, GUIContent.none, EditorStyles.foldout);

            Event e = Event.current;
            if (e.type != EventType.MouseDown || !backgroundRect.Contains(e.mousePosition) || e.button != 0)
                return state;
            state = !state;
            e.Use();

            return state;
        }

        private static void DrawSplitter(bool isBoxed = false)
        {
            Rect rect = GUILayoutUtility.GetRect(1f, 1f);
            float xMin = rect.xMin;

            // Splitter rect should be full-width
            rect = ToFullWidth(rect);

            if (isBoxed)
            {
                rect.xMin = Mathf.Approximately(xMin, 7.0f) ? 4.0f : EditorGUIUtility.singleLineHeight;
                rect.width -= 1;
            }

            if (Event.current.type != EventType.Repaint)
                return;

            EditorGUI.DrawRect(rect, !EditorGUIUtility.isProSkin
                ? new Color(0.6f, 0.6f, 0.6f, 1.333f)
                : new Color(0.12f, 0.12f, 0.12f, 1.333f));
        }

        private static void OnContextClick(Vector2 position, Func<bool> hasMoreOptions, Action toggleMoreOptions)
        {
            GenericMenu menu = new GenericMenu();

            menu.AddItem(EditorGUIUtility.TrTextContent("Show Additional Properties"), hasMoreOptions.Invoke(), toggleMoreOptions.Invoke);

            menu.DropDown(new Rect(position, Vector2.zero));
        }

        private static void ShowHelpButton(Rect contextMenuRect, string documentationURL, GUIContent title)
        {
            if (string.IsNullOrEmpty(documentationURL))
                return;

            Rect documentationRect = contextMenuRect;
            documentationRect.x -= 16 + 2;

            GUIContent documentationIcon = EditorGUIUtility.TrIconContent("_Help", $"Open Reference for {title.text}.");

            if (GUI.Button(documentationRect, documentationIcon))
                Help.BrowseURL(documentationURL);
        }
        
        private static void DrawBackground(Rect backgroundRect)
        {
            // Background
            float backgroundTint = EditorGUIUtility.isProSkin ? 0.1f : 1f;
            EditorGUI.DrawRect(backgroundRect, new Color(backgroundTint, backgroundTint, backgroundTint, 0.2f));
        }
        
        private static Rect ToFullWidth(Rect rect)
        {
            rect.xMin = 0f;
            rect.width += 4f;
            return rect;
        }
    }
}