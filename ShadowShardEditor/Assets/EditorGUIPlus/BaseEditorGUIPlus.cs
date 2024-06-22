using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using EditorGUIPlus.EditorModules;
using EditorGUIPlus.EditorModules.Base;
using EditorGUIPlus.Scopes;
using EditorGUIPlus.Scopes.Section;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
using TextEditor = EditorGUIPlus.EditorModules.Base.TextEditor;
using ToggleEditor = EditorGUIPlus.EditorModules.Base.ToggleEditor;

namespace EditorGUIPlus
{
    public class BaseEditorGUIPlus
    {
        private readonly GroupEditor _groupEditor;
        private readonly SliderEditor _sliderEditor;
        private readonly SliderIntEditor _sliderIntEditor;
        private readonly ToggleEditor _toggleEditor;
        private readonly VectorEditor _vectorEditor;
        private readonly VectorIntEditor _vectorIntEditor;
        private readonly ColorEditor _colorEditor;
        private readonly TextureEditor _textureEditor;
        private readonly PopupEditor _popupEditor;
        private readonly ObjectEditor _objectEditor;
        private readonly TextEditor _textEditor;
        private readonly CurveEditor _curveEditor;
        private readonly MessageEditor _messageEditor;
        
        public BaseEditorGUIPlus()
        {
            _groupEditor = new GroupEditor();
            _sliderEditor = new SliderEditor(_groupEditor);
            _sliderIntEditor = new SliderIntEditor(_groupEditor);
            _toggleEditor = new ToggleEditor(_groupEditor);
            _vectorEditor = new VectorEditor(_groupEditor);
            _vectorIntEditor = new VectorIntEditor(_groupEditor);
            _colorEditor = new ColorEditor(_groupEditor);
            _textureEditor = new TextureEditor(_groupEditor);
            _popupEditor = new PopupEditor(_groupEditor);
            _objectEditor = new ObjectEditor(_groupEditor);
            _textEditor = new TextEditor(_groupEditor);
            _curveEditor = new CurveEditor(_groupEditor);
            _messageEditor = new MessageEditor(_groupEditor);
        }

        #region GroupScopesEditorRegion
        public EditorGUILayout.HorizontalScope HorizontalScope(GUIStyle style = null, params GUILayoutOption[] options) =>
            _groupEditor.HorizontalScope(style, options);
        
        public EditorGUILayout.VerticalScope VerticalScope(GUIStyle style = null, params GUILayoutOption[] options) =>
            _groupEditor.VerticalScope(style, options);
        
        public ScrollableScope ScrollViewScope(ref Vector2 scrollPosition, params GUILayoutOption[] options) =>
            _groupEditor.ScrollViewScope(ref scrollPosition, options);
        
        public EditorGUILayout.ToggleGroupScope ToggleGroupScope(GUIContent label, ref bool toggle) =>
            _groupEditor.ToggleGroupScope(label, ref toggle);
        
        public EditorGUILayout.ToggleGroupScope ToggleGroupScope(GUIContent label, SerializedProperty property) =>
            _groupEditor.ToggleGroupScope(label, property);

        public EditorGUILayout.FadeGroupScope FadeGroupScope(float value) =>
            _groupEditor.FadeGroupScope(value);
        
        public HeaderScope HeaderScope(ISection section, bool spaceAtEnd = true, bool subHeader = false) =>
            _groupEditor.HeaderScope(section, spaceAtEnd, subHeader);
        
        public DisabledScope DisabledScope(bool isDisabled) =>
            _groupEditor.DisabledScope(isDisabled);
        
        public GroupScope GroupScope(GUIContent label, bool isDisabled) =>
            _groupEditor.GroupScope(label, isDisabled);
        
        public BuildTargetSelectionScope BuildTargetSelectionScope() =>
            _groupEditor.BuildTargetSelectionScope();
        
        #endregion
        
        #region GroupEditorRegion
        
        public void ScrollView(Action drawCall, ref Vector2 scrollPosition, params GUILayoutOption[] options) =>
            _groupEditor.DrawScrollView(drawCall, ref scrollPosition, options);
        
        public void DrawVertical(GUIStyle styles, Action drawCall) =>
            _groupEditor.DrawVertical(styles, drawCall);
        
        public void DrawIndented(int indentLevel, Action drawCall) =>
            _groupEditor.DrawIndented(indentLevel, drawCall);
        
