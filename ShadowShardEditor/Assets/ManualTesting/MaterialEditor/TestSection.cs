using EditorGUIPlus;
using EditorGUIPlus.MaterialEditor;
using EditorGUIPlus.MaterialEditor.ShaderGUI;
using UnityEditor;
using UnityEngine;

namespace ManualTesting.MaterialEditor
{
    public class TestSection : MaterialSection
    {
        protected Property BaseMap = new("_BaseMap");
        protected Property Color = new("_Color");
        protected Property FloatValue = new("_FloatValue");
        protected Property IntValue = new("_IntValue");
        protected Property VectorValue = new("_VectorValue");
        protected Property ToggleValue = new("_ToggleValue");
        protected Property EnumValue = new("_EnumValue");
        protected Property ShaderKeywordToggle = new("_ShaderKeywordToggle");

        public TestSection() : base(new GUIContent("Test Label"))
        {
        }

        public override void FindProperties(MaterialProperty[] properties)
        {
            BaseMap.Find(properties);
            Color.Find(properties);
            FloatValue.Find(properties);
            IntValue.Find(properties);
            VectorValue.Find(properties);
            ToggleValue.Find(properties);
            EnumValue.Find(properties);
            ShaderKeywordToggle.Find(properties);
        }

        public override void DrawProperties(MaterialEditorGUIPlus editor)
        {
        }

        public override void SetKeywords(Material material)
        {
        }
    }
}