using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using EditorGUIPlus.EditorModules;
using EditorGUIPlus.EditorModules.PropertyBased;
using EditorGUIPlus.MaterialEditor.AssetObject;
using EditorGUIPlus.Scopes;
using EditorGUIPlus.Scopes.Section;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.MaterialEditor
{
    public sealed class MaterialEditorGUIPlus : IMaterialEditorGUIPlus
    {
        private readonly GroupEditor _groupEditor;
        private readonly SliderPropertyEditor _sliderPropertyEditor;
        private readonly IntSliderPropertyEditor _intSliderPropertyEditor;
        private readonly TogglePropertyEditor _togglePropertyEditor;
        private readonly VectorPropertyEditor _vectorPropertyEditor;
        private readonly IntVectorPropertyEditor _intVectorPropertyEditor;
        private readonly ColorPropertyEditor _colorPropertyEditor;
        private readonly TexturePropertyEditor _texturePropertyEditor;
        private readonly PopupPropertyEditor _popupPropertyEditor;
        private readonly ObjectPropertyEditor _objectPropertyEditor;
        private readonly TextPropertyEditor _textPropertyEditor;
        private readonly MessageEditor _messageEditor;
        
        public UnityEditor.MaterialEditor MaterialEditor;
        
        public MaterialEditorGUIPlus()
        {
            PropertyService propertyService = new PropertyService();
            
            _groupEditor = new GroupEditor();
            _sliderPropertyEditor = new SliderPropertyEditor(propertyService, _groupEditor);
            _intSliderPropertyEditor = new IntSliderPropertyEditor(propertyService, _groupEditor);
            _togglePropertyEditor = new TogglePropertyEditor(propertyService, _groupEditor);
            _vectorPropertyEditor = new VectorPropertyEditor(propertyService, _groupEditor);
            _intVectorPropertyEditor = new IntVectorPropertyEditor(propertyService, _groupEditor);
            _colorPropertyEditor = new ColorPropertyEditor(propertyService, _groupEditor);
            _texturePropertyEditor = new TexturePropertyEditor(propertyService, _groupEditor);
            _popupPropertyEditor = new PopupPropertyEditor(propertyService, _groupEditor);
            _objectPropertyEditor = new ObjectPropertyEditor(_groupEditor);
            _textPropertyEditor = new TextPropertyEditor(_groupEditor);
            _messageEditor = new MessageEditor(_groupEditor);
        }
        
        public void InitializeMaterialEditor(UnityEditor.MaterialEditor materialEditor) => 
            MaterialEditor = materialEditor;
        
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
        
        public void DrawFoldout(GUIContent label, ref bool fold, bool toggleOnLabelClick, Action drawCall) =>
            _groupEditor.DrawFoldout(label, ref fold, toggleOnLabelClick, drawCall);
        
        public void DrawFoldout(GUIContent label, ref bool fold, Action drawCall) =>
            _groupEditor.DrawFoldout(label, ref fold, false, drawCall);
        
        #endregion

        #region SliderEditorRegion
        
        public float DrawSlider(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawSlider(label, property, range, indentLevel, false, onChangedCallback);
        
        public float DrawSlider(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawSlider(label, property, FloatRange.Normalized, indentLevel, false, onChangedCallback);
        
        public void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            MaterialProperty property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawVector3Sliders(labelX, labelY, labelZ, property, range, indentLevel, false, onChangedCallback);
        
        public void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawVector3Sliders(labelX, labelY, labelZ, property, FloatRange.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawFromVector4ParamSlider(GUIContent label, MaterialProperty property, Vector4Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawFromVector4ParamSlider(label, property, vectorParam, range, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawFromVector4ParamSlider(GUIContent label, MaterialProperty property, Vector4Param vectorParam, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawFromVector4ParamSlider(label, property, vectorParam, FloatRange.Normalized, indentLevel, false, onChangedCallback);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, MaterialProperty minProperty, 
            MaterialProperty maxProperty, FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawMinMaxSlider(label, minProperty, maxProperty, range, indentLevel, false, onChangedCallback);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, MaterialProperty minProperty, 
            MaterialProperty maxProperty, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawMinMaxSlider(label, minProperty, maxProperty, FloatRange.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawMinMaxVector4StartSlider(GUIContent label, MaterialProperty property, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawMinMaxVector4StartSlider(label, property, range, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawMinMaxVector4StartSlider(GUIContent label, MaterialProperty property, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawMinMaxVector4StartSlider(label, property, FloatRange.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawMinMaxVector4EndSlider(GUIContent label, MaterialProperty property, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawMinMaxVector4EndSlider(label, property, range, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawMinMaxVector4EndSlider(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawMinMaxVector4EndSlider(label, property, FloatRange.Normalized, indentLevel, false, onChangedCallback);

        #endregion
        
        #region SliderIntEditorRegion

        public int DrawIntSlider(GUIContent label, MaterialProperty property, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intSliderPropertyEditor.DrawIntSlider(label, property, range, indentLevel, false, onChangedCallback);
        
        public int DrawIntSlider(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intSliderPropertyEditor.DrawIntSlider(label, property, IntRange.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector3Int DrawFromVector3IntParamSlider(GUIContent label, MaterialProperty property, 
            Vector3Param vectorParam, IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _intSliderPropertyEditor.DrawFromVector3IntParamSlider(label, property, vectorParam, range, indentLevel, false, onChangedCallback);
        
        public Vector3Int DrawFromVector3IntParamSlider(GUIContent label, MaterialProperty property, 
            Vector3Param vectorParam, int indentLevel = 0, Action onChangedCallback = null) =>
            _intSliderPropertyEditor.DrawFromVector3IntParamSlider(label, property, vectorParam, IntRange.Normalized, indentLevel, false, onChangedCallback);
        
        public void DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            MaterialProperty property, IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _intSliderPropertyEditor.DrawVector3IntSliders(labelX, labelY, labelZ, property, range, indentLevel, false, onChangedCallback);
        
        public void DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null) =>
            _intSliderPropertyEditor.DrawVector3IntSliders(labelX, labelY, labelZ, property, IntRange.Normalized, indentLevel, false, onChangedCallback);

        #endregion
        
        #region ToggleEditorRegion

        public bool DrawToggle(GUIContent label, MaterialProperty property, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _togglePropertyEditor.DrawToggle(label, property, toggleAlign, indentLevel, false, onChangedCallback);
        
        public bool DrawToggle(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null) =>
            _togglePropertyEditor.DrawToggle(label, property, ToggleAlign.Right, indentLevel, false, onChangedCallback);
        
        public bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, MaterialProperty property,
            string shaderLocalKeyword, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _togglePropertyEditor.DrawShaderLocalKeywordToggle(label, material, property, shaderLocalKeyword, toggleAlign, indentLevel, false, onChangedCallback);
        
        public bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, MaterialProperty property,
            string shaderLocalKeyword, int indentLevel = 0, Action onChangedCallback = null) =>
            _togglePropertyEditor.DrawShaderLocalKeywordToggle(label, material, property, shaderLocalKeyword, ToggleAlign.Right, indentLevel, false, onChangedCallback);
        
        public bool DrawShaderGlobalKeywordToggle(GUIContent label, MaterialProperty property, string shaderGlobalKeyword, 
            ToggleAlign toggleAlign = ToggleAlign.Right, int indentLevel = 0, Action onChangedCallback = null) =>
            _togglePropertyEditor.DrawShaderGlobalKeywordToggle(label, property, shaderGlobalKeyword, toggleAlign, indentLevel, false, onChangedCallback);
        
        public bool DrawShaderGlobalKeywordToggle(GUIContent label, MaterialProperty property, string shaderGlobalKeyword, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _togglePropertyEditor.DrawShaderGlobalKeywordToggle(label, property, shaderGlobalKeyword, ToggleAlign.Right, indentLevel, false, onChangedCallback);
        
        #endregion
        
        #region VectorEditorRegion

        public float DrawFloat(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloat(label, property, range, indentLevel, false, onChangedCallback);
        
        public Vector2 DrawVector2(GUIContent label, MaterialProperty property, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector2(label, property, range, indentLevel, false, onChangedCallback);
        
        public Vector3 DrawVector3(GUIContent label, MaterialProperty property, Vector3Range range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector3(label, property, range, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawVector4(GUIContent label, MaterialProperty property, Vector4Range range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4(label, property, range, indentLevel, false, onChangedCallback);
        
        public float DrawFloat(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloat(label, property, FloatRange.Full, indentLevel, false, onChangedCallback);
        
        public Vector2 DrawVector2(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector2(label, property, Vector2Range.Full, indentLevel, false, onChangedCallback);
        
        public Vector3 DrawVector3(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector3(label, property, Vector3Range.Full, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawVector4(GUIContent label, MaterialProperty property, int indentLevel = 0,
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4(label, property, Vector4Range.Full, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawVector4Start(GUIContent label, MaterialProperty property, Vector2Range range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4Start(label, property, range, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawVector4Start(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4Start(label, property, Vector2Range.Full, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawVector4End(GUIContent label, MaterialProperty property, Vector2Range range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4End(label, property, range, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawVector4End(GUIContent label, MaterialProperty property, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4End(label, property, Vector2Range.Full, indentLevel, false, onChangedCallback);
        
        public Vector2 DrawFloatFromVector2(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector2(label, property, vector2Param, range, indentLevel, false, onChangedCallback);
        
        public Vector3 DrawFloatFromVector3(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector3(label, property, vector3Param, range, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawFloatFromVector4(GUIContent label, MaterialProperty property, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector4(label, property, vector4Param, range, indentLevel, false, onChangedCallback);
        
        public float DrawNormalizedFloat(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloat(label, property, FloatRange.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector2 DrawNormalizedVector2(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector2(label, property, Vector2Range.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector2 DrawNormalizedVector3(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector3(label, property, Vector3Range.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector2 DrawNormalizedVector4(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4(label, property, Vector4Range.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector2 DrawNormalizedFloatFromVector2(GUIContent label, MaterialProperty property, 
            Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector2(label, property, vector2Param, FloatRange.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector3 DrawNormalizedFloatFromVector3(GUIContent label, MaterialProperty property, 
            Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector3(label, property, vector3Param, FloatRange.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawNormalizedFloatFromVector4(GUIContent label, MaterialProperty property, 
            Vector4Param vector4Param, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector4(label, property, vector4Param, FloatRange.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawNormalizedVector4Start(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4Start(label, property, Vector2Range.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector4 DrawNormalizedVector4End(GUIContent label, MaterialProperty property, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4End(label, property, Vector2Range.Normalized, indentLevel, false, onChangedCallback);
        
        public float DrawMinFloat(GUIContent label, MaterialProperty property, float min = 0.0f, int indentLevel = 0,
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloat(label, property, FloatRange.ToMaxFrom(min), indentLevel, false, onChangedCallback);
        
        public Vector2 DrawMinVector2(GUIContent label, MaterialProperty property, Vector2 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector2(label, property, Vector2Range.ToMaxFrom(min), indentLevel, false, onChangedCallback);
        
        public Vector2 DrawMinVector3(GUIContent label, MaterialProperty property, Vector3 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector3(label, property, Vector3Range.ToMaxFrom(min), indentLevel, false, onChangedCallback);
        
        public Vector2 DrawMinVector4(GUIContent label, MaterialProperty property, Vector4 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4(label, property, Vector4Range.ToMaxFrom(min), indentLevel, false, onChangedCallback);
        
        public Vector2 DrawMinFloatFromVector2(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector2(label, property, vector2Param, FloatRange.ToMaxFrom(min), indentLevel, false, onChangedCallback);
        
        public Vector3 DrawMinFloatFromVector3(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector3(label, property, vector3Param, FloatRange.ToMaxFrom(min), indentLevel, false, onChangedCallback);
        
        public Vector4 DrawMinFloatFromVector4(GUIContent label, MaterialProperty property, Vector4Param vector4Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector4(label, property, vector4Param, FloatRange.ToMaxFrom(min), indentLevel, false, onChangedCallback);
        
        public Vector4 DrawMinVector4Start(GUIContent label, MaterialProperty property, Vector2 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4Start(label, property, Vector2Range.ToMaxFrom(min), indentLevel, false, onChangedCallback);
        
        public Vector4 DrawMinVector4End(GUIContent label, MaterialProperty property, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4End(label, property, Vector2Range.Normalized, indentLevel, false, onChangedCallback);
        
        #endregion
        
        #region VectorIntEditorRegion

        public int DrawInt(GUIContent label, MaterialProperty property, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawInt(label, property, range, indentLevel, false, onChangedCallback);
        
        public Vector2Int DrawVector2Int(GUIContent label, MaterialProperty property, Vector2IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector2Int(label, property, range, indentLevel, false, onChangedCallback);
        
        public Vector3Int DrawVector3Int(GUIContent label, MaterialProperty property, Vector3IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector3Int(label, property, range, indentLevel, false, onChangedCallback);
        
        public int DrawInt(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawInt(label, property, IntRange.Full, indentLevel, false, onChangedCallback);
        
        public Vector2Int DrawVector2Int(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector2Int(label, property, Vector2IntRange.Full, indentLevel, false, onChangedCallback);
        
        public Vector3Int DrawVector3Int(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector3Int(label, property, Vector3IntRange.Full, indentLevel, false, onChangedCallback);
        
        public Vector2Int DrawIntFromVector2Int(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawIntFromVector2Int(label, property, vector2Param, range, indentLevel, false, onChangedCallback);
        
        public Vector3Int DrawIntFromVector3Int(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawIntFromVector3Int(label, property, vector3Param, range, indentLevel, false, onChangedCallback);
        
        public int DrawNormalizedInt(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawInt(label, property, IntRange.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector2Int DrawNormalizedVector2Int(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector2Int(label, property, Vector2IntRange.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector3Int DrawNormalizedVector3Int(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector3Int(label, property, Vector3IntRange.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector2Int DrawNormalizedIntFromVector2Int(GUIContent label, MaterialProperty property, 
            Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawIntFromVector2Int(label, property, vector2Param, IntRange.Normalized, indentLevel, false, onChangedCallback);
        
        public Vector3Int DrawNormalizedIntFromVector3Int(GUIContent label, MaterialProperty property, 
            Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawIntFromVector3Int(label, property, vector3Param, IntRange.Normalized, indentLevel, false, onChangedCallback);
        
        public int DrawMinInt(GUIContent label, MaterialProperty property, int min = 0, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawInt(label, property, IntRange.ToMaxFrom(min), indentLevel, false, onChangedCallback);
        
        public Vector2Int DrawMinVector2Int(GUIContent label, MaterialProperty property, Vector2Int min, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector2Int(label, property, Vector2IntRange.ToMaxFrom(min), indentLevel, false, onChangedCallback);
        
        public Vector3Int DrawMinVector3Int(GUIContent label, MaterialProperty property, Vector3Int min, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector3Int(label, property, Vector3IntRange.ToMaxFrom(min), indentLevel, false, onChangedCallback);
        
        public Vector2Int DrawMinIntFromVector2Int(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            int min = 0, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawIntFromVector2Int(label, property, vector2Param, IntRange.ToMaxFrom(min), indentLevel, false, onChangedCallback);
        
        public Vector3Int DrawMinIntFromVector3Int(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            int min = 0, int indentLevel = 0, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawIntFromVector3Int(label, property, vector3Param, IntRange.ToMaxFrom(min), indentLevel, false, onChangedCallback);
        
        #endregion
        
        #region ColorEditorRegion
        
        public Color DrawColor(GUIContent label, MaterialProperty property, bool showAlpha = true, 
            bool hdr = false, int indentLevel = 0, Action onChangedCallback = null) =>
            _colorPropertyEditor.DrawColor(label, property, showAlpha, hdr, indentLevel, false, onChangedCallback);
        
        #endregion
        
        #region TextureEditorRegion

        public Texture DrawTexture(GUIContent label, MaterialProperty property, int indentLevel = 0, Action onChangedCallback = null) =>
            _texturePropertyEditor.DrawTexture(label, property, indentLevel, false, onChangedCallback);
        
        public void DrawSingleLineTexture(GUIContent label, MaterialProperty textureProperty, int indentLevel = 0) =>
            _texturePropertyEditor.DrawSingleLineTexture(MaterialEditor, label, textureProperty, indentLevel);
        
        public void DrawSingleLineTexture(GUIContent label, MaterialProperty textureProperty, 
            MaterialProperty secondProperty, int indentLevel = 0) =>
            _texturePropertyEditor.DrawSingleLineTexture(MaterialEditor, label, textureProperty, secondProperty, indentLevel);
        
        public void DrawSingleLineTextureWithHDRColor(GUIContent label, MaterialProperty textureProperty, 
            MaterialProperty colorProperty, bool showAlpha = false, int indentLevel = 0) =>
            _texturePropertyEditor.DrawSingleLineTextureWithHDRColor(MaterialEditor, label, textureProperty, colorProperty, showAlpha, indentLevel);
        
        public void DrawSingleLineTextureWithHDRColor(GUIContent label, MaterialProperty textureProperty, 
            MaterialProperty colorProperty, int indentLevel = 0) =>
            _texturePropertyEditor.DrawSingleLineTextureWithHDRColor(MaterialEditor, label, textureProperty, colorProperty, false, indentLevel);
        
        public void DrawSingleLineNormalTexture(GUIContent label, MaterialProperty normalMap, 
            MaterialProperty normalMapScale = null, int indentLevel = 0) =>
            _texturePropertyEditor.DrawSingleLineNormalTexture(MaterialEditor, label, normalMap, normalMapScale, indentLevel);
        
        public void DrawTextureScaleOffset(MaterialProperty textureProperty, int indentLevel = 0) =>
            _texturePropertyEditor.DrawTextureScaleOffset(MaterialEditor, textureProperty, indentLevel);
        
        #endregion
        
        #region PopupEditorRegion
        
        public TEnum DrawEnumPopup<TEnum>(MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawEnumPopup<TEnum, MaterialProperty>(property, indentLevel, false, onChangedCallback);
        
        public TEnum DrawEnumPopup<TEnum>(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawEnumPopup<TEnum, MaterialProperty>(label, property, indentLevel, false, onChangedCallback);
        
        public TEnum DrawBooleanPopup<TEnum>(MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawBooleanPopup<TEnum, MaterialProperty>(property, indentLevel, false, onChangedCallback);
        
        public TEnum DrawBooleanPopup<TEnum>(GUIContent label, MaterialProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawBooleanPopup<TEnum, MaterialProperty>(label, property, indentLevel, false, onChangedCallback);
        
        public TEnum DrawShaderLocalKeywordBooleanPopup<TEnum>(Material material, MaterialProperty property,
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawShaderLocalKeywordBooleanPopup<TEnum, MaterialProperty>(material, property, shaderGlobalKeyword, 
                indentLevel, false, onChangedCallback);
        
        public TEnum DrawShaderLocalKeywordBooleanPopup<TEnum>(GUIContent label, Material material, MaterialProperty property, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawShaderLocalKeywordBooleanPopup<TEnum, MaterialProperty>(label, material, property, 
                shaderGlobalKeyword, indentLevel, false, onChangedCallback);
        
        public TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(MaterialProperty property, string shaderGlobalKeyword, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawShaderGlobalKeywordBooleanPopup<TEnum, MaterialProperty>(property, shaderGlobalKeyword, 
                indentLevel, false, onChangedCallback);
        
        public TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, MaterialProperty property, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawShaderGlobalKeywordBooleanPopup<TEnum, MaterialProperty>(label, property, 
                shaderGlobalKeyword, indentLevel, false, onChangedCallback);
        
        public int DrawPopup(GUIContent label, MaterialProperty property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null)  =>
            _popupPropertyEditor.DrawPopup(label, property, displayedOptions, indentLevel, false, onChangedCallback);
        
        public int DrawBooleanPopup(GUIContent label, MaterialProperty property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _popupPropertyEditor.DrawBooleanPopup(label, property, displayedOptions, indentLevel, false, onChangedCallback);
        
        public int DrawShaderLocalKeywordBooleanPopup(GUIContent label, Material material, MaterialProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) =>
            _popupPropertyEditor.DrawShaderLocalKeywordBooleanPopup(label, material, property, displayedOptions, shaderGlobalKeyword, 
                indentLevel, false, onChangedCallback);
        
        public int DrawShaderGlobalKeywordBooleanPopup(GUIContent label, MaterialProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) =>
            _popupPropertyEditor.DrawShaderGlobalKeywordBooleanPopup(label, property, displayedOptions, shaderGlobalKeyword, 
                indentLevel, false, onChangedCallback);
        
        #endregion
        
        #region ObjectEditorRegion
            
        public void DrawMaterialAssetObject(
            Material material,
            MaterialProperty assetProperty,
            MaterialProperty hashProperty,
            Func<MaterialAssetObject> drawObjectField,
            int indentLevel = 0,
            Action onChangedCallback = null) =>
            _objectPropertyEditor.DrawMaterialAssetObject(material, MaterialEditor, assetProperty, hashProperty, drawObjectField, 
                indentLevel, onChangedCallback);
        
        public T GetMaterialAssetObjectFromGuid<T>(string guid) where T : MaterialAssetObject => 
            _objectPropertyEditor.GetMaterialAssetObjectFromGuid<T>(guid);

        #endregion
        
        #region TextEditorRegion
        
        public GUIContent DrawLabel(GUIContent label, GUIContent label2, int indentLevel = 0) =>
            _textPropertyEditor.DrawLabel(label, label2, indentLevel);
        
        public GUIContent DrawLabel(GUIContent label, int indentLevel = 0) =>
            _textPropertyEditor.DrawLabel(label, new GUIContent(string.Empty), indentLevel);
        
        public bool DrawLinkText(GUIContent label, int indentLevel = 0) =>
            _textPropertyEditor.DrawLinkText(label, indentLevel);
        
        public bool DrawLinkText(GUIContent label, string url, int indentLevel = 0) =>
            _textPropertyEditor.DrawLinkText(label, url, indentLevel);
        
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