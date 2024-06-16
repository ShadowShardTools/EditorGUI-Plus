using EditorGUIPlus;
using EditorGUIPlus.MaterialEditor.ShaderGUI;
using UnityEditor;
using UnityEngine;

namespace ManualTesting.MaterialEditor
{
    public class TestSection : MaterialSection
    {
        protected Property DetailMap = new(DetailInputsProperties.DetailMap);
        protected Property DetailAlbedoScale = new(DetailInputsProperties.DetailAlbedoScale);
        protected Property DetailNormalScale = new(DetailInputsProperties.DetailNormalScale);
        protected Property DetailSmoothnessScale = new(DetailInputsProperties.DetailSmoothnessScale);

        public TestSection() : base(DetailInputsStyles.Label)
        {
        }

        public override void FindProperties(MaterialProperty[] properties)
        {
            DetailMap.Find(properties);
            DetailAlbedoScale.Find(properties);
            DetailNormalScale.Find(properties);
            DetailSmoothnessScale.Find(properties);
        }

        public override void DrawProperties(EditorGUIPlus.EditorGUIPlus editorGUIPlus)
        {
            DrawDetailMap(editorGUIPlus);
            DrawDetailMapProperties(editorGUIPlus);
            editorGUIPlus.TextureEditor.DrawTextureScaleOffset(editorGUIPlus.MaterialEditor, DetailMap.MaterialProperty);
        }

        private void DrawDetailMap(EditorGUIPlus.EditorGUIPlus editorGUIPlus) =>
            editorGUIPlus.TextureEditor.DrawTexture(editorGUIPlus.MaterialEditor, DetailInputsStyles.DetailMap,
                DetailMap.MaterialProperty);

        protected virtual void DrawDetailMapProperties(EditorGUIPlus.EditorGUIPlus editorGUIPlus)
        {
            if (DetailMap.MaterialProperty.textureValue is null)
                return;

            editorGUIPlus.SliderEditor.DrawSlider(DetailInputsStyles.DetailAlbedoScale, DetailAlbedoScale.MaterialProperty, 1);
            editorGUIPlus.SliderEditor.DrawSlider(DetailInputsStyles.DetailNormalScale, DetailNormalScale.MaterialProperty, 1);
            editorGUIPlus.SliderEditor.DrawSlider(DetailInputsStyles.DetailSmoothnessScale,
                DetailSmoothnessScale.MaterialProperty, 1);
        }

        public override void SetKeywords(Material material)
        {
            if (material.HasProperty(DetailMap.ID))
                CoreUtils.SetKeyword(material, DetailInputsKeywords.Detail, material.GetTexture(DetailMap.ID));
        }
    }
}