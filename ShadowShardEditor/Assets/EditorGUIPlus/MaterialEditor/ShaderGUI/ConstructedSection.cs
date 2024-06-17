using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.MaterialEditor.ShaderGUI
{
    public class ConstructedSection : MaterialSection
    {
        protected IFeature[] Features;

        public ConstructedSection(IFeature[] features, GUIContent label) : base(label) =>
            Features = features;

        public override void FindProperties(MaterialProperty[] properties)
        {
            foreach (IFeature feature in Features)
                feature.FindProperties(properties);
        }

        public override void DrawProperties(MaterialEditorGUIPlus editor)
        {
            foreach (IFeature feature in Features)
                feature.Draw(editor);
        }
        
        public override void SetKeywords(Material material)
        {
            foreach (IFeature feature in Features)
                feature.SetKeywords(material);
        }
    }
}