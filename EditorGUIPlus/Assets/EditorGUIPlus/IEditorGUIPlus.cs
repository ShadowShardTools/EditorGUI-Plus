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
        float DrawSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        float DrawSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        float DrawSlider(GUIContent label, float sliderValue, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        float DrawSlider(GUIContent label, float sliderValue, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawFromVector2ParamSlider(GUIContent label, SerializedProperty property, Vector2Param vectorParam, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2 DrawFromVector2ParamSlider(GUIContent label, SerializedProperty property, Vector2Param vectorParam, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2 DrawFromVector2ParamSlider(GUIContent label, Vector2 vector2, Vector2Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector2 DrawFromVector2ParamSlider(GUIContent label, Vector2 vector2, Vector2Param vectorParam, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3 DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3 DrawFromVector3ParamSlider(GUIContent label, Vector3 vector3, Vector3Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawFromVector3ParamSlider(GUIContent label, Vector3 vector3, Vector3Param vectorParam, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3 DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3 DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, Vector3 vector3, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, Vector3 vector3, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawFromVector4ParamSlider(GUIContent label, SerializedProperty property, Vector4Param vectorParam, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawFromVector4ParamSlider(GUIContent label, SerializedProperty property, Vector4Param vectorParam, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawFromVector4ParamSlider(GUIContent label, Vector4 vector4, Vector4Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawFromVector4ParamSlider(GUIContent label, Vector4 vector4, Vector4Param vectorParam, 
            int indentLevel = 0, Action onChangedCallback = null);

        FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, 
            SerializedProperty maxProperty, FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, 
            SerializedProperty maxProperty, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        FloatRange DrawMinMaxSlider(GUIContent label, ref float minProperty, ref float maxProperty, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        FloatRange DrawMinMaxSlider(GUIContent label, ref float minProperty, ref float maxProperty, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, FloatRange range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawMinMaxVector4StartSlider(GUIContent label, Vector4 vector4, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawMinMaxVector4StartSlider(GUIContent label, Vector4 vector4, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, FloatRange range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawMinMaxVector4EndSlider(GUIContent label, Vector4 vector4, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawMinMaxVector4EndSlider(GUIContent label, Vector4 vector4, int indentLevel = 0, 
            Action onChangedCallback = null);

        int DrawIntSlider(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        int DrawIntSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        int DrawIntSlider(GUIContent label, int sliderValue, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        int DrawIntSlider(GUIContent label, int sliderValue, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2Int DrawFromVector2IntParamSlider(GUIContent label, Vector2Int vector2Int, 
            Vector2Param vectorParam, IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, 
            Action onChangedCallback = null);

        Vector2Int DrawFromVector2IntParamSlider(GUIContent label, Vector2Int vector2Int, 
            Vector2Param vectorParam, int indentLevel = 0, bool applyModifiedProperties = false, 
            Action onChangedCallback = null);

        Vector2Int DrawFromVector2IntParamSlider(GUIContent label, Vector2Int vector2Int, 
            Vector2Param vectorParam, IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector2Int DrawFromVector2IntParamSlider(GUIContent label, Vector2Int vector2Int, 
            Vector2Param vectorParam, int indentLevel = 0, Action onChangedCallback = null);

        Vector2Int DrawVector2IntSliders(GUIContent labelX, GUIContent labelY, SerializedProperty property, 
            IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2Int DrawVector2IntSliders(GUIContent labelX, GUIContent labelY, SerializedProperty property,
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2Int DrawVector2IntSliders(GUIContent labelX, GUIContent labelY, Vector2Int vector2Int,
            IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector2Int DrawVector2IntSliders(GUIContent labelX, GUIContent labelY, Vector2Int vector2Int, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawFromVector3IntParamSlider(GUIContent label, SerializedProperty property, 
            Vector3Param vectorParam, IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3Int DrawFromVector3IntParamSlider(GUIContent label, SerializedProperty property, 
            Vector3Param vectorParam, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3Int DrawFromVector3IntParamSlider(GUIContent label, Vector3Int vector3Int, 
            Vector3Param vectorParam, IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawFromVector3IntParamSlider(GUIContent label, Vector3Int vector3Int, 
            Vector3Param vectorParam, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3Int DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3Int DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, Vector3Int vector3Int,
            IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, Vector3Int vector3Int, 
            int indentLevel = 0, Action onChangedCallback = null);

        IntRange DrawMinMaxIntSlider(GUIContent label, SerializedProperty minProperty, SerializedProperty maxProperty, 
            IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        IntRange DrawMinMaxIntSlider(GUIContent label, SerializedProperty minProperty, SerializedProperty maxProperty, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        IntRange DrawMinMaxIntSlider(GUIContent label, ref int minProperty, ref int maxProperty, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        IntRange DrawMinMaxIntSlider(GUIContent label, ref int minProperty, ref int maxProperty, int indentLevel = 0, 
            Action onChangedCallback = null);

        bool DrawToggle(GUIContent label, SerializedProperty property, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        bool DrawToggle(GUIContent label, SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        bool DrawToggle(GUIContent label, bool property, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null);

        bool DrawToggle(GUIContent label, bool property, int indentLevel = 0, Action onChangedCallback = null);

        bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, SerializedProperty property,
            string shaderLocalKeyword, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, SerializedProperty property,
            string shaderLocalKeyword, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, bool property,
            string shaderLocalKeyword, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null);

        bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, bool property,
            string shaderLocalKeyword, int indentLevel = 0, Action onChangedCallback = null);

        bool DrawShaderGlobalKeywordToggle(GUIContent label, SerializedProperty property, string shaderGlobalKeyword, 
            ToggleAlign toggleAlign = ToggleAlign.Right, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        bool DrawShaderGlobalKeywordToggle(GUIContent label, SerializedProperty property, string shaderGlobalKeyword, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        bool DrawShaderGlobalKeywordToggle(GUIContent label, bool property, string shaderGlobalKeyword, 
            ToggleAlign toggleAlign = ToggleAlign.Right, int indentLevel = 0, Action onChangedCallback = null);

        bool DrawShaderGlobalKeywordToggle(GUIContent label, bool property, string shaderGlobalKeyword, 
            int indentLevel = 0, Action onChangedCallback = null);

        float DrawFloat(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        float DrawFloat(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        float DrawFloat(GUIContent label, float property, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        float DrawFloat(GUIContent label, float property, int indentLevel = 0, 
            Action onChangedCallback = null);

        double DrawDouble(GUIContent label, SerializedProperty property, DoubleRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        double DrawDouble(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        double DrawDouble(GUIContent label, double property, DoubleRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        double DrawDouble(GUIContent label, double property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawVector2(GUIContent label, SerializedProperty property, Vector2Range range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2 DrawVector2(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2 DrawVector2(GUIContent label, Vector2 vector2, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawVector2(GUIContent label, Vector2 vector2, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector3 DrawVector3(GUIContent label, SerializedProperty property, Vector3Range range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3 DrawVector3(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3 DrawVector3(GUIContent label, Vector3 vector3, Vector3Range range, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector3 DrawVector3(GUIContent label, Vector3 vector3, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawVector4(GUIContent label, SerializedProperty property, Vector4Range range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawVector4(GUIContent label, SerializedProperty property, int indentLevel = 0,
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawVector4(GUIContent label, Vector4 vector4, Vector4Range range, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawVector4(GUIContent label, Vector4 vector4, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawVector4Start(GUIContent label, SerializedProperty property, Vector2Range range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawVector4Start(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawVector4Start(GUIContent label, Vector4 vector4, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawVector4Start(GUIContent label, Vector4 vector4, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawVector4End(GUIContent label, SerializedProperty property, Vector2Range range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawVector4End(GUIContent label, SerializedProperty property, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawVector4End(GUIContent label, Vector4 vector4, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawVector4End(GUIContent label, Vector4 vector4, int indentLevel = 0, Action onChangedCallback = null);

        Vector2 DrawFloatFromVector2(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2 DrawFloatFromVector2(GUIContent label, Vector2 vector2, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawFloatFromVector3(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3 DrawFloatFromVector3(GUIContent label, Vector3 vector3, Vector3Param vector3Param, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawFloatFromVector4(GUIContent label, SerializedProperty property, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawFloatFromVector4(GUIContent label, Vector4 vector4, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        float DrawNormalizedFloat(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        float DrawNormalizedFloat(GUIContent label, float property, int indentLevel = 0, 
            Action onChangedCallback = null);

        double DrawNormalizedDouble(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        double DrawNormalizedDouble(GUIContent label, double property, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawNormalizedVector2(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2 DrawNormalizedVector2(GUIContent label, Vector2 vector2, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector3 DrawNormalizedVector3(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3 DrawNormalizedVector3(GUIContent label, Vector3 vector3, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawNormalizedVector4(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawNormalizedVector4(GUIContent label, Vector4 vector4, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawNormalizedFloatFromVector2(GUIContent label, SerializedProperty property, 
            Vector2Param vector2Param, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2 DrawNormalizedFloatFromVector2(GUIContent label, Vector2 vector2, Vector2Param vector2Param, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawNormalizedFloatFromVector3(GUIContent label, SerializedProperty property, 
            Vector3Param vector3Param, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3 DrawNormalizedFloatFromVector3(GUIContent label, Vector3 vector3, Vector3Param vector3Param, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawNormalizedFloatFromVector4(GUIContent label, SerializedProperty property, 
            Vector4Param vector4Param, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawNormalizedFloatFromVector4(GUIContent label, Vector4 vector4, Vector4Param vector4Param, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawNormalizedVector4Start(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawNormalizedVector4Start(GUIContent label, Vector4 vector4, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawNormalizedVector4End(GUIContent label, SerializedProperty property, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawNormalizedVector4End(GUIContent label, Vector4 vector4, int indentLevel = 0, 
            Action onChangedCallback = null);

        float DrawMinFloat(GUIContent label, SerializedProperty property, float min = 0.0f, int indentLevel = 0,
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        float DrawMinFloat(GUIContent label, float property, float min = 0.0f, int indentLevel = 0,
            Action onChangedCallback = null);

        double DrawMinDouble(GUIContent label, SerializedProperty property, double min = 0.0, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        double DrawMinDouble(GUIContent label, double property, double min = 0.0, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawMinVector2(GUIContent label, SerializedProperty property, Vector2 min, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2 DrawMinVector2(GUIContent label, Vector2 vector2, Vector2 min, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector3 DrawMinVector3(GUIContent label, SerializedProperty property, Vector3 min, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3 DrawMinVector3(GUIContent label, Vector3 vector3, Vector3 min, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector4 DrawMinVector4(GUIContent label, SerializedProperty property, Vector4 min, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawMinVector4(GUIContent label, Vector4 vector4, Vector4 min, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2 DrawMinFloatFromVector2(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            float min = 0.0f, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2 DrawMinFloatFromVector2(GUIContent label, Vector2 vector2, Vector2Param vector2Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null);

        Vector3 DrawMinFloatFromVector3(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            float min = 0.0f, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3 DrawMinFloatFromVector3(GUIContent label, Vector3 vector3, Vector3Param vector3Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawMinFloatFromVector4(GUIContent label, SerializedProperty property, Vector4Param vector4Param, 
            float min = 0.0f, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawMinFloatFromVector4(GUIContent label, Vector4 vector4, Vector4Param vector4Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null);

        Vector4 DrawMinVector4Start(GUIContent label, SerializedProperty property, Vector2 min, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector4 DrawMinVector4Start(GUIContent label, Vector4 vector4, Vector2 min, int indentLevel = 0, 
            Action onChangedCallback = null);

        Bounds DrawBoundsField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Bounds DrawBoundsField(GUIContent label, Bounds bounds, int indentLevel = 0, Action onChangedCallback = null);

        Rect DrawRectField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Rect DrawRectField(GUIContent label, Rect rect, int indentLevel = 0, Action onChangedCallback = null);

        int DrawInt(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        int DrawInt(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        int DrawInt(GUIContent label, int property, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        int DrawInt(GUIContent label, int property, int indentLevel = 0, Action onChangedCallback = null);

        long DrawLong(GUIContent label, SerializedProperty property, LongRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        long DrawLong(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        long DrawLong(GUIContent label, long property, LongRange range, int indentLevel = 0, 
            Action onChangedCallback = null);

        long DrawLong(GUIContent label, long property, int indentLevel = 0, Action onChangedCallback = null);

        Vector2Int DrawVector2Int(GUIContent label, SerializedProperty property, Vector2IntRange range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2Int DrawVector2Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2Int DrawVector2Int(GUIContent label, Vector2Int vector2Int, Vector2IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector2Int DrawVector2Int(GUIContent label, Vector2Int vector2Int, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector3Int DrawVector3Int(GUIContent label, SerializedProperty property, Vector3IntRange range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3Int DrawVector3Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3Int DrawVector3Int(GUIContent label, Vector3Int vector3Int, Vector3IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawVector3Int(GUIContent label, Vector3Int vector3Int, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2Int DrawIntFromVector2Int(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2Int DrawIntFromVector2Int(GUIContent label, Vector2Int vector2Int, Vector2Param vector2Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawIntFromVector3Int(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3Int DrawIntFromVector3Int(GUIContent label, Vector3Int vector3Int, Vector3Param vector3Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null);

        int DrawNormalizedInt(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        int DrawNormalizedInt(GUIContent label, int property, int indentLevel = 0, Action onChangedCallback = null);

        long DrawNormalizedLong(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        long DrawNormalizedLong(GUIContent label, SerializedProperty property, long min = 0, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        long DrawNormalizedLong(GUIContent label, long property, int indentLevel = 0, Action onChangedCallback = null);

        long DrawNormalizedLong(GUIContent label, long property, long min = 0, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2Int DrawNormalizedVector2Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2Int DrawNormalizedVector2Int(GUIContent label, Vector2Int vector2Int, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector3Int DrawNormalizedVector3Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3Int DrawNormalizedVector3Int(GUIContent label, ref Vector3Int vector3Int, int indentLevel = 0, 
            Action onChangedCallback = null);

        Vector2Int DrawNormalizedIntFromVector2Int(GUIContent label, SerializedProperty property, 
            Vector2Param vector2Param, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2Int DrawNormalizedIntFromVector2Int(GUIContent label, Vector2Int vector2Int, 
            Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawNormalizedIntFromVector3Int(GUIContent label, SerializedProperty property, 
            Vector3Param vector3Param, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3Int DrawNormalizedIntFromVector3Int(GUIContent label, ref Vector3Int vector3Int, 
            Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null);

        int DrawMinInt(GUIContent label, SerializedProperty property, int min = 0, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        int DrawMinInt(GUIContent label, int property, int min = 0, int indentLevel = 0, Action onChangedCallback = null);

        Vector2Int DrawMinVector2Int(GUIContent label, SerializedProperty property, Vector2Int min, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2Int DrawMinVector2Int(GUIContent label, Vector2Int vector2Int, Vector2Int min, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawMinVector3Int(GUIContent label, SerializedProperty property, Vector3Int min, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3Int DrawMinVector3Int(GUIContent label, Vector3Int vector3Int, Vector3Int min, 
            int indentLevel = 0, Action onChangedCallback = null);

        Vector2Int DrawMinIntFromVector2Int(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            int min = 0, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector2Int DrawMinIntFromVector2Int(GUIContent label, Vector2Int vector2Int, Vector2Param vector2Param, 
            int min = 0, int indentLevel = 0, Action onChangedCallback = null);

        Vector3Int DrawMinIntFromVector3Int(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            int min = 0, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Vector3Int DrawMinIntFromVector3Int(GUIContent label, ref Vector3Int vector3Int, Vector3Param vector3Param, 
            int min = 0, int indentLevel = 0, Action onChangedCallback = null);

        BoundsInt DrawIntBoundsField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        BoundsInt DrawIntBoundsField(GUIContent label, BoundsInt boundsInt, int indentLevel = 0, Action onChangedCallback = null);

        RectInt DrawIntRectField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        RectInt DrawIntRectField(GUIContent label, RectInt rectInt, int indentLevel = 0, Action onChangedCallback = null);

        Color DrawColor(GUIContent label, SerializedProperty property, bool showAlpha = true, 
            bool hdr = false, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Color DrawColor(GUIContent label,  Color color, bool showAlpha = true, 
            bool hdr = false, int indentLevel = 0, Action onChangedCallback = null);

        Gradient DrawGradient(GUIContent label, SerializedProperty property, bool hdr = false, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Gradient DrawGradient(GUIContent label, Gradient gradient, bool hdr = false, 
            int indentLevel = 0, Action onChangedCallback = null);

        Texture DrawTexture(GUIContent label, SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);
        Texture DrawTexture(GUIContent label, Texture texture, int indentLevel = 0, Action onChangedCallback = null);

        TEnum DrawEnumPopup<TEnum>(SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawEnumPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) where TEnum : Enum;

        void DrawEnumPopup(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        TEnum DrawEnumPopup<TEnum>(TEnum property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawEnumPopup<TEnum>(GUIContent label, TEnum property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawEnumFlagsField<TEnum>(GUIContent label, SerializedProperty property, bool includeObsolete = false,  
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawEnumFlagsField<TEnum>(GUIContent label, TEnum property, bool includeObsolete = false,  
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawBooleanPopup<TEnum>(SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawBooleanPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) where TEnum : Enum;

        int DrawBooleanPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        TEnum DrawBooleanPopup<TEnum>(TEnum property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawBooleanPopup<TEnum>(GUIContent label, TEnum property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum;

        int DrawBooleanPopup<TEnum>(GUIContent label, TEnum property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(SerializedProperty property, string shaderGlobalKeyword, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, SerializedProperty property, 
            string shaderGlobalKeyword, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) where TEnum : Enum;

        int DrawShaderGlobalKeywordBooleanPopup(GUIContent label, SerializedProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(TEnum property, string shaderGlobalKeyword, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum;

        TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, TEnum property, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum;

        int DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, TEnum property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum;

        int DrawPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        int DrawPopup<TEnum>(GUIContent label, TEnum property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum;

        string DrawTagField(GUIContent label, SerializedProperty property,
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        string DrawTagField(GUIContent label, string property,
            int indentLevel = 0, Action onChangedCallback = null);

        int DrawLayerField(GUIContent label, SerializedProperty property,
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        int DrawLayerField(GUIContent label, int layer,
            int indentLevel = 0, Action onChangedCallback = null);

        int DrawMaskField(GUIContent label, SerializedProperty property, string[] displayedOptions, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        int DrawMaskField(GUIContent label, int mask, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null);

        void DrawObjectField<TObject>(GUIContent label, SerializedProperty property, int indentLevel = 0,
            bool allowSceneObjects = true, bool applyModifiedProperties = false, Action<TObject> onChangedCallback = null) where TObject : Object;

        void DrawObjectField(GUIContent label, SerializedProperty property, int indentLevel = 0,
            bool allowSceneObjects = true, bool applyModifiedProperties = false, Action onChangedCallback = null);

        Object DrawObjectField(GUIContent label, Object objectProperty, int indentLevel = 0,
            bool allowSceneObjects = true, Action<Object> onChangedCallback = null);

        string DrawTextField(GUIContent label, SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);
        string DrawTextField(GUIContent label, string text, int indentLevel = 0, Action onChangedCallback = null);
        string DrawTextArea(GUIContent label, SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);
        string DrawTextArea(SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);
        string DrawTextArea(GUIContent label, string text, int indentLevel = 0, Action onChangedCallback = null);
        string DrawTextArea(string text, int indentLevel = 0, Action onChangedCallback = null);
        string DrawPasswordField(GUIContent label, SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);
        string DrawPasswordField(GUIContent label, string password, int indentLevel = 0, Action onChangedCallback = null);

        string DrawFolderPathField(GUIContent label, SerializedProperty property, string defaultDirectory, 
            string defaultName, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        string DrawFolderPathField(GUIContent label, string path, string defaultDirectory, string defaultName, 
            int indentLevel = 0, Action onChangedCallback = null);

        AnimationCurve DrawAnimationCurve(GUIContent label, SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null);

        AnimationCurve DrawAnimationCurve(GUIContent label, AnimationCurve curve, int indentLevel = 0, 
            Action onChangedCallback = null);

        void DrawField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null);

        TType DrawField<TType>(GUIContent label, TType value, int indentLevel = 0, Action onChangedCallback = null);
        void InitializeBaseEditors();
        EditorGUILayout.HorizontalScope HorizontalScope(GUIStyle style = null, params GUILayoutOption[] options);
        EditorGUILayout.VerticalScope VerticalScope(GUIStyle style = null, params GUILayoutOption[] options);
        ScrollableScope ScrollViewScope(ref Vector2 scrollPosition, params GUILayoutOption[] options);
        EditorGUILayout.ToggleGroupScope ToggleGroupScope(GUIContent label, ref bool toggle);
        EditorGUILayout.ToggleGroupScope ToggleGroupScope(GUIContent label, SerializedProperty property);
        EditorGUILayout.FadeGroupScope FadeGroupScope(float value);
        HeaderScope HeaderScope(ISection section, bool spaceAtEnd = true, bool subHeader = false);
        DisabledScope DisabledScope(bool isDisabled);
        GroupScope GroupScope(GUIContent label, bool isDisabled);
        BuildTargetSelectionScope BuildTargetSelectionScope();
        void ScrollView(Action drawCall, ref Vector2 scrollPosition, params GUILayoutOption[] options);
        void DrawVertical(GUIStyle styles, Action drawCall);
        void DrawIndented(int indentLevel, Action drawCall);
        void DrawDisabled(bool isDisabled, Action drawCall);
        void DrawIndentedDisabled(int indentLevel, bool isDisabled, Action drawCall);
        void DrawGroup(bool isDisabled, Action drawCall);
        void DrawGroup(Action drawCall);
        void DrawGroup(GUIContent label, bool isDisabled, Action drawCall);
        void DrawGroup(GUIContent label, Action drawCall);
        void DrawInspectorTitlebar(ref bool fold, Object[] targetObjs, Action drawCall);
        void DrawFoldout(GUIContent label, ref bool fold, bool toggleOnLabelClick, Action drawCall);
        void DrawFoldout(GUIContent label, ref bool fold, Action drawCall);

        Vector2 DrawVector2Sliders(GUIContent labelX, GUIContent labelY, Vector2 vector2, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null);

        Vector2 DrawVector2Sliders(GUIContent labelX, GUIContent labelY, Vector2 vector2, int indentLevel = 0, 
            Action onChangedCallback = null);

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