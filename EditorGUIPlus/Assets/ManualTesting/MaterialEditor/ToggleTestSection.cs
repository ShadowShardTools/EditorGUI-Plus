using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using EditorGUIPlus.MaterialEditor;
using EditorGUIPlus.MaterialEditor.ShaderGUI;
using UnityEditor;
using UnityEngine;

namespace ManualTesting.MaterialEditor
{
    public class ToggleTestSection : MaterialSection
    {
        protected Property ToggleValue = new("_ToggleValue");
        protected Property ShaderKeywordToggle = new("_ShaderKeywordToggle");

        private readonly GUIContent _toggleLabel = new("Toggle Test");

        public ToggleTestSection() : base(new GUIContent("Test Label"))
        {
        }

        public override void FindProperties(MaterialProperty[] properties)
        {
            ToggleValue.Find(properties);
            ShaderKeywordToggle.Find(properties);
        }

        public override void DrawProperties(MaterialEditorGUIPlus editor)
        {
            editor.DrawToggle(_toggleLabel, ToggleValue.MaterialProperty, 1);
            editor.DrawShaderGlobalKeywordToggle(_toggleLabel, ToggleValue.MaterialProperty, "_TEST_KEYWORD", 1);
        }

        public override void SetKeywords(Material material)
        {
        }
    }
}