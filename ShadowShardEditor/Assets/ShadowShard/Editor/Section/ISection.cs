using UnityEngine;

namespace ShadowShard.Editor.Section
{
    public interface ISection
    {
        public GUIContent Label { get; set; }
        public bool IsExpanded { get; set; }
        public bool IsRendered { get; set; }
    }
}