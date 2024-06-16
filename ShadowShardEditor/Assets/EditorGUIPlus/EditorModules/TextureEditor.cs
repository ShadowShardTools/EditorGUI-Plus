using System;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules
{
    internal sealed class TextureEditor
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

        internal Texture DrawTexture<TProperty>(GUIContent label, TProperty property, int indentLevel = 0, 
            Action onChangedCallback = null)
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
                {
                    _propertyService.SetTexture(property, newValue);
                    onChangedCallback?.Invoke();
                }
            }
        }
        
        internal void DrawSingleLineTexture(
            UnityEditor.MaterialEditor materialEditor,
            GUIContent label, 
            MaterialProperty textureProperty, 
            int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return;

            void Draw()
            {
                materialEditor.TexturePropertySingleLine(label, textureProperty);
            }
        }

        internal void DrawSingleLineTexture(
            UnityEditor.MaterialEditor materialEditor, 
            GUIContent label, 
            MaterialProperty textureProperty, 
            MaterialProperty secondProperty, 
            int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return;

            void Draw()
            {
                materialEditor.TexturePropertySingleLine(label, textureProperty, secondProperty);
            }
        }

        internal void DrawSingleLineTextureWithHDRColor(
            UnityEditor.MaterialEditor materialEditor,
            GUIContent label, 
            MaterialProperty textureProperty, 
            MaterialProperty colorProperty, 
            bool showAlpha = false,
            int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return;

            void Draw()
            {
                materialEditor.TexturePropertyWithHDRColor(label, textureProperty, colorProperty, showAlpha);
            }
        }

        internal void DrawSingleLineNormalTexture(
            UnityEditor.MaterialEditor materialEditor, 
            GUIContent label, 
            MaterialProperty normalMap, 
            MaterialProperty normalMapScale = null, 
            int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return;

            void Draw()
            {
                bool hasBumpMap = normalMap.textureValue != null;
                materialEditor.TexturePropertySingleLine(label, normalMap, hasBumpMap ? normalMapScale : null);
            
                if (normalMapScale is null)
                    return;
            
                bool incorrectScale = Math.Abs(normalMapScale.floatValue - 1.0f) > 0.001f;
                if (incorrectScale && IsMobilePlatform())
                    FixNormalScale(materialEditor, normalMapScale);
            }
        }

        internal void DrawTextureScaleOffset(UnityEditor.MaterialEditor materialEditor, MaterialProperty textureProperty, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return;

            void Draw()
            {
                materialEditor.TextureScaleOffsetProperty(textureProperty);
            }
        }

        internal void FixNormalScale(UnityEditor.MaterialEditor materialEditor, MaterialProperty normalMapScale)
        {
            if(normalMapScale is null)
                return;
            
            bool fixScale = materialEditor.HelpBoxWithButton(BumpScaleNotSupported, FixNormal);
            
            if (fixScale)
                normalMapScale.floatValue = 1.0f;
        }
        
        internal bool IsMobilePlatform() => 
            UnityEditorInternal.InternalEditorUtility.IsMobilePlatform(EditorUserBuildSettings.activeBuildTarget);
    }
}