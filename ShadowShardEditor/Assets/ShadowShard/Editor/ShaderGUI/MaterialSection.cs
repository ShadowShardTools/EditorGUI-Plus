using ShadowShard.Editor.Section;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor.ShaderGUI
{
    public abstract class MaterialSection : ISection
    {
        public GUIContent Label { get; set; }
        public bool IsExpanded { get; set; }
        public bool IsRendered { get; set; }
        
        public MaterialSection(GUIContent label)
        {
            Label = label;
            IsExpanded = true;
            IsRendered = true;
        }
        
        public abstract void FindProperties(MaterialProperty[] properties);
        public abstract void DrawProperties(ShadowShardEditor materialEditorWrapper);
        public abstract void SetKeywords(Material material);
    }
}