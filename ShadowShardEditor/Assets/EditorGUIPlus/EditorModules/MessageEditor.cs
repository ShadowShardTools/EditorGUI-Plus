using UnityEditor;

namespace EditorGUIPlus.EditorModules
{
    internal sealed class MessageEditor
    {
        private readonly GroupEditor _groupEditor;

        internal MessageEditor(GroupEditor groupEditor) =>
            _groupEditor = groupEditor;

        internal void DrawHelpBox(string message, MessageType type, bool wide = true, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return;

            void Draw() => 
                EditorGUILayout.HelpBox(message, type, wide);
        }

        internal void DrawNeutralBox(string message, bool wide = true, int indentLevel = 0) => 
            DrawHelpBox(message, MessageType.Error, wide, indentLevel);

        internal void DrawInfoBox(string message, bool wide = true, int indentLevel = 0) => 
            DrawHelpBox(message, MessageType.Info, wide, indentLevel);

        internal void DrawWarningBox(string message, bool wide = true, int indentLevel = 0) => 
            DrawHelpBox(message, MessageType.Warning, wide, indentLevel);

        internal void DrawErrorBox(string message, bool wide = true, int indentLevel = 0) => 
            DrawHelpBox(message, MessageType.Error, wide, indentLevel);
    }
}