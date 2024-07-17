using System.Collections.Generic;
using UnityEngine;

namespace EditorGUIPlus.MaterialEditor.AssetObject
{
    public class MaterialAssetObject : ScriptableObject, IMaterialAssetObject
    {
        [SerializeField]
        [HideInInspector]
        private List<Material> childMaterials = new List<Material>();
        
        public readonly uint Hash;

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
        {
            if(!childMaterials.Contains(material))
                childMaterials.Add(material);
        }

        public virtual void RemoveChildMaterial(Material material)
        {
            if(childMaterials.Contains(material))
                childMaterials.Remove(material);
        }
    }
}