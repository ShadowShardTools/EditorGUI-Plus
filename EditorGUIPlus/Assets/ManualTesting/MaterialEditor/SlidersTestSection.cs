using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using EditorGUIPlus.MaterialEditor;
using EditorGUIPlus.MaterialEditor.ShaderGUI;
using UnityEditor;
using UnityEngine;

namespace ManualTesting.MaterialEditor
{
    public class SlidersTestSection : MaterialSection
    {
        protected ShaderProperty FloatValue = new("_FloatValue");
        protected ShaderProperty FloatMinValue = new("_FloatMinValue");
        protected ShaderProperty FloatMaxValue = new("_FloatMaxValue");
        protected ShaderProperty VectorValue = new("_VectorValue");

        private readonly GUIContent _floatLabel = new("Float Test");
        private readonly GUIContent _vectorLabel = new("Vector Test");
        private readonly FloatRange _testFloatRange = new(0.0f, 10.0f);

        public SlidersTestSection() : base(new GUIContent("Test Label"))
        {
        }

        public override void FindProperties(MaterialProperty[] properties)
        {
            FloatValue.Find(properties);
            FloatMinValue.Find(properties);
            FloatMaxValue.Find(properties);
            VectorValue.Find(properties);
        }

        public override void DrawProperties(MaterialEditorGUIPlus editor)
        {
            editor.DrawSlider(_floatLabel, FloatValue.MaterialProperty, _testFloatRange, 1);
            editor.DrawSlider(_floatLabel, FloatValue.MaterialProperty, 1);
            editor.DrawFromVector4ParamSlider(_vectorLabel, VectorValue.MaterialProperty, Vector4Param.X, _testFloatRange, 1);
            editor.DrawFromVector4ParamSlider(_vectorLabel, VectorValue.MaterialProperty, Vector4Param.Y, 1);
            editor.DrawVector3Sliders(_vectorLabel, _vectorLabel, _vectorLabel, VectorValue.MaterialProperty, _testFloatRange, 1);
            editor.DrawVector3Sliders(_vectorLabel, _vectorLabel, _vectorLabel, VectorValue.MaterialProperty, 1);
            editor.DrawMinMaxSlider(_floatLabel, FloatMinValue.MaterialProperty, FloatMaxValue.MaterialProperty, _testFloatRange,1);
            editor.DrawMinMaxSlider(_floatLabel, FloatMinValue.MaterialProperty, FloatMaxValue.MaterialProperty,1);
            editor.DrawMinMaxVector4StartSlider(_vectorLabel, VectorValue.MaterialProperty, _testFloatRange, 1);
            editor.DrawMinMaxVector4StartSlider(_vectorLabel, VectorValue.MaterialProperty, 1);
            editor.DrawMinMaxVector4EndSlider(_vectorLabel, VectorValue.MaterialProperty, _testFloatRange, 1);
            editor.DrawMinMaxVector4EndSlider(_vectorLabel, VectorValue.MaterialProperty, 1);
        }

        public override void SetKeywords(Material material)
        {
        }
    }
}