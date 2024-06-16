using System;
using ShadowShard.Editor.Data.Enums;
using ShadowShard.Editor.Data.Range;
using ShadowShard.Editor.MaterialEditor.AssetObject;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor.MaterialEditor
{
    public interface IShadowShardMaterialEditor
    {
        void InitializeMaterialEditor(UnityEditor.MaterialEditor materialEditor);
        void DrawVertical(GUIStyle styles, Action drawCall);
        void DrawIndented(int indentLevel, Action drawCall);
        void DrawDisabled(bool isDisabled, Action drawCall);
        void DrawIndentedDisabled(int indentLevel, bool isDisabled, Action drawCall);
        void DrawGroup(bool isDisabled, Action drawCall);
        void DrawGroup(Action drawCall);
        void DrawGroup(GUIContent label, bool isDisabled, Action drawCall);
        void DrawGroup(GUIContent label, Action drawCall);
        float DrawSlider(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0);
        float DrawSlider(GUIContent label, MaterialProperty property, int indentLevel = 0);
        int DrawIntSlider(GUIContent label, MaterialProperty property, IntRange range, int indentLevel = 0);
        int DrawIntSlider(GUIContent label, MaterialProperty property, int indentLevel = 0);
        void DrawFromVector3ParamSlider(GUIContent label, MaterialProperty property, Vector3Param vectorParam, FloatRange range, int indentLevel = 0);
        void DrawFromVector3ParamSlider(GUIContent label, MaterialProperty property, Vector3Param vectorParam, int indentLevel = 0);
        void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, MaterialProperty property, FloatRange range, int indentLevel = 0);
        void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, MaterialProperty property, int indentLevel = 0);
        FloatRange DrawMinMaxSlider(GUIContent label, MaterialProperty minProperty, MaterialProperty maxProperty, FloatRange range, int indentLevel = 0);
        FloatRange DrawMinMaxSlider(GUIContent label, MaterialProperty minProperty, MaterialProperty maxProperty, int indentLevel = 0);
        FloatRange DrawMinMaxVector4StartSlider(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0);
        FloatRange DrawMinMaxVector4StartSlider(GUIContent label, MaterialProperty property, int indentLevel = 0);
        FloatRange DrawMinMaxVector4EndSlider(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0);
        FloatRange DrawMinMaxVector4EndSlider(GUIContent label, MaterialProperty property, int indentLevel = 0);
        bool DrawToggle(GUIContent label, MaterialProperty property, int indentLevel = 0);
        bool DrawShaderGlobalKeywordToggle(GUIContent label, MaterialProperty property, string shaderGlobalKeyword, int indentLevel = 0);
        float DrawFloat(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0);
        float DrawFloat(GUIContent label, MaterialProperty property, int indentLevel = 0);
        Vector2 DrawVector2(GUIContent label, MaterialProperty property, Vector2Range range, int indentLevel = 0);
        Vector2 DrawVector2(GUIContent label, MaterialProperty property, int indentLevel = 0);
        Vector3 DrawVector3(GUIContent label, MaterialProperty property, Vector3Range range, int indentLevel = 0);
        Vector3 DrawVector3(GUIContent label, MaterialProperty property, int indentLevel = 0);
        Vector4 DrawVector4(GUIContent label, MaterialProperty property, Vector4Range range, int indentLevel = 0);
        Vector4 DrawVector4(GUIContent label, MaterialProperty property, int indentLevel = 0);
        float DrawNormalizedFloat(GUIContent label, MaterialProperty property, int indentLevel = 0);
        Vector2 DrawNormalizedVector2(GUIContent label, MaterialProperty property, int indentLevel = 0);
        Vector2 DrawNormalizedVector3(GUIContent label, MaterialProperty property, int indentLevel = 0);
        Vector2 DrawNormalizedVector4(GUIContent label, MaterialProperty property, int indentLevel = 0);

        Vector2 DrawNormalizedFloatFromVector2(GUIContent label, MaterialProperty property, 
            Vector2Param vector2Param, int indentLevel = 0);

        Vector3 DrawNormalizedFloatFromVector3(GUIContent label, MaterialProperty property, 
            Vector3Param vector3Param, int indentLevel = 0);

        Vector4 DrawNormalizedFloatFromVector4(GUIContent label, MaterialProperty property, 
            Vector4Param vector4Param, int indentLevel = 0);

        float DrawMinFloat(GUIContent label, MaterialProperty property, float min = 0.0f, int indentLevel = 0);
        Vector2 DrawMinVector2(GUIContent label, MaterialProperty property, Vector2 min, int indentLevel = 0);
        Vector2 DrawMinVector3(GUIContent label, MaterialProperty property, Vector3 min, int indentLevel = 0);
        Vector2 DrawMinVector4(GUIContent label, MaterialProperty property, Vector4 min, int indentLevel = 0);

        Vector2 DrawMinFloatFromVector2(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            float min = 0.0f, int indentLevel = 0);

        Vector3 DrawMinFloatFromVector3(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            float min = 0.0f, int indentLevel = 0);

        Vector4 DrawMinFloatFromVector4(GUIContent label, MaterialProperty property, Vector4Param vector4Param, 
            float min = 0.0f, int indentLevel = 0);

        Vector2 DrawFloatFromVector2(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0);

        Vector3 DrawFloatFromVector3(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            FloatRange range, int indentLevel = 0);

        Vector4 DrawFloatFromVector4(GUIContent label, MaterialProperty property, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0);

        Vector4 DrawVector4Start(GUIContent label, MaterialProperty property, Vector2Range range, int indentLevel = 0);
        Vector4 DrawVector4Start(GUIContent label, MaterialProperty property, int indentLevel = 0);
        Vector4 DrawVector4End(GUIContent label, MaterialProperty property, Vector2Range range, int indentLevel = 0);
        Vector4 DrawVector4End(GUIContent label, MaterialProperty property, int indentLevel = 0);
        Color DrawColor(GUIContent label, MaterialProperty property, bool showAlpha = true, bool hdr = false, int indentLevel = 0);
        float DrawInt(GUIContent label, MaterialProperty property, IntRange range, int indentLevel = 0);
        float DrawInt(GUIContent label, MaterialProperty property, int indentLevel = 0);
        Vector2Int DrawVector2Int(GUIContent label, MaterialProperty property, Vector2IntRange range, int indentLevel = 0);
        Vector2Int DrawVector2Int(GUIContent label, MaterialProperty property, int indentLevel = 0);
        Vector3Int DrawVector3Int(GUIContent label, MaterialProperty property, Vector3IntRange range, int indentLevel = 0);
        Vector3Int DrawVector3Int(GUIContent label, MaterialProperty property, int indentLevel = 0);
        float DrawNormalizedInt(GUIContent label, MaterialProperty property, int indentLevel = 0);
        Vector2Int DrawNormalizedVector2Int(GUIContent label, MaterialProperty property, int indentLevel = 0);
        Vector3Int DrawNormalizedVector3Int(GUIContent label, MaterialProperty property, int indentLevel = 0);
        int DrawMinInt(GUIContent label, MaterialProperty property, int min = 0, int indentLevel = 0);
        Vector2Int DrawMinVector2Int(GUIContent label, MaterialProperty property, Vector2Int min, int indentLevel = 0);
        Vector3Int DrawMinVector3Int(GUIContent label, MaterialProperty property, Vector3Int min, int indentLevel = 0);

        Vector2Int DrawIntFromVector2Int(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            IntRange range, int indentLevel = 0);

        Vector3Int DrawIntFromVector3Int(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            IntRange range, int indentLevel = 0);

        Vector2Int DrawNormalizedIntFromVector2Int(GUIContent label, MaterialProperty property, 
            Vector2Param vector2Param, int indentLevel = 0);

        Vector3Int DrawNormalizedIntFromVector3Int(GUIContent label, MaterialProperty property, 
            Vector3Param vector3Param, int indentLevel = 0);

        Vector2Int DrawMinIntFromVector2Int(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            int min = 0, int indentLevel = 0);

        Vector3Int DrawMinIntFromVector3Int(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            int min = 0, int indentLevel = 0);

        Texture DrawTexture(GUIContent label, MaterialProperty property, int indentLevel = 0);
        void DrawSingleLineTexture(GUIContent label, MaterialProperty textureProperty, int indentLevel = 0);

        void DrawSingleLineTexture(GUIContent label, MaterialProperty textureProperty, 
            MaterialProperty secondProperty, int indentLevel = 0);

        void DrawSingleLineTextureWithHDRColor(GUIContent label, MaterialProperty textureProperty, 
            MaterialProperty colorProperty, bool showAlpha = false, int indentLevel = 0);

        void DrawSingleLineTextureWithHDRColor(GUIContent label, MaterialProperty textureProperty, 
            MaterialProperty colorProperty, int indentLevel = 0);

        void DrawSingleLineNormalTexture(GUIContent label, MaterialProperty normalMap, 
            MaterialProperty normalMapScale = null, int indentLevel = 0);

        void DrawTextureScaleOffset(MaterialProperty textureProperty, int indentLevel = 0);
        TEnum DrawEnumPopup<TEnum>(MaterialProperty property, int indentLevel = 0) where TEnum : Enum;
        TEnum DrawEnumPopup<TEnum>(GUIContent label, MaterialProperty property, int indentLevel = 0) where TEnum : Enum;
        TEnum DrawBooleanPopup<TEnum>(MaterialProperty property, int indentLevel = 0) where TEnum : Enum;
        TEnum DrawBooleanPopup<TEnum>(GUIContent label, MaterialProperty property, int indentLevel = 0) where TEnum : Enum;
        int DrawBooleanPopup(GUIContent label, MaterialProperty property, string[] displayedOptions, int indentLevel = 0);
        TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(MaterialProperty property, string shaderGlobalKeyword, int indentLevel = 0) where TEnum : Enum;
        TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, MaterialProperty property, string shaderGlobalKeyword, int indentLevel = 0) where TEnum : Enum;

        int DrawShaderGlobalKeywordBooleanPopup(GUIContent label, MaterialProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0);

        int DrawPopup(GUIContent label, MaterialProperty property, string[] displayedOptions, int indentLevel = 0);

        void DrawObjectField(
            GUIContent label, 
            Material material, 
            MaterialProperty assetProperty, 
            MaterialProperty hashProperty, 
            int indentLevel = 0,
            bool allowSceneObjects = false, 
            Action<MaterialAssetObject> onChangedCallback = null);
    }
}