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
    public sealed partial class EditorGUIPlus
    {
        private GroupEditor _groupEditor;
        private SliderEditor _sliderEditor;
        private IntSliderEditor _intSliderEditor;
        private ToggleEditor _toggleEditor;
        private VectorEditor _vectorEditor;
        private IntVectorEditor _intVectorEditor;
        private ColorEditor _colorEditor;
        private TextureEditor _textureEditor;
        private PopupEditor _popupEditor;
        private ObjectEditor _objectEditor;
        private TextEditor _textEditor;
        private CurveEditor _curveEditor;
        private MessageEditor _messageEditor;

        public void InitializeBaseEditors()
        {
            _groupEditor = new GroupEditor();
            _sliderEditor = new SliderEditor(_groupEditor);
            _intSliderEditor = new IntSliderEditor(_groupEditor);
            _toggleEditor = new ToggleEditor(_groupEditor);
            _vectorEditor = new VectorEditor(_groupEditor);
            _intVectorEditor = new IntVectorEditor(_groupEditor);
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
        
        public EditorGUI.IndentLevelScope IndentLevelScope(int increment) =>
            _groupEditor.IndentLevelScope(increment);
        
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
        
        public float DrawSlider(GUIContent label, float sliderValue, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderEditor.DrawSlider(label, sliderValue, range, indentLevel, onChangedCallback);
        
        public float DrawSlider(GUIContent label, float sliderValue, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderEditor.DrawSlider(label, sliderValue, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector2 DrawFromVector2ParamSlider(GUIContent label, Vector2 vector2, Vector2Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawFromVector2ParamSlider(label, vector2, vectorParam, range, indentLevel, onChangedCallback);
        
        public Vector2 DrawFromVector2ParamSlider(GUIContent label, Vector2 vector2, Vector2Param vectorParam, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawFromVector2ParamSlider(label, vector2, vectorParam, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector2 DrawVector2Sliders(GUIContent labelX, GUIContent labelY, Vector2 vector2, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawVector2Sliders(labelX, labelY, vector2, range, indentLevel, onChangedCallback);
        
        public Vector2 DrawVector2Sliders(GUIContent labelX, GUIContent labelY, Vector2 vector2, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderEditor.DrawVector2Sliders(labelX, labelY, vector2, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3 DrawFromVector3ParamSlider(GUIContent label, Vector3 vector3, Vector3Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawFromVector3ParamSlider(label, vector3, vectorParam, range, indentLevel, onChangedCallback);
        
        public Vector3 DrawFromVector3ParamSlider(GUIContent label, Vector3 vector3, Vector3Param vectorParam, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawFromVector3ParamSlider(label, vector3, vectorParam, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3 DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, Vector3 vector3, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawVector3Sliders(labelX, labelY, labelZ, vector3, range, indentLevel, onChangedCallback);
        
        public Vector3 DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, Vector3 vector3, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawVector3Sliders(labelX, labelY, labelZ, vector3, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawFromVector4ParamSlider(GUIContent label, Vector4 vector4, Vector4Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawFromVector4ParamSlider(label, vector4, vectorParam, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawFromVector4ParamSlider(GUIContent label, Vector4 vector4, Vector4Param vectorParam, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawFromVector4ParamSlider(label, vector4, vectorParam, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, ref float minProperty, ref float maxProperty, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxSlider(label, ref minProperty, ref maxProperty, range, indentLevel, onChangedCallback);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, ref float minProperty, ref float maxProperty, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxSlider(label, ref minProperty, ref maxProperty, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawMinMaxVector4StartSlider(GUIContent label, Vector4 vector4, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxVector4StartSlider(label, vector4, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawMinMaxVector4StartSlider(GUIContent label, Vector4 vector4, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxVector4StartSlider(label, vector4, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawMinMaxVector4EndSlider(GUIContent label, Vector4 vector4, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxVector4EndSlider(label, vector4, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawMinMaxVector4EndSlider(GUIContent label, Vector4 vector4, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxVector4EndSlider(label, vector4, FloatRange.Normalized, indentLevel, onChangedCallback);

        #endregion
        
        #region SliderIntEditorRegion

        public int DrawIntSlider(GUIContent label, int sliderValue, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intSliderEditor.DrawIntSlider(label,  sliderValue, range, indentLevel, onChangedCallback);
        
        public int DrawIntSlider(GUIContent label, int sliderValue, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intSliderEditor.DrawIntSlider(label,  sliderValue, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector2Int DrawFromVector2IntParamSlider(GUIContent label, Vector2Int vector2Int, 
            Vector2Param vectorParam, IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _intSliderEditor.DrawFromVector2IntParamSlider(label, vector2Int, vectorParam, range, indentLevel, onChangedCallback);
        
        public Vector2Int DrawFromVector2IntParamSlider(GUIContent label, Vector2Int vector2Int, 
            Vector2Param vectorParam, int indentLevel = 0, Action onChangedCallback = null) =>
            _intSliderEditor.DrawFromVector2IntParamSlider(label, vector2Int, vectorParam, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector2Int DrawVector2IntSliders(GUIContent labelX, GUIContent labelY, Vector2Int vector2Int,
            IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _intSliderEditor.DrawVector2IntSliders(labelX, labelY, vector2Int, range, indentLevel, onChangedCallback);
        
        public Vector2Int DrawVector2IntSliders(GUIContent labelX, GUIContent labelY, Vector2Int vector2Int, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _intSliderEditor.DrawVector2IntSliders(labelX, labelY, vector2Int, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3Int DrawFromVector3IntParamSlider(GUIContent label, Vector3Int vector3Int, 
            Vector3Param vectorParam, IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _intSliderEditor.DrawFromVector3IntParamSlider(label, vector3Int, vectorParam, range, indentLevel, onChangedCallback);
        
        public Vector3Int DrawFromVector3IntParamSlider(GUIContent label, Vector3Int vector3Int, 
            Vector3Param vectorParam, int indentLevel = 0, Action onChangedCallback = null) =>
            _intSliderEditor.DrawFromVector3IntParamSlider(label, vector3Int, vectorParam, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3Int DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, Vector3Int vector3Int,
            IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _intSliderEditor.DrawVector3IntSliders(labelX, labelY, labelZ, vector3Int, range, indentLevel, onChangedCallback);
        
        public Vector3Int DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, Vector3Int vector3Int, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _intSliderEditor.DrawVector3IntSliders(labelX, labelY, labelZ, vector3Int, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public IntRange DrawMinMaxIntSlider(GUIContent label, ref int minProperty, ref int maxProperty, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _intSliderEditor.DrawMinMaxIntSlider(label, ref minProperty, ref maxProperty, range, indentLevel, onChangedCallback);
        
        public IntRange DrawMinMaxIntSlider(GUIContent label, ref int minProperty, ref int maxProperty, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intSliderEditor.DrawMinMaxIntSlider(label, ref minProperty, ref maxProperty, IntRange.Normalized, indentLevel, onChangedCallback);

        #endregion
        
        #region ToggleEditorRegion

        public bool DrawToggle(GUIContent label, bool property, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawToggle(label, property, toggleAlign, indentLevel, onChangedCallback);
        
        public bool DrawToggle(GUIContent label, bool property, int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawToggle(label, property, ToggleAlign.Right, indentLevel, onChangedCallback);
        
        public bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, bool property,
            string shaderLocalKeyword, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawShaderLocalKeywordToggle(label, material, property, shaderLocalKeyword, toggleAlign, indentLevel, onChangedCallback);
        
        public bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, bool property,
            string shaderLocalKeyword, int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawShaderLocalKeywordToggle(label, material, property, shaderLocalKeyword, ToggleAlign.Right, indentLevel, onChangedCallback);
        
        public bool DrawShaderGlobalKeywordToggle(GUIContent label, bool property, string shaderGlobalKeyword, 
            ToggleAlign toggleAlign = ToggleAlign.Right, int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawShaderGlobalKeywordToggle(label, property, shaderGlobalKeyword, toggleAlign, indentLevel, onChangedCallback);
        
        public bool DrawShaderGlobalKeywordToggle(GUIContent label, bool property, string shaderGlobalKeyword, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawShaderGlobalKeywordToggle(label, property, shaderGlobalKeyword, ToggleAlign.Right, indentLevel, onChangedCallback);
        
        #endregion
        
        #region VectorEditorRegion

        public float DrawFloat(GUIContent label, float property, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawFloat(label, property, range, indentLevel, onChangedCallback);
        
        public double DrawDouble(GUIContent label, double property, DoubleRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawDouble(label, property, range, indentLevel, onChangedCallback);
        
        public Vector2 DrawVector2(GUIContent label, Vector2 vector2, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector2(label, vector2, range, indentLevel, onChangedCallback);
        
        public Vector3 DrawVector3(GUIContent label, Vector3 vector3, Vector3Range range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector3(label, vector3, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4(GUIContent label, Vector4 vector4, Vector4Range range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4(label, vector4, range, indentLevel, onChangedCallback);
        
        public float DrawFloat(GUIContent label, float property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawFloat(label, property, FloatRange.Full, indentLevel, onChangedCallback);
        
        public double DrawDouble(GUIContent label, double property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawDouble(label, property, DoubleRange.Full, indentLevel, onChangedCallback);
        
        public Vector2 DrawVector2(GUIContent label, Vector2 vector2, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector2(label, vector2, Vector2Range.Full, indentLevel, onChangedCallback);
        
        public Vector3 DrawVector3(GUIContent label, Vector3 vector3, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector3(label, vector3, Vector3Range.Full, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4(GUIContent label, Vector4 vector4, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4(label, vector4, Vector4Range.Full, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4Start(GUIContent label, Vector4 vector4, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4Start(label, vector4, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4Start(GUIContent label, Vector4 vector4, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4Start(label, vector4, Vector2Range.Full, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4End(GUIContent label, Vector4 vector4, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4End(label, vector4, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4End(GUIContent label, Vector4 vector4, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4End(label, vector4, Vector2Range.Full, indentLevel, onChangedCallback);
        
        public Vector2 DrawFloatFromVector2(GUIContent label, Vector2 vector2, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector2(label, vector2, vector2Param, range, indentLevel, onChangedCallback);
        
        public Vector3 DrawFloatFromVector3(GUIContent label, Vector3 vector3, Vector3Param vector3Param, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector3(label, vector3, vector3Param, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawFloatFromVector4(GUIContent label, Vector4 vector4, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector4(label, vector4, vector4Param, range, indentLevel, onChangedCallback);
        
        public float DrawNormalizedFloat(GUIContent label, float property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawFloat(label, property, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public double DrawNormalizedDouble(GUIContent label, double property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawDouble(label, property, DoubleRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector2 DrawNormalizedVector2(GUIContent label, Vector2 vector2, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector2(label, vector2, Vector2Range.Normalized, indentLevel, onChangedCallback);
        
        public Vector3 DrawNormalizedVector3(GUIContent label, Vector3 vector3, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector3(label, vector3, Vector3Range.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawNormalizedVector4(GUIContent label, Vector4 vector4, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4(label, vector4, Vector4Range.Normalized, indentLevel, onChangedCallback);
        
        public Vector2 DrawNormalizedFloatFromVector2(GUIContent label, Vector2 vector2, Vector2Param vector2Param, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector2(label, vector2, vector2Param, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3 DrawNormalizedFloatFromVector3(GUIContent label, Vector3 vector3, Vector3Param vector3Param, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector3(label, vector3, vector3Param, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawNormalizedFloatFromVector4(GUIContent label, Vector4 vector4, Vector4Param vector4Param, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector4(label, vector4, vector4Param, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawNormalizedVector4Start(GUIContent label, Vector4 vector4, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4Start(label, vector4, Vector2Range.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawNormalizedVector4End(GUIContent label, Vector4 vector4, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4End(label, vector4, Vector2Range.Normalized, indentLevel, onChangedCallback);
        
        public float DrawMinFloat(GUIContent label, float property, float min = 0.0f, int indentLevel = 0,
            Action onChangedCallback = null) =>
            _vectorEditor.DrawFloat(label, property, FloatRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public double DrawMinDouble(GUIContent label, double property, double min = 0.0, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawDouble(label, property, DoubleRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector2 DrawMinVector2(GUIContent label, Vector2 vector2, Vector2 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector2(label, vector2, Vector2Range.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector3 DrawMinVector3(GUIContent label, Vector3 vector3, Vector3 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector3(label, vector3, Vector3Range.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector4 DrawMinVector4(GUIContent label, Vector4 vector4, Vector4 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4(label, vector4, Vector4Range.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector2 DrawMinFloatFromVector2(GUIContent label, Vector2 vector2, Vector2Param vector2Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector2(label, vector2, vector2Param, FloatRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector3 DrawMinFloatFromVector3(GUIContent label, Vector3 vector3, Vector3Param vector3Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector3(label, vector3, vector3Param, FloatRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector4 DrawMinFloatFromVector4(GUIContent label, Vector4 vector4, Vector4Param vector4Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector4(label, vector4, vector4Param, FloatRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector4 DrawMinVector4Start(GUIContent label, Vector4 vector4, Vector2 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4Start(label, vector4, Vector2Range.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Bounds DrawBoundsField(GUIContent label, Bounds bounds, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawBoundsField(label, bounds, indentLevel, onChangedCallback);
        
        public Rect DrawRectField(GUIContent label, Rect rect, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawRectField(label, rect, indentLevel, onChangedCallback);
        
        #endregion
        
        #region VectorIntEditorRegion

        public int DrawInt(GUIContent label, int property, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorEditor.DrawInt(label, property, range, indentLevel, onChangedCallback);
        
        public long DrawLong(GUIContent label, long property, LongRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorEditor.DrawLong(label, property, range, indentLevel, onChangedCallback);
        
        public Vector2Int DrawVector2Int(GUIContent label, Vector2Int vector2Int, Vector2IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawVector2Int(label, vector2Int, range, indentLevel, onChangedCallback);
        
        public Vector3Int DrawVector3Int(GUIContent label, Vector3Int vector3Int, Vector3IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawVector3Int(label, vector3Int, range, indentLevel, onChangedCallback);
        
        public int DrawInt(GUIContent label, int property, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawInt(label, property, IntRange.Full, indentLevel, onChangedCallback);
        
        public long DrawLong(GUIContent label, long property, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawLong(label, property, LongRange.Full, indentLevel, onChangedCallback);
        
        public Vector2Int DrawVector2Int(GUIContent label, Vector2Int vector2Int, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorEditor.DrawVector2Int(label, vector2Int, Vector2IntRange.Full, indentLevel, onChangedCallback);
        
        public Vector3Int DrawVector3Int(GUIContent label, Vector3Int vector3Int, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorEditor.DrawVector3Int(label, vector3Int, Vector3IntRange.Full, indentLevel, onChangedCallback);
        
        public Vector2Int DrawIntFromVector2Int(GUIContent label, Vector2Int vector2Int, Vector2Param vector2Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawIntFromVector2Int(label, vector2Int, vector2Param, range, indentLevel, onChangedCallback);
        
        public Vector3Int DrawIntFromVector3Int(GUIContent label, Vector3Int vector3Int, Vector3Param vector3Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawIntFromVector3Int(label, vector3Int, vector3Param, range, indentLevel, onChangedCallback);
        
        public int DrawNormalizedInt(GUIContent label, int property, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawInt(label, property, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public long DrawNormalizedLong(GUIContent label, long property, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawLong(label, property, LongRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector2Int DrawNormalizedVector2Int(GUIContent label, Vector2Int vector2Int, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorEditor.DrawVector2Int(label, vector2Int, Vector2IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3Int DrawNormalizedVector3Int(GUIContent label, ref Vector3Int vector3Int, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorEditor.DrawVector3Int(label, vector3Int, Vector3IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector2Int DrawNormalizedIntFromVector2Int(GUIContent label, Vector2Int vector2Int, 
            Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawIntFromVector2Int(label, vector2Int, vector2Param, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3Int DrawNormalizedIntFromVector3Int(GUIContent label, ref Vector3Int vector3Int, 
            Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawIntFromVector3Int(label, vector3Int, vector3Param, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public int DrawMinInt(GUIContent label, int property, int min = 0, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawInt(label, property, IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public long DrawNormalizedLong(GUIContent label, long property, long min = 0, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorEditor.DrawLong(label, property, LongRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector2Int DrawMinVector2Int(GUIContent label, Vector2Int vector2Int, Vector2Int min, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawVector2Int(label, vector2Int, Vector2IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector3Int DrawMinVector3Int(GUIContent label, Vector3Int vector3Int, Vector3Int min, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawVector3Int(label, vector3Int, Vector3IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector2Int DrawMinIntFromVector2Int(GUIContent label, Vector2Int vector2Int, Vector2Param vector2Param, 
            int min = 0, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawIntFromVector2Int(label, vector2Int, vector2Param, IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector3Int DrawMinIntFromVector3Int(GUIContent label, ref Vector3Int vector3Int, Vector3Param vector3Param, 
            int min = 0, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawIntFromVector3Int(label, vector3Int, vector3Param, IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public BoundsInt DrawIntBoundsField(GUIContent label, BoundsInt boundsInt, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawIntBoundsField(label, boundsInt, indentLevel, onChangedCallback);
        
        public RectInt DrawIntRectField(GUIContent label, RectInt rectInt, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorEditor.DrawIntRectField(label, rectInt, indentLevel, onChangedCallback);
        
        #endregion
        
        #region ColorEditorRegion
        
        public Color DrawColor(GUIContent label,  Color color, bool showAlpha = true, 
            bool hdr = false, int indentLevel = 0, Action onChangedCallback = null) =>
            _colorEditor.DrawColor(label, color, showAlpha, hdr, indentLevel, onChangedCallback);
        
        public Gradient DrawGradient(GUIContent label, Gradient gradient, bool hdr = false, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _colorEditor.DrawGradient(label, gradient, hdr, indentLevel, onChangedCallback);
        
        #endregion
        
        #region TextureEditorRegion

        public Texture DrawTexture(GUIContent label, Texture texture, int indentLevel = 0, Action onChangedCallback = null) =>
            _textureEditor.DrawTexture(label, texture, indentLevel, onChangedCallback);
        
        #endregion
        
        #region PopupEditorRegion
        
        public TEnum DrawEnumPopup<TEnum>(TEnum property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawEnumPopup(property, indentLevel, onChangedCallback);
        
        public TEnum DrawEnumPopup<TEnum>(GUIContent label, TEnum property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawEnumPopup(label, property, indentLevel, onChangedCallback);
        
        public TEnum DrawEnumFlagsField<TEnum>(GUIContent label, TEnum property, bool includeObsolete = false,  
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawEnumFlagsField(label, property, includeObsolete, indentLevel, onChangedCallback);
        
        public TEnum DrawBooleanPopup<TEnum>(TEnum property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawBooleanPopup(property, indentLevel, onChangedCallback);
        
        public TEnum DrawBooleanPopup<TEnum>(GUIContent label, TEnum property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawBooleanPopup(label, property, indentLevel, onChangedCallback);
        
        public TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(TEnum property, string shaderGlobalKeyword, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawShaderGlobalKeywordBooleanPopup(property, shaderGlobalKeyword, 
                indentLevel, onChangedCallback);
        
        public TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, TEnum property, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawShaderGlobalKeywordBooleanPopup(label, property, shaderGlobalKeyword, 
                indentLevel, onChangedCallback);
        
        public int DrawPopup<TEnum>(GUIContent label, TEnum property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawPopup(label, property, displayedOptions, indentLevel, onChangedCallback);
        
        public int DrawBooleanPopup<TEnum>(GUIContent label, TEnum property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawBooleanPopup(label, property, displayedOptions, indentLevel, onChangedCallback);
        
        public int DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, TEnum property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawShaderGlobalKeywordBooleanPopup(label, property, displayedOptions, shaderGlobalKeyword, 
                indentLevel, onChangedCallback);
        
        public string DrawTagField(GUIContent label, string property,
            int indentLevel = 0, Action onChangedCallback = null) =>
            _popupEditor.DrawTagField(label, property, indentLevel, onChangedCallback);
        
        public int DrawLayerField(GUIContent label, int layer,
            int indentLevel = 0, Action onChangedCallback = null) =>
            _popupEditor.DrawLayerField(label,  layer, indentLevel, onChangedCallback);
        
        public int DrawMaskField(GUIContent label, int mask, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _popupEditor.DrawMaskField(label,  mask, displayedOptions, indentLevel, onChangedCallback);
        
        #endregion
        
        #region ObjectEditorRegion

        public Object DrawObjectField(GUIContent label, Object objectProperty, int indentLevel = 0,
            bool allowSceneObjects = true, Action<Object> onChangedCallback = null) =>
            _objectEditor.DrawObjectField(label, objectProperty, indentLevel, allowSceneObjects, onChangedCallback);
        
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
        
        public string DrawTextField(GUIContent label, string text, int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawTextField(label, text, indentLevel, onChangedCallback);
        
        public string DrawTextArea(GUIContent label, string text, int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawTextArea(label, text, indentLevel, onChangedCallback);
        
        public string DrawTextArea(string text, int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawTextArea(new GUIContent(string.Empty), text, indentLevel, onChangedCallback);
        
        public string DrawPasswordField(GUIContent label, string password, int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawPasswordField(label, password, indentLevel, onChangedCallback);
        
        public string DrawFolderPathField(GUIContent label, string path, string defaultDirectory, string defaultName, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawFolderPathField(label, path, defaultDirectory, indentLevel, onChangedCallback);
        
        #endregion
        
        #region CurveEditorRegion

        public AnimationCurve DrawAnimationCurve(GUIContent label, AnimationCurve curve, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _curveEditor.DrawAnimationCurve(label, curve, indentLevel, onChangedCallback);
        
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
        
        public TType DrawField<TType>(GUIContent label, TType value, int indentLevel = 0, Action onChangedCallback = null) =>
            _fieldDrawer.DrawField(this, label, value, indentLevel, onChangedCallback);
        
        public void Space() =>
            EditorGUILayout.Space();
        
        public void Space(float width) =>
            EditorGUILayout.Space(width);
        
        public void Space(float width, bool expand) =>
            EditorGUILayout.Space(width, expand);
    }
}