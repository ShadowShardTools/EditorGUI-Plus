using System;
using ShadowShard.Editor.Data.Enums;
using ShadowShard.Editor.Data.Range;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShadowShard.Editor
{
    public interface IShadowShardEditor
    {
        void DrawVertical(GUIStyle styles, Action drawCall);
        void DrawIndented(int indentLevel, Action drawCall);
        void DrawDisabled(bool isDisabled, Action drawCall);
        void DrawIndentedDisabled(int indentLevel, bool isDisabled, Action drawCall);
        void DrawGroup(bool isDisabled, Action drawCall);
        void DrawGroup(Action drawCall);
        void DrawGroup(GUIContent label, bool isDisabled, Action drawCall);
        void DrawGroup(GUIContent label, Action drawCall);
        float DrawSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0);
        float DrawSlider(GUIContent label, SerializedProperty property, int indentLevel = 0);
        int DrawIntSlider(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0);
        int DrawIntSlider(GUIContent label, SerializedProperty property, int indentLevel = 0);
        void DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, FloatRange range, int indentLevel = 0);
        void DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, int indentLevel = 0);
        void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, SerializedProperty property, FloatRange range, int indentLevel = 0);
        void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, SerializedProperty property, int indentLevel = 0);
        FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, SerializedProperty maxProperty, FloatRange range, int indentLevel = 0);
        FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, SerializedProperty maxProperty, int indentLevel = 0);
        FloatRange DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0);
        FloatRange DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, int indentLevel = 0);
        FloatRange DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0);
        FloatRange DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, int indentLevel = 0);
        bool DrawToggle(GUIContent label, SerializedProperty property, int indentLevel = 0);
        bool DrawShaderGlobalKeywordToggle(GUIContent label, SerializedProperty property, string shaderGlobalKeyword, int indentLevel = 0);
        float DrawFloat(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0);
        float DrawFloat(GUIContent label, SerializedProperty property, int indentLevel = 0);
        Vector2 DrawVector2(GUIContent label, SerializedProperty property, Vector2Range range, int indentLevel = 0);
        Vector2 DrawVector2(GUIContent label, SerializedProperty property, int indentLevel = 0);
        Vector3 DrawVector3(GUIContent label, SerializedProperty property, Vector3Range range, int indentLevel = 0);
        Vector3 DrawVector3(GUIContent label, SerializedProperty property, int indentLevel = 0);
        Vector4 DrawVector4(GUIContent label, SerializedProperty property, Vector4Range range, int indentLevel = 0);
        Vector4 DrawVector4(GUIContent label, SerializedProperty property, int indentLevel = 0);
        float DrawNormalizedFloat(GUIContent label, SerializedProperty property, int indentLevel = 0);
        Vector2 DrawNormalizedVector2(GUIContent label, SerializedProperty property, int indentLevel = 0);
        Vector2 DrawNormalizedVector3(GUIContent label, SerializedProperty property, int indentLevel = 0);
        Vector2 DrawNormalizedVector4(GUIContent label, SerializedProperty property, int indentLevel = 0);

        Vector2 DrawNormalizedFloatFromVector2(GUIContent label, SerializedProperty property, 
            Vector2Param vector2Param, int indentLevel = 0);

        Vector3 DrawNormalizedFloatFromVector3(GUIContent label, SerializedProperty property, 
            Vector3Param vector3Param, int indentLevel = 0);

        Vector4 DrawNormalizedFloatFromVector4(GUIContent label, SerializedProperty property, 
            Vector4Param vector4Param, int indentLevel = 0);

        float DrawMinFloat(GUIContent label, SerializedProperty property, float min = 0.0f, int indentLevel = 0);
        Vector2 DrawMinVector2(GUIContent label, SerializedProperty property, Vector2 min, int indentLevel = 0);
        Vector2 DrawMinVector3(GUIContent label, SerializedProperty property, Vector3 min, int indentLevel = 0);
        Vector2 DrawMinVector4(GUIContent label, SerializedProperty property, Vector4 min, int indentLevel = 0);

        Vector2 DrawMinFloatFromVector2(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            float min = 0.0f, int indentLevel = 0);

        Vector3 DrawMinFloatFromVector3(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            float min = 0.0f, int indentLevel = 0);

        Vector4 DrawMinFloatFromVector4(GUIContent label, SerializedProperty property, Vector4Param vector4Param, 
            float min = 0.0f, int indentLevel = 0);

        Vector2 DrawFloatFromVector2(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0);

        Vector3 DrawFloatFromVector3(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            FloatRange range, int indentLevel = 0);

        Vector4 DrawFloatFromVector4(GUIContent label, SerializedProperty property, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0);

        Vector4 DrawVector4Start(GUIContent label, SerializedProperty property, Vector2Range range, int indentLevel = 0);
        Vector4 DrawVector4Start(GUIContent label, SerializedProperty property, int indentLevel = 0);
        Vector4 DrawVector4End(GUIContent label, SerializedProperty property, Vector2Range range, int indentLevel = 0);
        Vector4 DrawVector4End(GUIContent label, SerializedProperty property, int indentLevel = 0);
        Color DrawColor(GUIContent label, SerializedProperty property, bool showAlpha = true, bool hdr = false, int indentLevel = 0);
        float DrawInt(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0);
        float DrawInt(GUIContent label, SerializedProperty property, int indentLevel = 0);
        Vector2Int DrawVector2Int(GUIContent label, SerializedProperty property, Vector2IntRange range, int indentLevel = 0);
        Vector2Int DrawVector2Int(GUIContent label, SerializedProperty property, int indentLevel = 0);
        Vector3Int DrawVector3Int(GUIContent label, SerializedProperty property, Vector3IntRange range, int indentLevel = 0);
        Vector3Int DrawVector3Int(GUIContent label, SerializedProperty property, int indentLevel = 0);
        float DrawNormalizedInt(GUIContent label, SerializedProperty property, int indentLevel = 0);
        Vector2Int DrawNormalizedVector2Int(GUIContent label, SerializedProperty property, int indentLevel = 0);
        Vector3Int DrawNormalizedVector3Int(GUIContent label, SerializedProperty property, int indentLevel = 0);
        int DrawMinInt(GUIContent label, SerializedProperty property, int min = 0, int indentLevel = 0);
        Vector2Int DrawMinVector2Int(GUIContent label, SerializedProperty property, Vector2Int min, int indentLevel = 0);
        Vector3Int DrawMinVector3Int(GUIContent label, SerializedProperty property, Vector3Int min, int indentLevel = 0);

        Vector2Int DrawIntFromVector2Int(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            IntRange range, int indentLevel = 0);

        Vector3Int DrawIntFromVector3Int(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            IntRange range, int indentLevel = 0);

        Vector2Int DrawNormalizedIntFromVector2Int(GUIContent label, SerializedProperty property, 
            Vector2Param vector2Param, int indentLevel = 0);

        Vector3Int DrawNormalizedIntFromVector3Int(GUIContent label, SerializedProperty property, 
            Vector3Param vector3Param, int indentLevel = 0);

        Vector2Int DrawMinIntFromVector2Int(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            int min = 0, int indentLevel = 0);

        Vector3Int DrawMinIntFromVector3Int(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            int min = 0, int indentLevel = 0);

        Texture DrawTexture(GUIContent label, SerializedProperty property, int indentLevel = 0);
        TEnum DrawEnumPopup<TEnum>(SerializedProperty property, int indentLevel = 0) where TEnum : Enum;
        TEnum DrawEnumPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0) where TEnum : Enum;
        TEnum DrawBooleanPopup<TEnum>(SerializedProperty property, int indentLevel = 0) where TEnum : Enum;
        TEnum DrawBooleanPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0) where TEnum : Enum;
        int DrawBooleanPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, int indentLevel = 0);
        TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(SerializedProperty property, string shaderGlobalKeyword, int indentLevel = 0) where TEnum : Enum;
        TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, SerializedProperty property, string shaderGlobalKeyword, int indentLevel = 0) where TEnum : Enum;

        int DrawShaderGlobalKeywordBooleanPopup(GUIContent label, SerializedProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0);

        int DrawPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, int indentLevel = 0);

        void DrawObjectField<TObject>(GUIContent label, SerializedProperty property, int indentLevel = 0,
            bool allowSceneObjects = true, Action<TObject> onChangedCallback = null) where TObject : Object;

        string DrawTextField(GUIContent label, SerializedProperty property, int indentLevel = 0);
        string DrawFolderPathField(GUIContent label, SerializedProperty property, string defaultDirectory, int indentLevel = 0);
    }
}