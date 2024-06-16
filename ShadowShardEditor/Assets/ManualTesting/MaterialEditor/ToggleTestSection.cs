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
        protected Property Color = new("_Color");
        protected Property BaseMap = new("_BaseMap");
        protected Property VectorValue = new("_VectorValue");
        protected Property ToggleValue = new("_ToggleValue");
        protected Property EnumValue = new("_EnumValue");
        protected Property ShaderKeywordToggle = new("_ShaderKeywordToggle");

        private readonly GUIContent _colorLabel = new("Color Test");
        private readonly GUIContent _floatLabel = new("Float Test");
        private readonly GUIContent _vectorLabel = new("Vector Test");
        private readonly GUIContent _toggleLabel = new("Toggle Test");

        public ToggleTestSection() : base(new GUIContent("Test Label"))
        {
        }

        public override void FindProperties(MaterialProperty[] properties)
        {
            Color.Find(properties);
            BaseMap.Find(properties);
            VectorValue.Find(properties);
            ToggleValue.Find(properties);
            EnumValue.Find(properties);
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