using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using EditorGUIPlus.MaterialEditor;
using EditorGUIPlus.MaterialEditor.ShaderGUI;
using UnityEditor;
using UnityEngine;

namespace ManualTesting.MaterialEditor
{
    public class VectorTestSection : MaterialSection
    {
        protected ShaderProperty Color = new("_Color");
        protected ShaderProperty BaseMap = new("_BaseMap");
        protected ShaderProperty FloatValue = new("_FloatValue");
        protected ShaderProperty VectorValue = new("_VectorValue");
        protected ShaderProperty EnumValue = new("_EnumValue");

        private readonly GUIContent _colorLabel = new("Color Test");
        private readonly GUIContent _floatLabel = new("Float Test");
        private readonly GUIContent _vectorLabel = new("Vector Test");
        
        private readonly FloatRange _testFloatRange = new(0.0f, 10.0f);
        private readonly Vector2Range _testVector2Range = new(Vector2.zero, new Vector2(10.0f, 10.0f));
        private readonly Vector3Range _testVector3Range = new(Vector3.zero, new Vector3(10.0f, 10.0f, 10.0f));
        private readonly Vector4Range _testVector4Range = new(Vector3.zero, new Vector4(10.0f, 10.0f, 10.0f, 10.0f));

        public VectorTestSection() : base(new GUIContent("Test Label"))
        {
        }

        public override void FindProperties(MaterialProperty[] properties)
        {
            Color.Find(properties);
            BaseMap.Find(properties);
            FloatValue.Find(properties);
            VectorValue.Find(properties);
            EnumValue.Find(properties);
        }

        public override void DrawProperties(MaterialEditorGUIPlus editor)
        {
            editor.DrawFloat(_floatLabel, FloatValue.MaterialProperty, _testFloatRange, 1);
            editor.DrawVector2(_vectorLabel, VectorValue.MaterialProperty, _testVector2Range, 1);
            editor.DrawVector3(_vectorLabel, VectorValue.MaterialProperty, _testVector3Range, 1);
            editor.DrawVector4(_vectorLabel, VectorValue.MaterialProperty, _testVector4Range, 1);
            
            editor.DrawFloat(_floatLabel, FloatValue.MaterialProperty, 1);
            editor.DrawVector2(_vectorLabel, VectorValue.MaterialProperty, 1);
            editor.DrawVector3(_vectorLabel, VectorValue.MaterialProperty, 1);
            editor.DrawVector4(_vectorLabel, VectorValue.MaterialProperty, 1);
            
            editor.DrawFloatFromVector2(_vectorLabel, VectorValue.MaterialProperty, Vector2Param.X, _testFloatRange, 1);
            editor.DrawFloatFromVector3(_vectorLabel, VectorValue.MaterialProperty, Vector3Param.Z, _testFloatRange, 1);
            editor.DrawFloatFromVector4(_vectorLabel, VectorValue.MaterialProperty, Vector4Param.W, _testFloatRange, 1);
            
            editor.DrawNormalizedFloat(_floatLabel, FloatValue.MaterialProperty, 1);
            editor.DrawNormalizedVector2(_vectorLabel, VectorValue.MaterialProperty, 1);
            editor.DrawNormalizedVector3(_vectorLabel, VectorValue.MaterialProperty, 1);
            editor.DrawNormalizedVector4(_vectorLabel, VectorValue.MaterialProperty, 1);
            
            editor.DrawNormalizedFloatFromVector2(_vectorLabel, VectorValue.MaterialProperty, Vector2Param.X, 1);
            editor.DrawNormalizedFloatFromVector3(_vectorLabel, VectorValue.MaterialProperty, Vector3Param.Z, 1);
            editor.DrawNormalizedFloatFromVector4(_vectorLabel, VectorValue.MaterialProperty, Vector4Param.W, 1);
            
            editor.DrawMinFloat(_floatLabel, FloatValue.MaterialProperty, 0.0f, 1);
            editor.DrawMinVector2(_vectorLabel, VectorValue.MaterialProperty, Vector2.zero, 1);
            editor.DrawMinVector3(_vectorLabel, VectorValue.MaterialProperty, Vector3.zero, 1);
            editor.DrawMinVector4(_vectorLabel, VectorValue.MaterialProperty, Vector4.zero, 1);
            
            editor.DrawMinFloatFromVector2(_vectorLabel, VectorValue.MaterialProperty, Vector2Param.X, 0.0f, 1);
            editor.DrawMinFloatFromVector3(_vectorLabel, VectorValue.MaterialProperty, Vector3Param.Z, 0.0f, 1);
            editor.DrawMinFloatFromVector4(_vectorLabel, VectorValue.MaterialProperty, Vector4Param.W, 0.0f, 1);
            
            editor.DrawVector4Start(_floatLabel, VectorValue.MaterialProperty, _testVector2Range, 1);
            editor.DrawVector4Start(_vectorLabel, VectorValue.MaterialProperty, 1);
            editor.DrawVector4End(_vectorLabel, VectorValue.MaterialProperty, _testVector2Range, 1);
            editor.DrawVector4End(_vectorLabel, VectorValue.MaterialProperty, 1);
            
            editor.DrawColor(_vectorLabel, Color.MaterialProperty, false, false, 1);
        }

        public override void SetKeywords(Material material)
        {
        }
    }
}