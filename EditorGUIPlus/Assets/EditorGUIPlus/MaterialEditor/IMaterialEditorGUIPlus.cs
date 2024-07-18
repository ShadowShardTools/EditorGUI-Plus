using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using EditorGUIPlus.MaterialEditor.AssetObject;
using EditorGUIPlus.Scopes;
using EditorGUIPlus.Scopes.Section;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.MaterialEditor
{
    public interface IMaterialEditorGUIPlus
    {
        void InitializeMaterialEditor(UnityEditor.MaterialEditor materialEditor);
        EditorGUILayout.HorizontalScope HorizontalScope(GUIStyle style = null, params GUILayoutOption[] options);
        EditorGUILayout.VerticalScope VerticalScope(GUIStyle style = null, params GUILayoutOption[] options);
        ScrollableScope ScrollViewScope(ref Vector2 scrollPosition, params GUILayoutOption[] options);
        EditorGUILayout.ToggleGroupScope ToggleGroupScope(GUIContent label, ref bool toggle);
        EditorGUILayout.ToggleGroupScope ToggleGroupScope(GUIContent label, SerializedProperty property);
        EditorGUILayout.FadeGroupScope FadeGroupScope(float value);
        HeaderScope HeaderScope(ISection section, bool spaceAtEnd = true, bool subHeader = false);
        DisabledScope DisabledScope(bool isDisabled);
        GroupScope GroupScope(GUIContent label, bool isDisabled);
        void ScrollView(Action drawCall, ref Vector2 scrollPosition, params GUILayoutOption[] options);
        void DrawVertical(GUIStyle styles, Action drawCall);
        void DrawIndented(int indentLevel, Action drawCall);
        void DrawDisabled(bool isDisabled, Action drawCall);
        void DrawIndentedDisabled(int indentLevel, bool isDisabled, Action drawCall);
        void DrawGroup(bool isDisabled, Action drawCall);
        void DrawGroup(Action drawCall);
        void DrawGroup(GUIContent label, bool isDisabled, Action drawCall);
        void DrawGroup(GUIContent label, Action drawCall);
        void DrawFoldout(GUIContent label, ref bool fold, bool toggleOnLabelClick, Action drawCall);
        void DrawFoldout(GUIContent label, ref bool fold, Action drawCall);

        float DrawSlider(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        float DrawSlider(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawVector2Sliders(GUIContent labelX, GUIContent labelY, MaterialProperty property, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector2 DrawVector2Sliders(GUIContent labelX, GUIContent labelY, MaterialProperty property,
            int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            MaterialProperty property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawFromVector4ParamSlider(GUIContent label, MaterialProperty property, Vector4Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawFromVector4ParamSlider(GUIContent label, MaterialProperty property, Vector4Param vectorParam, 
            int indentLevel = 0, Action onChangedCallback = null);

        FloatRange DrawMinMaxSlider(GUIContent label, MaterialProperty minProperty, 
            MaterialProperty maxProperty, FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        FloatRange DrawMinMaxSlider(GUIContent label, MaterialProperty minProperty, 
            MaterialProperty maxProperty, int indentLevel = 0, Action onChangedCallback = null);

        IntRange DrawMinMaxSlider(GUIContent label, ref int minProperty, ref int maxProperty, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawMinMaxVector4StartSlider(GUIContent label, MaterialProperty property, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawMinMaxVector4StartSlider(GUIContent label, MaterialProperty property, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawMinMaxVector4EndSlider(GUIContent label, MaterialProperty property, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawMinMaxVector4EndSlider(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        int DrawIntSlider(GUIContent label, MaterialProperty property, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        int DrawIntSlider(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2Int DrawVector2IntSliders(GUIContent labelX, GUIContent labelY, MaterialProperty property, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector2Int DrawVector2IntSliders(GUIContent labelX, GUIContent labelY, MaterialProperty property, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawFromVector3IntParamSlider(GUIContent label, MaterialProperty property, 
            Vector3Param vectorParam, IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawFromVector3IntParamSlider(GUIContent label, MaterialProperty property, 
            Vector3Param vectorParam, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            MaterialProperty property, IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null);

        IntRange DrawMinMaxIntSlider(GUIContent label, MaterialProperty minProperty, MaterialProperty maxProperty, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        bool DrawToggle(GUIContent label, MaterialProperty property, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null);

        bool DrawToggle(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null);

        bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, MaterialProperty property,
            string shaderLocalKeyword, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null);

        bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, MaterialProperty property,
            string shaderLocalKeyword, int indentLevel = 0, Action onChangedCallback = null);

        bool DrawShaderGlobalKeywordToggle(GUIContent label, MaterialProperty property, string shaderGlobalKeyword, 
            ToggleAlign toggleAlign = ToggleAlign.Right, int indentLevel = 0, Action onChangedCallback = null);

        bool DrawShaderGlobalKeywordToggle(GUIContent label, MaterialProperty property, string shaderGlobalKeyword, 
            int indentLevel = 0, Action onChangedCallback = null);

        float DrawFloat(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        float DrawFloat(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawVector2(GUIContent label, MaterialProperty property, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawVector2(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector3 DrawVector3(GUIContent label, MaterialProperty property, Vector3Range range, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector3 DrawVector3(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawVector4(GUIContent label, MaterialProperty property, Vector4Range range, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawVector4(GUIContent label, MaterialProperty property, int indentLevel = 0,
            Action onChangedCallback = null);

        Vector4 DrawVector4Start(GUIContent label, MaterialProperty property, Vector2Range range, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawVector4Start(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawVector4End(GUIContent label, MaterialProperty property, Vector2Range range, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawVector4End(GUIContent label, MaterialProperty property, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector2 DrawFloatFromVector2(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawFloatFromVector3(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawFloatFromVector4(GUIContent label, MaterialProperty property, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        float DrawNormalizedFloat(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawNormalizedVector2(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawNormalizedVector3(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawNormalizedVector4(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawNormalizedFloatFromVector2(GUIContent label, MaterialProperty property, 
            Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawNormalizedFloatFromVector3(GUIContent label, MaterialProperty property, 
            Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawNormalizedFloatFromVector4(GUIContent label, MaterialProperty property, 
            Vector4Param vector4Param, int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawNormalizedVector4Start(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawNormalizedVector4End(GUIContent label, MaterialProperty property, 
            int indentLevel = 0, Action onChangedCallback = null);

        float DrawMinFloat(GUIContent label, MaterialProperty property, float min = 0.0f, int indentLevel = 0,
            Action onChangedCallback = null);

        Vector2 DrawMinVector2(GUIContent label, MaterialProperty property, Vector2 min, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawMinVector3(GUIContent label, MaterialProperty property, Vector3 min, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawMinVector4(GUIContent label, MaterialProperty property, Vector4 min, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawMinFloatFromVector2(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawMinFloatFromVector3(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawMinFloatFromVector4(GUIContent label, MaterialProperty property, Vector4Param vector4Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawMinVector4Start(GUIContent label, MaterialProperty property, Vector2 min, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawMinVector4End(GUIContent label, MaterialProperty property, 
            int indentLevel = 0, Action onChangedCallback = null);

        int DrawInt(GUIContent label, MaterialProperty property, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        int DrawInt(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2Int DrawVector2Int(GUIContent label, MaterialProperty property, Vector2IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector2Int DrawVector2Int(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector3Int DrawVector3Int(GUIContent label, MaterialProperty property, Vector3IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawVector3Int(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2Int DrawIntFromVector2Int(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawIntFromVector3Int(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        int DrawNormalizedInt(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2Int DrawNormalizedVector2Int(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector3Int DrawNormalizedVector3Int(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2Int DrawNormalizedIntFromVector2Int(GUIContent label, MaterialProperty property, 
            Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawNormalizedIntFromVector3Int(GUIContent label, MaterialProperty property, 
            Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null);

        int DrawMinInt(GUIContent label, MaterialProperty property, int min = 0, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2Int DrawMinVector2Int(GUIContent label, MaterialProperty property, Vector2Int min, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawMinVector3Int(GUIContent label, MaterialProperty property, Vector3Int min, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector2Int DrawMinIntFromVector2Int(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            int min = 0, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawMinIntFromVector3Int(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            int min = 0, int indentLevel = 0, Action onChangedCallback = null);

        Color DrawColor(GUIContent label, MaterialProperty property, bool showAlpha = true, 
            bool hdr = false, int indentLevel = 0, Action onChangedCallback = null);

        Texture DrawTexture(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null);
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

        TEnum DrawEnumPopup<TEnum>(MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawEnumPopup<TEnum>(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawBooleanPopup<TEnum>(MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawBooleanPopup<TEnum>(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum;

        int DrawBooleanPopup(GUIContent label, MaterialProperty property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null);

        TEnum DrawShaderLocalKeywordBooleanPopup<TEnum>(Material material, MaterialProperty property,
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawShaderLocalKeywordBooleanPopup<TEnum>(GUIContent label, Material material, MaterialProperty property, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum;

        int DrawShaderLocalKeywordBooleanPopup(GUIContent label, Material material, MaterialProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null);

        TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(MaterialProperty property, string shaderGlobalKeyword, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, MaterialProperty property, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum;

        int DrawShaderGlobalKeywordBooleanPopup(GUIContent label, MaterialProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null);

        int DrawPopup(GUIContent label, MaterialProperty property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null);

        void DrawMaterialAssetObject(
            Material material,
            MaterialProperty assetProperty,
            MaterialProperty hashProperty,
            Func<MaterialAssetObject> drawObjectField,
            int indentLevel = 0,
            Action onChangedCallback = null);

        T GetMaterialAssetObjectFromGuid<T>(string guid) where T : MaterialAssetObject;
        GUIContent DrawLabel(GUIContent label, GUIContent label2, int indentLevel = 0);
        GUIContent DrawLabel(GUIContent label, int indentLevel = 0);
        bool DrawLinkText(GUIContent label, int indentLevel = 0);
        bool DrawLinkText(GUIContent label, string url, int indentLevel = 0);
        void DrawHelpBox(string message, MessageType type, bool wide = true, int indentLevel = 0);
        void DrawNeutralBox(string message, bool wide = true, int indentLevel = 0);
        void DrawInfoBox(string message, bool wide = true, int indentLevel = 0);
        void DrawWarningBox(string message, bool wide = true, int indentLevel = 0);
        void DrawErrorBox(string message, bool wide = true, int indentLevel = 0);
        void Space();
        void Space(float width);
        void Space(float width, bool expand);
    }
}