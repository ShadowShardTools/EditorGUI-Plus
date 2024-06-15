using UnityEngine;

namespace ShadowShard.Editor.MaterialEditor.AssetObject
{
    public interface IMaterialAssetObject
    {
        void SetMaterialsAssetObject();
        void SetMaterialAssetObject(Material material);
        void ResetToDefault();
        
        void AddChildMaterial(Material material);
        void RemoveChildMaterial(Material material);
    }
}