        public void DrawDisabled(bool isDisabled, Action drawCall) =>
            _groupEditor.DrawDisabled(isDisabled, drawCall);
        
        public void DrawIndentedDisabled(int indentLevel, bool isDisabled, Action drawCall) =>
            _groupEditor.DrawIndentedDisabled(indentLevel, isDisabled, drawCall);
        
        public void DrawGroup(bool isDisabled, Action drawCall) =>
            _groupEditor.DrawGroup(isDisabled, drawCall);
        
        public void DrawGroup(Action drawCall) =>
            _groupEditor.DrawGroup(false, drawCall);
        
        public void DrawGroup(GUIContent label, bool isDisabled, Action drawCall) =>
            _groupEditor.DrawGroup(label, isDisabled, drawCall);
        
        public void DrawGroup(GUIContent label, Action drawCall) =>
            _groupEditor.DrawGroup(label, false, drawCall);
        
        public void DrawInspectorTitlebar(ref bool fold, Object[] targetObjs, Action drawCall) =>
            _groupEditor.DrawInspectorTitlebar(ref fold, targetObjs, drawCall);
        
        public void DrawFoldout(GUIContent label, ref bool fold, bool toggleOnLabelClick, Action drawCall) =>
            _groupEditor.DrawFoldout(label, ref fold, toggleOnLabelClick, drawCall);
        
        public void DrawFoldout(GUIContent label, ref bool fold, Action drawCall) =>
            _groupEditor.DrawFoldout(label, ref fold, false, drawCall);
        
        #endregion

        #region SliderEditorRegion
        
