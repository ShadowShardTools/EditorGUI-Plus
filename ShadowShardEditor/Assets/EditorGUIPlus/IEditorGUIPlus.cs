using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using EditorGUIPlus.Scopes;
using EditorGUIPlus.Scopes.Section;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EditorGUIPlus
{
    public interface IEditorGUIPlus
    {
        EditorGUILayout.HorizontalScope HorizontalScope(GUIStyle style = null, params GUILayoutOption[] options);
        EditorGUILayout.VerticalScope VerticalScope(GUIStyle style = null, params GUILayoutOption[] options);
        EditorGUILayout.ScrollViewScope ScrollViewScope(ref Vector2 scrollPosition, params GUILayoutOption[] options);
        EditorGUILayout.ToggleGroupScope ToggleGroupScope(GUIContent label, ref bool toggle);
        EditorGUILayout.FadeGroupScope FadeGroupScope(float value);
        HeaderScope HeaderScope(ISection section, bool spaceAtEnd = true, bool subHeader = false);
        IntendedScope IntendedScope(int indentLevel);
        DisabledScope DisabledScope(bool isDisabled);
        IntendedDisabledScope IndentedDisabledScope(int indentLevel, bool isDisabled);
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

        float DrawSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        float DrawSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        void DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        void DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, 
            int indentLevel = 0, Action onChangedCallback = null);

        void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null);

        FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, 
            SerializedProperty maxProperty, FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, 
            SerializedProperty maxProperty, int indentLevel = 0, Action onChangedCallback = null);

        FloatRange DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null);

        FloatRange DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, 
            int indentLevel = 0, Action onChangedCallback = null);

        FloatRange DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null);

        FloatRange DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        int DrawIntSlider(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        int DrawIntSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        void DrawFromVector3IntParamSlider<TProperty>(GUIContent label, TProperty property, 
            Vector3Param vectorParam, IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        void DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        bool DrawToggle(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        bool DrawShaderGlobalKeywordToggle(GUIContent label, SerializedProperty property, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null);

        float DrawFloat(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawVector2(GUIContent label, SerializedProperty property, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector3 DrawVector3(GUIContent label, SerializedProperty property, Vector3Range range, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawVector4(GUIContent label, SerializedProperty property, Vector4Range range, int indentLevel = 0, 
            Action onChangedCallback = null);

        float DrawFloat(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawVector2(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector3 DrawVector3(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawVector4(GUIContent label, SerializedProperty property, int indentLevel = 0,
            Action onChangedCallback = null);

        float DrawNormalizedFloat(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawNormalizedVector2(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawNormalizedVector3(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawNormalizedVector4(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawNormalizedFloatFromVector2(GUIContent label, SerializedProperty property, 
            Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawNormalizedFloatFromVector3(GUIContent label, SerializedProperty property, 
            Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawNormalizedFloatFromVector4(GUIContent label, SerializedProperty property, 
            Vector4Param vector4Param, int indentLevel = 0, Action onChangedCallback = null);

        float DrawMinFloat(GUIContent label, SerializedProperty property, float min = 0.0f, int indentLevel = 0,
            Action onChangedCallback = null);

        Vector2 DrawMinVector2(GUIContent label, SerializedProperty property, Vector2 min, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawMinVector3(GUIContent label, SerializedProperty property, Vector3 min, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawMinVector4(GUIContent label, SerializedProperty property, Vector4 min, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawMinFloatFromVector2(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawMinFloatFromVector3(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawMinFloatFromVector4(GUIContent label, SerializedProperty property, Vector4Param vector4Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null);

        Vector2 DrawFloatFromVector2(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawFloatFromVector3(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawFloatFromVector4(GUIContent label, SerializedProperty property, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawVector4Start(GUIContent label, SerializedProperty property, Vector2Range range, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawVector4Start(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawVector4End(GUIContent label, SerializedProperty property, Vector2Range range, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawVector4End(GUIContent label, SerializedProperty property, 
            int indentLevel = 0, Action onChangedCallback = null);

        Color DrawColor(GUIContent label, SerializedProperty property, bool showAlpha = true, 
            bool hdr = false, int indentLevel = 0, Action onChangedCallback = null);

        float DrawInt(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2Int DrawVector2Int(GUIContent label, SerializedProperty property, Vector2IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawVector3Int(GUIContent label, SerializedProperty property, Vector3IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null);

        float DrawInt(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2Int DrawVector2Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector3Int DrawVector3Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        float DrawNormalizedInt(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2Int DrawNormalizedVector2Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector3Int DrawNormalizedVector3Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null);

        int DrawMinInt(GUIContent label, SerializedProperty property, int min = 0, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2Int DrawMinVector2Int(GUIContent label, SerializedProperty property, Vector2Int min, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawMinVector3Int(GUIContent label, SerializedProperty property, Vector3Int min, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector2Int DrawIntFromVector2Int(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawIntFromVector3Int(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector2Int DrawNormalizedIntFromVector2Int(GUIContent label, SerializedProperty property, 
            Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawNormalizedIntFromVector3Int(GUIContent label, SerializedProperty property, 
            Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null);

        Vector2Int DrawMinIntFromVector2Int(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            int min = 0, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawMinIntFromVector3Int(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            int min = 0, int indentLevel = 0, Action onChangedCallback = null);

        Texture DrawTexture(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null);

        TEnum DrawEnumPopup<TEnum>(SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawEnumPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawBooleanPopup<TEnum>(SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawBooleanPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(SerializedProperty property, string shaderGlobalKeyword, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, SerializedProperty property, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum;

        int DrawPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null);

        int DrawBooleanPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null);

        int DrawShaderGlobalKeywordBooleanPopup(GUIContent label, SerializedProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null);

        void DrawObjectField<TObject>(GUIContent label, SerializedProperty property, int indentLevel = 0,
            bool allowSceneObjects = true, Action<TObject> onChangedCallback = null) where TObject : Object;

        string DrawTextField(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null);

        string DrawFolderPathField(GUIContent label, SerializedProperty property, string defaultDirectory, 
            int indentLevel = 0, Action onChangedCallback = null);

        AnimationCurve DrawAnimationCurve(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null);
    }
}