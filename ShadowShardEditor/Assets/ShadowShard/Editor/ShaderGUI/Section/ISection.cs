using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor.ShaderGUI.Section
{
    public interface ISection
    {
        public GUIContent Label { get; set; }
        public bool IsExpanded { get; set; }
        public bool IsRendered { get; set; }

        public void FindProperties(MaterialProperty[] properties);

        public void DrawProperties(ShadowShardEditor editor);

        public void SetKeywords(Material material);
    }
}