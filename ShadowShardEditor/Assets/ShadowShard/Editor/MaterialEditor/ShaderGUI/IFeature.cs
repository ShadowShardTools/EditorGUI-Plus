using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor.MaterialEditor.ShaderGUI
{
    public interface IFeature
    {
        public void FindProperties(MaterialProperty[] properties);

        public void Draw(ShadowShardEditor editor);

        public void SetKeywords(Material material);
    }
}