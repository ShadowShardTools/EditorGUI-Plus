using System;
using System.Collections.Generic;
using EditorGUIPlus.MaterialEditor;
using EditorGUIPlus.MaterialEditor.AssetObject;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EditorGUIPlus.EditorModules
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
        
        internal void DrawMaterialAssetObject(
            Material material, 
            UnityEditor.MaterialEditor materialEditor,
            MaterialProperty assetProperty,
            MaterialProperty hashProperty,
            Func<MaterialAssetObject> drawObjectField,
            int indentLevel = 0,
            Action onChangedCallback = null)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = assetProperty.hasMixedValue || hashProperty.hasMixedValue;
                MaterialAssetObject newValue = drawObjectField.Invoke();
                EditorGUI.showMixedValue = false;

                if(EditorGUI.EndChangeCheck())
                {
                    UpdateMaterialAssetObject(material, newValue, assetProperty, hashProperty);
                    UpdateExternalReference(materialEditor, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        public T GetMaterialAssetObjectFromGuid<T>(string guid) where T : MaterialAssetObject
        {
            if (string.IsNullOrEmpty(guid))
                return null;

            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            return string.IsNullOrEmpty(assetPath) ? null : AssetDatabase.LoadAssetAtPath<T>(assetPath);
        }
        
        private void UpdateMaterialAssetObject<T>(Material material, T newMaterialAssetObject,
            MaterialProperty assetProperty, MaterialProperty hashProperty) where T : MaterialAssetObject
        {
            Vector4 newGuid = Vector4.zero;
            float hash = 0;

            if (newMaterialAssetObject != null)
            {
                string newGuidString = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(newMaterialAssetObject));
                newGuid = newGuidString.ToVector4();
                hash = newMaterialAssetObject.Hash.AsFloat();

                newMaterialAssetObject.SetMaterialAssetObject(material);
                newMaterialAssetObject.AddChildMaterial(material);
            }

            string oldGuidString = assetProperty.vectorValue.ToGuid();
            if (assetProperty.vectorValue != newGuid)
            {
                MaterialAssetObject oldMaterialAssetObject = 
                    AssetDatabase.LoadAssetAtPath<MaterialAssetObject>(AssetDatabase.GUIDToAssetPath(oldGuidString));

                if (oldMaterialAssetObject != null && oldMaterialAssetObject != newMaterialAssetObject)
                {
                    oldMaterialAssetObject.RemoveChildMaterial(material);
                }

                assetProperty.vectorValue = newGuid;
                hashProperty.floatValue = hash;
            }
        }
        
        private void UpdateExternalReference<T>(UnityEditor.MaterialEditor materialEditor, T newMaterialAssetObject) where T : MaterialAssetObject
        {
            foreach (Object target in materialEditor.targets)
            {
                MaterialExternalReferences matExternalRefs = MaterialExternalReferences.GetMaterialExternalReferences(target as Material);
                matExternalRefs.SetMaterialAssetObjectReference(0, newMaterialAssetObject);
            }
        }
    }
}