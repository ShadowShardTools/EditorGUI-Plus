using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using EditorGUIPlus.MaterialEditor;
using EditorGUIPlus.MaterialEditor.ShaderGUI;
using UnityEditor;
using UnityEngine;

namespace ManualTesting.MaterialEditor
{
    public class IntSlidersTestSection : MaterialSection
    {
        protected ShaderProperty Color = new("_Color");
        protected ShaderProperty BaseMap = new("_BaseMap");
        protected ShaderProperty IntValue = new("_IntValue");
        protected ShaderProperty VectorValue = new("_VectorValue");
        protected ShaderProperty ToggleValue = new("_ToggleValue");
        protected ShaderProperty EnumValue = new("_EnumValue");
        protected ShaderProperty ShaderKeywordToggle = new("_ShaderKeywordToggle");

        private readonly GUIContent _colorLabel = new("Color Test");
        private readonly GUIContent _floatLabel = new("Float Test");
        private readonly GUIContent _vectorLabel = new("Vector Test");
        private readonly IntRange _testIntRange = new(0, 10);

        public IntSlidersTestSection() : base(new GUIContent("Test Label"))
        {
        }

        public override void FindProperties(MaterialProperty[] properties)
        {
            Color.Find(properties);
            BaseMap.Find(properties);
            IntValue.Find(properties);
            VectorValue.Find(properties);
            ToggleValue.Find(properties);
            EnumValue.Find(properties);
            ShaderKeywordToggle.Find(properties);
        }

        public override void DrawProperties(MaterialEditorGUIPlus editor)
        {
            editor.DrawIntSlider(_floatLabel, IntValue.MaterialProperty, _testIntRange, 1);
            editor.DrawIntSlider(_floatLabel, IntValue.MaterialProperty, 1);
            editor.DrawFromVector3IntParamSlider(_vectorLabel, VectorValue.MaterialProperty, Vector3Param.X, _testIntRange, 1);
            editor.DrawFromVector3IntParamSlider(_vectorLabel, VectorValue.MaterialProperty, Vector3Param.Y, 1);
            editor.DrawVector3IntSliders(_vectorLabel, _vectorLabel, _vectorLabel, VectorValue.MaterialProperty, _testIntRange, 1);
            editor.DrawVector3IntSliders(_vectorLabel, _vectorLabel, _vectorLabel, VectorValue.MaterialProperty, 1);
        }

        public override void SetKeywords(Material material)
        {
        }
    }
}