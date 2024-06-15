using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShadowShard.Editor.MaterialEditor
{
    public class MaterialExternalReferences : ScriptableObject
    {
        [SerializeField] 
        private MaterialAssetObject[] materialAssetObjects = Array.Empty<MaterialAssetObject>();
        
        [SerializeField] 
        internal Material[] materialReferences = Array.Empty<Material>();

        public void SetMaterialAssetObjectReference(int index, MaterialAssetObject profile)
        {
            if (index >= materialAssetObjects.Length)
            {
                var newList = new MaterialAssetObject[index + 1];
                for (int i = 0; i < materialAssetObjects.Length; ++i)
                    newList[i] = materialAssetObjects[i];

                materialAssetObjects = newList;
            }

            materialAssetObjects[index] = profile;
            EditorUtility.SetDirty(this);
        }

        public void SetMaterialReference(int index, Material mat)
        {
            if (index >= materialReferences.Length)
            {
                var newList = new Material[index + 1];
                for (int i = 0; i < materialReferences.Length; ++i)
                    newList[i] = materialReferences[i];

                materialReferences = newList;
            }

            materialReferences[index] = mat;
            EditorUtility.SetDirty(this);
        }

        public static MaterialExternalReferences GetMaterialExternalReferences(Material material)
        {
            var subAssets = AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GetAssetPath(material));
            MaterialExternalReferences matExternalRefs = null;
            foreach (Object subAsset in subAssets)
            {
                if (subAsset.GetType() == typeof(MaterialExternalReferences))
                {
                    matExternalRefs = subAsset as MaterialExternalReferences;
                    break;
                }
            }

            if (matExternalRefs == null)
            {
                matExternalRefs = CreateInstance<MaterialExternalReferences>();
                matExternalRefs.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector | HideFlags.NotEditable;
                AssetDatabase.AddObjectToAsset(matExternalRefs, material);
                EditorUtility.SetDirty(matExternalRefs);
                EditorUtility.SetDirty(material);
            }

            return matExternalRefs;
        }
    }
}