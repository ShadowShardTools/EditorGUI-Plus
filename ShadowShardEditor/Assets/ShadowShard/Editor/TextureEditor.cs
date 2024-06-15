using System;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    internal class TextureEditor
    {
        private static readonly GUIContent FixNormal =
            EditorGUIUtility.TrTextContent("Fix now", "Converts the assigned texture to be a normal map format.");

        private static readonly GUIContent BumpScaleNotSupported =
            EditorGUIUtility.TrTextContent("Bump scale is not supported on mobile platforms");
        
        private readonly PropertyService _propertyService;
        private readonly GroupEditor _groupEditor;

        internal TextureEditor(PropertyService propertyService, GroupEditor groupEditor)
        {
            _propertyService = propertyService;
            _groupEditor = groupEditor;
        }

        internal Texture DrawTexture<TProperty>(GUIContent label, TProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetTexture(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();

                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Texture propertyValue = _propertyService.GetTexture(property);
                Texture newValue = EditorGUILayout.ObjectField(label, propertyValue, typeof(Texture), false) as Texture;
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck()) 
                    _propertyService.SetTexture(property, newValue);
            }
        }
        
        internal void DrawTexture(UnityEditor.MaterialEditor materialEditor, GUIContent label, MaterialProperty property)
        {
            materialEditor.TexturePropertySingleLine(label, property);
        }
        
        internal void DrawTexture(UnityEditor.MaterialEditor materialEditor, GUIContent label, MaterialProperty textureProperty, MaterialProperty secondProperty)
        {
            materialEditor.TexturePropertySingleLine(label, textureProperty, secondProperty);
        }
        
        internal void DrawTextureWithHDRColor(UnityEditor.MaterialEditor materialEditor, GUIContent label, MaterialProperty textureProperty, MaterialProperty colorProperty)
        {
            materialEditor.TexturePropertyWithHDRColor(label, textureProperty, 
                colorProperty, false);
        }
        
        internal void DrawNormalTexture(UnityEditor.MaterialEditor materialEditor, GUIContent label, MaterialProperty normalMap, MaterialProperty normalMapScale = null)
        {
            bool hasBumpMap = normalMap.textureValue is not null;
            MaterialProperty materialProperty = hasBumpMap ? normalMapScale : null;
            
            materialEditor.TexturePropertySingleLine(label, normalMap, materialProperty);
            
            if (normalMapScale is null)
                return;
            
            bool incorrectScale = Math.Abs(normalMapScale.floatValue - 1.0f) > 0.001f;
            if (incorrectScale && IsMobilePlatform())
                FixNormalScale(materialEditor, normalMapScale);
        }

        internal void FixNormalScale(UnityEditor.MaterialEditor materialEditor, MaterialProperty normalMapScale)
        {
            if(normalMapScale is null)
                return;
            
            bool fixScale = materialEditor.HelpBoxWithButton(BumpScaleNotSupported, FixNormal);
            
            if (fixScale)
                normalMapScale.floatValue = 1.0f;
        }

        internal void DrawTextureScaleOffset(UnityEditor.MaterialEditor materialEditor, MaterialProperty textureProperty)
        {
            if(textureProperty is null)
                return;
            
            materialEditor.TextureScaleOffsetProperty(textureProperty);
        }
        
        internal bool IsMobilePlatform() => 
            UnityEditorInternal.InternalEditorUtility.IsMobilePlatform(EditorUserBuildSettings.activeBuildTarget);
    }
}