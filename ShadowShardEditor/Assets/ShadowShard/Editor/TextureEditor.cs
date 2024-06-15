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
        
        private readonly GroupEditor _groupEditor;

        public TextureEditor(GroupEditor groupEditor) => 
            _groupEditor = groupEditor;

        public Texture2D DrawTexture(GUIContent label, SerializedProperty property, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return (Texture2D)property.objectReferenceValue;

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                Texture2D newValue = EditorGUILayout.ObjectField(label, (Texture2D)property.objectReferenceValue, typeof(Texture2D), false) as Texture2D;
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    property.objectReferenceValue = newValue;
                    property.serializedObject.ApplyModifiedProperties();
                }
            }
        }
        
        public Texture2D DrawSmallTextureField(GUIContent label, SerializedProperty property, int indentLevel = 0)
        {
            const float thumbnailSize = 16f;

            Rect thumbnailRect = EditorGUILayout.GetControlRect(false, thumbnailSize);
            Texture2D propertyValue = (Texture2D)property.objectReferenceValue;
            
            _groupEditor.DrawIndented(indentLevel, Draw);
            return propertyValue;

            void Draw()
            {
                EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
                EditorGUI.DrawTextureTransparent(thumbnailRect, propertyValue, ScaleMode.ScaleToFit);
                EditorGUI.PropertyField(thumbnailRect, property, label);
                EditorGUI.showMixedValue = false;
            }
        }
        
        //TODO: move to MaterialEditor
        public void DrawTexture(MaterialEditor materialEditor, GUIContent label, MaterialProperty property)
        {
            materialEditor.TexturePropertySingleLine(label, property);
        }
        
        public void DrawTexture(MaterialEditor materialEditor, GUIContent label, MaterialProperty textureProperty, MaterialProperty secondProperty)
        {
            materialEditor.TexturePropertySingleLine(label, textureProperty, secondProperty);
        }
        
        public void DrawTextureWithHDRColor(MaterialEditor materialEditor, GUIContent label, MaterialProperty textureProperty, MaterialProperty colorProperty)
        {
            materialEditor.TexturePropertyWithHDRColor(label, textureProperty, 
                colorProperty, false);
        }
        
        public void DrawNormalTexture(MaterialEditor materialEditor, GUIContent label, MaterialProperty normalMap, MaterialProperty normalMapScale = null)
        {
            if (normalMap is null)
                return;
                
            bool hasBumpMap = normalMap.textureValue is not null;
            MaterialProperty materialProperty = hasBumpMap ? normalMapScale : null;
            
            materialEditor.TexturePropertySingleLine(label, normalMap, materialProperty);
            
            if (normalMapScale is null)
                return;
            
            bool incorrectScale = Math.Abs(normalMapScale.floatValue - 1.0f) > 0.001f;
            if (incorrectScale && IsMobilePlatform())
                FixNormalScale(materialEditor, normalMapScale);
        }

        public void FixNormalScale(MaterialEditor materialEditor, MaterialProperty normalMapScale)
        {
            if(normalMapScale is null)
                return;
            
            bool fixScale = materialEditor.HelpBoxWithButton(BumpScaleNotSupported, FixNormal);
            
            if (fixScale)
                normalMapScale.floatValue = 1.0f;
        }

        public void DrawTextureScaleOffset(MaterialEditor materialEditor, MaterialProperty textureProperty)
        {
            if(textureProperty is null)
                return;
            
            materialEditor.TextureScaleOffsetProperty(textureProperty);
        }
        
        private bool IsMobilePlatform() => 
            UnityEditorInternal.InternalEditorUtility.IsMobilePlatform(EditorUserBuildSettings.activeBuildTarget);
    }
}