        public float DrawSlider(GUIContent label, ref float property, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderEditor.DrawSlider(label, ref property, range, indentLevel, onChangedCallback);
        
        public float DrawSlider(GUIContent label, ref float property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderEditor.DrawSlider(label, ref property, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3 DrawFromVector3ParamSlider(GUIContent label, ref Vector3 property, Vector3Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawFromVector3ParamSlider(label, ref property, vectorParam, range, indentLevel, onChangedCallback);
        
        public Vector3 DrawFromVector3ParamSlider(GUIContent label, ref Vector3 property, Vector3Param vectorParam, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawFromVector3ParamSlider(label, ref property, vectorParam, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            ref Vector3 property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawVector3Sliders(labelX, labelY, labelZ, ref property, range, indentLevel, onChangedCallback);
        
        public void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            ref Vector3 property, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawVector3Sliders(labelX, labelY, labelZ, ref property, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, ref float minProperty, 
            ref float maxProperty, FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxSlider(label, ref minProperty, ref maxProperty, range, indentLevel, onChangedCallback);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, ref float minProperty, 
            ref float maxProperty, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxSlider(label, ref minProperty, ref maxProperty, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public FloatRange DrawMinMaxVector4StartSlider(GUIContent label, ref Vector4 property, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxVector4StartSlider(label, ref property, range, indentLevel, onChangedCallback);
        
        public FloatRange DrawMinMaxVector4StartSlider(GUIContent label, ref Vector4 property, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxVector4StartSlider(label, ref property, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public FloatRange DrawMinMaxVector4EndSlider(GUIContent label, ref Vector4 property, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxVector4EndSlider(label, ref property, range, indentLevel, onChangedCallback);
        
        public FloatRange DrawMinMaxVector4EndSlider(GUIContent label, ref Vector4 property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxVector4EndSlider(label, ref property, FloatRange.Normalized, indentLevel, onChangedCallback);

        #endregion
        
        #region SliderIntEditorRegion

        public int DrawIntSlider(GUIContent label, ref int property, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderIntEditor.DrawIntSlider(label, ref property, range, indentLevel, onChangedCallback);
        
        public int DrawIntSlider(GUIContent label, ref int property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderIntEditor.DrawIntSlider(label, ref property, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3Int DrawFromVector3IntParamSlider(GUIContent label, ref Vector3Int property, 
            Vector3Param vectorParam, IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderIntEditor.DrawFromVector3IntParamSlider(label, ref property, vectorParam, range, indentLevel, onChangedCallback);
        
        public Vector3Int DrawFromVector3IntParamSlider(GUIContent label, ref Vector3Int property, 
            Vector3Param vectorParam, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderIntEditor.DrawFromVector3IntParamSlider(label, ref property, vectorParam, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public void DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            ref Vector3Int property, IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderIntEditor.DrawVector3IntSliders(labelX, labelY, labelZ, ref property, range, indentLevel, onChangedCallback);
        
        public void DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            ref Vector3Int property, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderIntEditor.DrawVector3IntSliders(labelX, labelY, labelZ, ref property, IntRange.Normalized, indentLevel, onChangedCallback);

        #endregion
        
        #region ToggleEditorRegion

        public bool DrawToggle(GUIContent label, ref bool property, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawToggle(label, ref property, toggleAlign, indentLevel, onChangedCallback);
        
        public bool DrawToggle(GUIContent label, ref bool property, int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawToggle(label, ref property, ToggleAlign.Right, indentLevel, onChangedCallback);
        
        public bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, ref bool property,
            string shaderLocalKeyword, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawShaderLocalKeywordToggle(label, material, ref property, shaderLocalKeyword, toggleAlign, indentLevel, onChangedCallback);
        
        public bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, ref bool property,
            string shaderLocalKeyword, int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawShaderLocalKeywordToggle(label, material, ref property, shaderLocalKeyword, ToggleAlign.Right, indentLevel, onChangedCallback);
        
        public bool DrawShaderGlobalKeywordToggle(GUIContent label, ref bool property, string shaderGlobalKeyword, 
            ToggleAlign toggleAlign = ToggleAlign.Right, int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawShaderGlobalKeywordToggle(label, ref property, shaderGlobalKeyword, toggleAlign, indentLevel, onChangedCallback);
        
        public bool DrawShaderGlobalKeywordToggle(GUIContent label, ref bool property, string shaderGlobalKeyword, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawShaderGlobalKeywordToggle(label, ref property, shaderGlobalKeyword, ToggleAlign.Right, indentLevel, onChangedCallback);
        
        #endregion
        
        #region VectorEditorRegion

        public float DrawFloat(GUIContent label, ref float property, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawFloat(label, ref property, range, indentLevel, onChangedCallback);
        
        public double DrawDouble(GUIContent label, ref double property, DoubleRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawDouble(label, ref property, range, indentLevel, onChangedCallback);
        
        public Vector2 DrawVector2(GUIContent label, ref Vector2 property, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector2(label, ref property, range, indentLevel, onChangedCallback);
        
        public Vector3 DrawVector3(GUIContent label, ref Vector3 property, Vector3Range range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector3(label, ref property, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4(GUIContent label, ref Vector4 property, Vector4Range range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4(label, ref property, range, indentLevel, onChangedCallback);
        
        public float DrawFloat(GUIContent label, ref float property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawFloat(label, ref property, FloatRange.Full, indentLevel, onChangedCallback);
        
        public double DrawDouble(GUIContent label, ref double property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawDouble(label, ref property, DoubleRange.Full, indentLevel, onChangedCallback);
        
        public Vector2 DrawVector2(GUIContent label, ref Vector2 property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector2(label, ref property, Vector2Range.Full, indentLevel, onChangedCallback);
        
        public Vector3 DrawVector3(GUIContent label, ref Vector3 property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector3(label, ref property, Vector3Range.Full, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4(GUIContent label, ref Vector4 property, int indentLevel = 0,
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4(label, ref property, Vector4Range.Full, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4Start(GUIContent label, ref Vector4 property, Vector2Range range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4Start(label, ref property, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4Start(GUIContent label, ref Vector4 property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4Start(label, ref property, Vector2Range.Full, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4End(GUIContent label, ref Vector4 property, Vector2Range range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4End(label, ref property, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4End(GUIContent label, ref Vector4 property, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4End(label, ref property, Vector2Range.Full, indentLevel, onChangedCallback);
        
        public Vector2 DrawFloatFromVector2(GUIContent label, ref Vector2 property, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector2(label, ref property, vector2Param, range, indentLevel, onChangedCallback);
        
        public Vector3 DrawFloatFromVector3(GUIContent label, ref Vector3 property, Vector3Param vector3Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector3(label, ref property, vector3Param, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawFloatFromVector4(GUIContent label, ref Vector4 property, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector4(label, ref property, vector4Param, range, indentLevel, onChangedCallback);
        
        public float DrawNormalizedFloat(GUIContent label, ref float property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawFloat(label, ref property, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public double DrawNormalizedDouble(GUIContent label, ref double property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawDouble(label, ref property, DoubleRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector2 DrawNormalizedVector2(GUIContent label, ref Vector2 property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector2(label, ref property, Vector2Range.Normalized, indentLevel, onChangedCallback);
        
        public Vector3 DrawNormalizedVector3(GUIContent label, ref Vector3 property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector3(label, ref property, Vector3Range.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawNormalizedVector4(GUIContent label, ref Vector4 property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4(label, ref property, Vector4Range.Normalized, indentLevel, onChangedCallback);
        
        public Vector2 DrawNormalizedFloatFromVector2(GUIContent label, ref Vector2 property, Vector2Param vector2Param, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector2(label, ref property, vector2Param, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3 DrawNormalizedFloatFromVector3(GUIContent label, ref Vector3 property, Vector3Param vector3Param, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector3(label, ref property, vector3Param, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawNormalizedFloatFromVector4(GUIContent label, ref Vector4 property, Vector4Param vector4Param, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector4(label, ref property, vector4Param, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawNormalizedVector4Start(GUIContent label, ref Vector4 property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4Start(label, ref property, Vector2Range.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawNormalizedVector4End(GUIContent label, ref Vector4 property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4End(label, ref property, Vector2Range.Normalized, indentLevel, onChangedCallback);
        
        public float DrawMinFloat(GUIContent label, ref float property, float min = 0.0f, int indentLevel = 0,
            Action onChangedCallback = null) =>
            _vectorEditor.DrawFloat(label, ref property, FloatRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public double DrawMinDouble(GUIContent label, ref double property, double min = 0.0, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawDouble(label, ref property, DoubleRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector2 DrawMinVector2(GUIContent label, ref Vector2 property, Vector2 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector2(label, ref property, Vector2Range.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector3 DrawMinVector3(GUIContent label, ref Vector3 property, Vector3 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector3(label, ref property, Vector3Range.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector4 DrawMinVector4(GUIContent label, ref Vector4 property, Vector4 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4(label, ref property, Vector4Range.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector2 DrawMinFloatFromVector2(GUIContent label, ref Vector2 property, Vector2Param vector2Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector2(label, ref property, vector2Param, FloatRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector3 DrawMinFloatFromVector3(GUIContent label, ref Vector3 property, Vector3Param vector3Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector3(label, ref property, vector3Param, FloatRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector4 DrawMinFloatFromVector4(GUIContent label, ref Vector4 property, Vector4Param vector4Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector4(label, ref property, vector4Param, FloatRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector4 DrawMinVector4Start(GUIContent label, ref Vector4 property, Vector2 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4Start(label, ref property, Vector2Range.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Bounds DrawBoundsField(GUIContent label, ref Bounds property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawBoundsField(label, ref property, indentLevel, onChangedCallback);
        
        public Rect DrawRectField(GUIContent label, ref Rect property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawRectField(label, ref property, indentLevel, onChangedCallback);
        
        #endregion
        
        #region VectorIntEditorRegion

        public int DrawInt(GUIContent label, ref int property, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawInt(label, ref property, range, indentLevel, onChangedCallback);
        
        public long DrawLong(GUIContent label, ref long property, LongRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawLong(label, ref property, range, indentLevel, onChangedCallback);
        
        public Vector2Int DrawVector2Int(GUIContent label, ref Vector2Int property, Vector2IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector2Int(label, ref property, range, indentLevel, onChangedCallback);
        
        public Vector3Int DrawVector3Int(GUIContent label, ref Vector3Int property, Vector3IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector3Int(label, ref property, range, indentLevel, onChangedCallback);
        
        public int DrawInt(GUIContent label, ref int property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawInt(label, ref property, IntRange.Full, indentLevel, onChangedCallback);
        
        public long DrawLong(GUIContent label, ref long property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawLong(label, ref property, LongRange.Full, indentLevel, onChangedCallback);
        
        public Vector2Int DrawVector2Int(GUIContent label, ref Vector2Int property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector2Int(label, ref property, Vector2IntRange.Full, indentLevel, onChangedCallback);
        
        public Vector3Int DrawVector3Int(GUIContent label, ref Vector3Int property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector3Int(label, ref property, Vector3IntRange.Full, indentLevel, onChangedCallback);
        
        public Vector2Int DrawIntFromVector2Int(GUIContent label, ref Vector2Int property, Vector2Param vector2Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntFromVector2Int(label, ref property, vector2Param, range, indentLevel, onChangedCallback);
        
        public Vector3Int DrawIntFromVector3Int(GUIContent label, ref Vector3Int property, Vector3Param vector3Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntFromVector3Int(label, ref property, vector3Param, range, indentLevel, onChangedCallback);
        
        public int DrawNormalizedInt(GUIContent label, ref int property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawInt(label, ref property, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public long DrawNormalizedLong(GUIContent label, ref long property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawLong(label, ref property, LongRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector2Int DrawNormalizedVector2Int(GUIContent label, ref Vector2Int property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector2Int(label, ref property, Vector2IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3Int DrawNormalizedVector3Int(GUIContent label, ref Vector3Int property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector3Int(label, ref property, Vector3IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector2Int DrawNormalizedIntFromVector2Int(GUIContent label, ref Vector2Int property, 
            Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntFromVector2Int(label, ref property, vector2Param, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3Int DrawNormalizedIntFromVector3Int(GUIContent label, ref Vector3Int property, 
            Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntFromVector3Int(label, ref property, vector3Param, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public int DrawMinInt(GUIContent label, ref int property, int min = 0, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawInt(label, ref property, IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public long DrawNormalizedLong(GUIContent label, ref long property, long min = 0, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawLong(label, ref property, LongRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector2Int DrawMinVector2Int(GUIContent label, ref Vector2Int property, Vector2Int min, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector2Int(label, ref property, Vector2IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector3Int DrawMinVector3Int(GUIContent label, ref Vector3Int property, Vector3Int min, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector3Int(label, ref property, Vector3IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector2Int DrawMinIntFromVector2Int(GUIContent label, ref Vector2Int property, Vector2Param vector2Param, 
            int min = 0, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntFromVector2Int(label, ref property, vector2Param, IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector3Int DrawMinIntFromVector3Int(GUIContent label, ref Vector3Int property, Vector3Param vector3Param, 
            int min = 0, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntFromVector3Int(label, ref property, vector3Param, IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public BoundsInt DrawIntBoundsField(GUIContent label, ref BoundsInt property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntBoundsField(label, ref property, indentLevel, onChangedCallback);
        
        public RectInt DrawIntRectField(GUIContent label, ref RectInt property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntRectField(label, ref property, indentLevel, onChangedCallback);
        
        #endregion
        
        #region ColorEditorRegion
        
        public Color DrawColor(GUIContent label, ref Color property, bool showAlpha = true, 
            bool hdr = false, int indentLevel = 0, Action onChangedCallback = null) =>
            _colorEditor.DrawColor(label, ref property, showAlpha, hdr, indentLevel, onChangedCallback);
        
        public Gradient DrawGradient(GUIContent label, ref Gradient property, bool hdr = false, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _colorEditor.DrawGradient(label, ref property, hdr, indentLevel, onChangedCallback);
        
        #endregion
        
        #region TextureEditorRegion

        public Texture DrawTexture(GUIContent label, ref Texture property, int indentLevel = 0, Action onChangedCallback = null) =>
            _textureEditor.DrawTexture(label, ref property, indentLevel, onChangedCallback);
        
        #endregion
        
        #region PopupEditorRegion
        
        public TEnum DrawEnumPopup<TEnum>(ref TEnum property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawEnumPopup(ref property, indentLevel, onChangedCallback);
        
        public TEnum DrawEnumPopup<TEnum>(GUIContent label, ref TEnum property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawEnumPopup(label, ref property, indentLevel, onChangedCallback);
        
        public TEnum DrawEnumFlagsField<TEnum>(GUIContent label, ref TEnum property, bool includeObsolete = false,  
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawEnumFlagsField(label, ref property, includeObsolete, indentLevel, onChangedCallback);
        
        public TEnum DrawBooleanPopup<TEnum>(ref TEnum property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawBooleanPopup(ref property, indentLevel, onChangedCallback);
        
        public TEnum DrawBooleanPopup<TEnum>(GUIContent label, ref TEnum property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawBooleanPopup(label, ref property, indentLevel, onChangedCallback);
        
        public TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(ref TEnum property, string shaderGlobalKeyword, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawShaderGlobalKeywordBooleanPopup(ref property, shaderGlobalKeyword, 
                indentLevel, onChangedCallback);
        
        public TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, ref TEnum property, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawShaderGlobalKeywordBooleanPopup(label, ref property, shaderGlobalKeyword, 
                indentLevel, onChangedCallback);
        
        public int DrawPopup<TEnum>(GUIContent label, ref TEnum property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawPopup(label, ref property, displayedOptions, indentLevel, onChangedCallback);
        
        public int DrawBooleanPopup<TEnum>(GUIContent label, ref TEnum property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawBooleanPopup(label, ref property, displayedOptions, indentLevel, onChangedCallback);
        
        public int DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, ref TEnum property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawShaderGlobalKeywordBooleanPopup(label, ref property, displayedOptions, shaderGlobalKeyword, 
                indentLevel, onChangedCallback);
        
        public string DrawTagField(GUIContent label, ref string property,
            int indentLevel = 0, Action onChangedCallback = null) =>
            _popupEditor.DrawTagField(label, ref property, indentLevel, onChangedCallback);
        
        public int DrawLayerField(GUIContent label, ref int property,
            int indentLevel = 0, Action onChangedCallback = null) =>
            _popupEditor.DrawLayerField(label, ref property, indentLevel, onChangedCallback);
        
        public int DrawMaskField(GUIContent label, ref int property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _popupEditor.DrawMaskField(label, ref property, displayedOptions, indentLevel, onChangedCallback);
        
        #endregion
        
        #region ObjectEditorRegion

        public Object DrawObjectField(GUIContent label, ref Object property, int indentLevel = 0,
            bool allowSceneObjects = true, Action<Object> onChangedCallback = null) =>
            _objectEditor.DrawObjectField(label, ref property, indentLevel, allowSceneObjects, onChangedCallback);
        
        #endregion
        
        #region TextEditorRegion
        
        public GUIContent DrawLabel(GUIContent label, GUIContent label2, int indentLevel = 0) =>
            _textEditor.DrawLabel(label, label2, indentLevel);
        
        public GUIContent DrawLabel(GUIContent label, int indentLevel = 0) =>
            _textEditor.DrawLabel(label, new GUIContent(string.Empty), indentLevel);

        public bool DrawLinkText(GUIContent label, int indentLevel = 0) =>
            _textEditor.DrawLinkText(label, indentLevel);
        
        public bool DrawLinkText(GUIContent label, string url, int indentLevel = 0) =>
            _textEditor.DrawLinkText(label, url, indentLevel);
        
        public string DrawTextField(GUIContent label, ref string property, int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawTextField(label, ref property, indentLevel, onChangedCallback);
        
        public string DrawTextArea(GUIContent label, ref string property, int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawTextArea(label, ref property, indentLevel, onChangedCallback);
        
        public string DrawTextArea(ref string property, int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawTextArea(new GUIContent(string.Empty), ref property, indentLevel, onChangedCallback);
        
        public string DrawPasswordField(GUIContent label, ref string property, int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawPasswordField(label, ref property, indentLevel, onChangedCallback);
        
        public string DrawFolderPathField(GUIContent label, ref string property, string defaultDirectory, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawFolderPathField(label, ref property, defaultDirectory, indentLevel, onChangedCallback);
        
        #endregion
        
        #region CurveEditorRegion

        public AnimationCurve DrawAnimationCurve(GUIContent label, ref AnimationCurve property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _curveEditor.DrawAnimationCurve(label, ref property, indentLevel, onChangedCallback);
        
        #endregion
        
        #region MessageEditorRegion

        public void DrawHelpBox(string message, MessageType type, bool wide = true, int indentLevel = 0) =>
            _messageEditor.DrawHelpBox(message, type, wide);
        
        public void DrawNeutralBox(string message, bool wide = true, int indentLevel = 0) =>
            _messageEditor.DrawNeutralBox(message, wide, indentLevel);
        
        public void DrawInfoBox(string message, bool wide = true, int indentLevel = 0) =>
            _messageEditor.DrawInfoBox(message, wide, indentLevel);
        
        public void DrawWarningBox(string message, bool wide = true, int indentLevel = 0) =>
            _messageEditor.DrawWarningBox(message, wide, indentLevel);
        
        public void DrawErrorBox(string message, bool wide = true, int indentLevel = 0) =>
            _messageEditor.DrawErrorBox(message, wide, indentLevel);
        
        #endregion

        public void Space() =>
            EditorGUILayout.Space();
        
        public void Space(float width) =>
            EditorGUILayout.Space(width);
        
        public void Space(float width, bool expand) =>
            EditorGUILayout.Space(width, expand);
    }
}