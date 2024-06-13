using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor.ShaderGUI.Section
{
    public abstract class Section : ISection
    {
        public GUIContent Label { get; set; }
        public bool IsExpanded { get; set; }
        public bool IsRendered { get; set; }
        
        public Section(GUIContent label)
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