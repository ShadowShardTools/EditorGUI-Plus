using System;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class TextureEditor
    {
        private static readonly GUIContent FixNormal =
            EditorGUIUtility.TrTextContent("Fix now", "Converts the assigned texture to be a normal map format.");

        private static readonly GUIContent BumpScaleNotSupported =
            EditorGUIUtility.TrTextContent("Bump scale is not supported on mobile platforms");
        
        private readonly EditorUtils _editorUtils;

        public TextureEditor(EditorUtils editorUtils) => 
            _editorUtils = editorUtils;

        public void DrawTexture(GUIContent label, SerializedProperty property, int indentLevel = 0)
        {
            if (property is null)
                return;
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                var newValue = EditorGUILayout.ObjectField(label, (Texture2D)property.objectReferenceValue, 
                    typeof(Texture2D), false) as Texture2D;
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    property.objectReferenceValue = newValue;
                    property.serializedObject.ApplyModifiedProperties();
                }
            });
        }
        
        public void DrawSmallTextureField<T>(GUIContent label, T property, int indentLevel = 0) where T : class
        {
            if (property is null) 
                return;
            
            const float thumbnailSize = 16f;

            var thumbnailRect = EditorGUILayout.GetControlRect(false, thumbnailSize);
            
            var propertyValue = _editorUtils.GetPropertyValue<Texture2D>(property);
            
            _editorUtils.DrawIndented(indentLevel, () =>
            {
                EditorGUI.showMixedValue = _editorUtils.HasMixedValue(property);
                EditorGUI.DrawTextureTransparent(thumbnailRect, propertyValue, ScaleMode.ScaleToFit);
                //EditorGUI.PropertyField(thumbnailRect, propertyValue, label);
                EditorGUI.showMixedValue = false;
            });
        }
        
        public void DrawTexture(MaterialEditor materialEditor, GUIContent label, MaterialProperty property)
        {
            if (property is null) 
                return;

            materialEditor.TexturePropertySingleLine(label, property);
        }
        
        public void DrawTexture(MaterialEditor materialEditor, GUIContent label, MaterialProperty textureProperty, MaterialProperty secondProperty)
        {
            if (textureProperty is null)
                return;
            
            if (secondProperty is null)
                return;
            
            materialEditor.TexturePropertySingleLine(label, textureProperty, secondProperty);
        }
        
        public void DrawTextureWithHDRColor(MaterialEditor materialEditor, GUIContent label, MaterialProperty textureProperty, MaterialProperty colorProperty)
        {
            if (textureProperty is null)
                return;
            
            if (colorProperty is null)
                return;
            
            materialEditor.TexturePropertyWithHDRColor(label, textureProperty, 
                colorProperty, false);
        }
        
        public void DrawNormalTexture(MaterialEditor materialEditor, GUIContent label, MaterialProperty normalMap, MaterialProperty normalMapScale = null)
        {
            if (normalMap is null)
                return;
                
            var hasBumpMap = normalMap.textureValue is not null;
            var materialProperty = hasBumpMap ? normalMapScale : null;
            
            materialEditor.TexturePropertySingleLine(label, normalMap, materialProperty);
            
            if (normalMapScale is null)
                return;
            
            var incorrectScale = Math.Abs(normalMapScale.floatValue - 1.0f) > 0.001f;
            if (incorrectScale && _editorUtils.IsMobilePlatform())
                FixNormalScale(materialEditor, normalMapScale);
        }

        public void FixNormalScale(MaterialEditor materialEditor, MaterialProperty normalMapScale)
        {
            if(normalMapScale is null)
                return;
            
            var fixScale = materialEditor.HelpBoxWithButton(BumpScaleNotSupported, FixNormal);
            
            if (fixScale)
                normalMapScale.floatValue = 1.0f;
        }

        public void DrawTextureScaleOffset(MaterialEditor materialEditor, MaterialProperty textureProperty)
        {
            if(textureProperty is null)
                return;
            
            materialEditor.TextureScaleOffsetProperty(textureProperty);
        }
    }
}