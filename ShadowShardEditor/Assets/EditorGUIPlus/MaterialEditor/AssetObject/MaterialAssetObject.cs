using System.Collections.Generic;
using UnityEngine;

namespace EditorGUIPlus.MaterialEditor.AssetObject
{
    public class MaterialAssetObject : ScriptableObject, IMaterialAssetObject
    {
        [SerializeField] 
        private List<Material> childMaterials;
        
        public readonly uint Hash = 0;
            
        public MaterialAssetObject() => 
            ResetToDefault();

        private void OnValidate() => 
            SetMaterialsAssetObject();
        
        public void SetMaterialsAssetObject()
        {
            if (childMaterials is null) 
                return;
            
            foreach (Material material in childMaterials)
                SetMaterialAssetObject(material);
        }

        public virtual void SetMaterialAssetObject(Material material)
        { }

        public virtual void ResetToDefault()
        {
            SetMaterialsAssetObject();
        }

        public virtual void AddChildMaterial(Material material)
        { }

        public virtual void RemoveChildMaterial(Material material)
        { }
    }
}