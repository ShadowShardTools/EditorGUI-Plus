using System;
using System.Collections.Generic;
using ShadowShard.Editor.MaterialEditor;
using ShadowShard.Editor.MaterialEditor.AssetObject;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShadowShard.Editor.EditorModules
{
    internal sealed class ObjectEditor
    {
        private readonly GroupEditor _groupEditor;

        internal ObjectEditor(GroupEditor groupEditor) =>
            _groupEditor = groupEditor;
        
        internal void DrawObjectField<TObject>(GUIContent label, SerializedProperty property, int indentLevel = 0,
            bool allowSceneObjects = true, Action<TObject> onChangedCallback = null)
            where TObject : Object
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                TObject newValue = EditorGUILayout.ObjectField(label, (TObject)property.objectReferenceValue,
                    typeof(TObject), allowSceneObjects: allowSceneObjects) as TObject;
                EditorGUI.showMixedValue = false;

                if(EditorGUI.EndChangeCheck())
                {
                    property.objectReferenceValue = newValue;
                    property.serializedObject.ApplyModifiedProperties();
                    onChangedCallback?.Invoke(newValue);
                }
            }
        }
        
        internal void DrawObjectField(
            GUIContent label, 
            Material material, 
            UnityEditor.MaterialEditor materialEditor,
            MaterialProperty assetProperty, 
            MaterialProperty hashProperty,
            int indentLevel = 0,
            bool allowSceneObjects = true, 
            Action<MaterialAssetObject> onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = assetProperty.hasMixedValue || hashProperty.hasMixedValue;
                string guid = assetProperty.vectorValue.ToGuid();
                MaterialAssetObject assetObject = GetMaterialAssetObjectFromGuid<MaterialAssetObject>(guid);
                MaterialAssetObject newValue = EditorGUILayout.ObjectField(label, assetObject, typeof(MaterialAssetObject), allowSceneObjects: allowSceneObjects) as MaterialAssetObject;
                EditorGUI.showMixedValue = false;

                if(EditorGUI.EndChangeCheck())
                {
                    UpdateMaterialAssetObject(material, assetObject, assetProperty, hashProperty, guid);
                    UpdateExternalReference(materialEditor, assetObject);
                    onChangedCallback?.Invoke(newValue);
                }
            }
        }
        
        private TObject GetMaterialAssetObjectFromGuid<TObject>(string guid) where TObject : Object
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            
            return string.IsNullOrEmpty(assetPath) ? null : AssetDatabase.LoadAssetAtPath<TObject>(assetPath);
        }
        
        private void UpdateMaterialAssetObject(Material material, MaterialAssetObject materialAssetObject, 
            MaterialProperty assetProperty, MaterialProperty hashProperty, string guid)
        {
            if (guid == null)
                throw new ArgumentNullException(nameof(guid));

            Vector4 newGuid = Vector4.zero;
            float hash = 0;

            if (materialAssetObject != null)
            {
                guid = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(materialAssetObject));
                newGuid = guid.ToVector4();
                hash = materialAssetObject.Hash.AsFloat();

                materialAssetObject.SetMaterialAssetObject(material);
                materialAssetObject.AddChildMaterial(material);
            }

            if (assetProperty.vectorValue != newGuid)
            {
                string oldProfileGuid = assetProperty.vectorValue.ToGuid();
                MaterialAssetObject oldProfileSettings = 
                    AssetDatabase.LoadAssetAtPath<MaterialAssetObject>(AssetDatabase.GUIDToAssetPath(oldProfileGuid));

                if (oldProfileSettings != null && oldProfileSettings != materialAssetObject)
                    oldProfileSettings.RemoveChildMaterial(material);
            }

            assetProperty.vectorValue = newGuid;
            hashProperty.floatValue = hash;
        }
        
        private void UpdateExternalReference(UnityEditor.MaterialEditor materialEditor, MaterialAssetObject materialAssetObject)
        {
            foreach (Object target in GetTargets(materialEditor))
            {
                MaterialExternalReferences matExternalRefs = MaterialExternalReferences.GetMaterialExternalReferences(target as Material);
                matExternalRefs.SetMaterialAssetObjectReference(0, materialAssetObject);
            }
        }
        
        private IEnumerable<Object> GetTargets(UnityEditor.MaterialEditor materialEditor) => 
            materialEditor.targets;
    }
}