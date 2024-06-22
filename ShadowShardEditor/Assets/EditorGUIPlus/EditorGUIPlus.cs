using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using EditorGUIPlus.EditorModules;
using EditorGUIPlus.EditorModules.PropertyBased;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
using TextEditor = EditorGUIPlus.EditorModules.PropertyBased.TextEditor;

namespace EditorGUIPlus
{
    public sealed class EditorGUIPlus : BaseEditorGUIPlus
    {
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
        
        public EditorGUIPlus()
        {
            PropertyService propertyService = new();
            GroupEditor groupEditor = new();
            
            _sliderEditor = new SliderEditor(propertyService, groupEditor);
            _sliderIntEditor = new SliderIntEditor(propertyService, groupEditor);
            _toggleEditor = new ToggleEditor(propertyService, groupEditor);
            _vectorEditor = new VectorEditor(propertyService, groupEditor);
            _vectorIntEditor = new VectorIntEditor(propertyService, groupEditor);
            _colorEditor = new ColorEditor(propertyService, groupEditor);
            _textureEditor = new TextureEditor(propertyService, groupEditor);
            _popupEditor = new PopupEditor(propertyService, groupEditor);
            _objectEditor = new ObjectEditor(groupEditor);
            _textEditor = new TextEditor(groupEditor);
            _curveEditor = new CurveEditor(groupEditor);
        }

        #region SliderEditorRegion
        
        public float DrawSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderEditor.DrawSlider(label, property, range, indentLevel, onChangedCallback);
        
        public float DrawSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderEditor.DrawSlider(label, property, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3 DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawFromVector3ParamSlider(label, property, vectorParam, range, indentLevel, onChangedCallback);
        
        public Vector3 DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawFromVector3ParamSlider(label, property, vectorParam, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawVector3Sliders(labelX, labelY, labelZ, property, range, indentLevel, onChangedCallback);
        
        public void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawVector3Sliders(labelX, labelY, labelZ, property, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, 
            SerializedProperty maxProperty, FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxSlider(label, minProperty, maxProperty, range, indentLevel, onChangedCallback);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, 
            SerializedProperty maxProperty, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxSlider(label, minProperty, maxProperty, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public FloatRange DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxVector4StartSlider(label, property, range, indentLevel, onChangedCallback);
        
        public FloatRange DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxVector4StartSlider(label, property, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public FloatRange DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, FloatRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxVector4EndSlider(label, property, range, indentLevel, onChangedCallback);
        
        public FloatRange DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderEditor.DrawMinMaxVector4EndSlider(label, property, FloatRange.Normalized, indentLevel, onChangedCallback);

        #endregion
        
        #region SliderIntEditorRegion

        public int DrawIntSlider(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderIntEditor.DrawIntSlider(label, property, range, indentLevel, onChangedCallback);
        
        public int DrawIntSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _sliderIntEditor.DrawIntSlider(label, property, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3Int DrawFromVector3IntParamSlider(GUIContent label, SerializedProperty property, 
            Vector3Param vectorParam, IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderIntEditor.DrawFromVector3IntParamSlider(label, property, vectorParam, range, indentLevel, onChangedCallback);
        
        public Vector3Int DrawFromVector3IntParamSlider(GUIContent label, SerializedProperty property, 
            Vector3Param vectorParam, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderIntEditor.DrawFromVector3IntParamSlider(label, property, vectorParam, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public void DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderIntEditor.DrawVector3IntSliders(labelX, labelY, labelZ, property, range, indentLevel, onChangedCallback);
        
        public void DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null) =>
            _sliderIntEditor.DrawVector3IntSliders(labelX, labelY, labelZ, property, IntRange.Normalized, indentLevel, onChangedCallback);

        #endregion
        
        #region ToggleEditorRegion

        public bool DrawToggle(GUIContent label, SerializedProperty property, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawToggle(label, property, toggleAlign, indentLevel, onChangedCallback);
        
        public bool DrawToggle(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawToggle(label, property, ToggleAlign.Right, indentLevel, onChangedCallback);
        
        public bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, SerializedProperty property,
            string shaderLocalKeyword, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawShaderLocalKeywordToggle(label, material, property, shaderLocalKeyword, toggleAlign, indentLevel, onChangedCallback);
        
        public bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, SerializedProperty property,
            string shaderLocalKeyword, int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawShaderLocalKeywordToggle(label, material, property, shaderLocalKeyword, ToggleAlign.Right, indentLevel, onChangedCallback);
        
        public bool DrawShaderGlobalKeywordToggle(GUIContent label, SerializedProperty property, string shaderGlobalKeyword, 
            ToggleAlign toggleAlign = ToggleAlign.Right, int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawShaderGlobalKeywordToggle(label, property, shaderGlobalKeyword, toggleAlign, indentLevel, onChangedCallback);
        
        public bool DrawShaderGlobalKeywordToggle(GUIContent label, SerializedProperty property, string shaderGlobalKeyword, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _toggleEditor.DrawShaderGlobalKeywordToggle(label, property, shaderGlobalKeyword, ToggleAlign.Right, indentLevel, onChangedCallback);
        
        #endregion
        
        #region VectorEditorRegion

        public float DrawFloat(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawFloat(label, property, range, indentLevel, onChangedCallback);
        
        public double DrawDouble(GUIContent label, SerializedProperty property, DoubleRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawDouble(label, property, range, indentLevel, onChangedCallback);
        
        public Vector2 DrawVector2(GUIContent label, SerializedProperty property, Vector2Range range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector2(label, property, range, indentLevel, onChangedCallback);
        
        public Vector3 DrawVector3(GUIContent label, SerializedProperty property, Vector3Range range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector3(label, property, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4(GUIContent label, SerializedProperty property, Vector4Range range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4(label, property, range, indentLevel, onChangedCallback);
        
        public float DrawFloat(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawFloat(label, property, FloatRange.Full, indentLevel, onChangedCallback);
        
        public double DrawDouble(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawDouble(label, property, DoubleRange.Full, indentLevel, onChangedCallback);
        
        public Vector2 DrawVector2(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector2(label, property, Vector2Range.Full, indentLevel, onChangedCallback);
        
        public Vector3 DrawVector3(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector3(label, property, Vector3Range.Full, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4(GUIContent label, SerializedProperty property, int indentLevel = 0,
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4(label, property, Vector4Range.Full, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4Start(GUIContent label, SerializedProperty property, Vector2Range range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4Start(label, property, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4Start(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4Start(label, property, Vector2Range.Full, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4End(GUIContent label, SerializedProperty property, Vector2Range range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4End(label, property, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawVector4End(GUIContent label, SerializedProperty property, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4End(label, property, Vector2Range.Full, indentLevel, onChangedCallback);
        
        public Vector2 DrawFloatFromVector2(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector2(label, property, vector2Param, range, indentLevel, onChangedCallback);
        
        public Vector3 DrawFloatFromVector3(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector3(label, property, vector3Param, range, indentLevel, onChangedCallback);
        
        public Vector4 DrawFloatFromVector4(GUIContent label, SerializedProperty property, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector4(label, property, vector4Param, range, indentLevel, onChangedCallback);
        
        public float DrawNormalizedFloat(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawFloat(label, property, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public double DrawNormalizedDouble(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawDouble(label, property, DoubleRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector2 DrawNormalizedVector2(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector2(label, property, Vector2Range.Normalized, indentLevel, onChangedCallback);
        
        public Vector3 DrawNormalizedVector3(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector3(label, property, Vector3Range.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawNormalizedVector4(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4(label, property, Vector4Range.Normalized, indentLevel, onChangedCallback);
        
        public Vector2 DrawNormalizedFloatFromVector2(GUIContent label, SerializedProperty property, 
            Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector2(label, property, vector2Param, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3 DrawNormalizedFloatFromVector3(GUIContent label, SerializedProperty property, 
            Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector3(label, property, vector3Param, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawNormalizedFloatFromVector4(GUIContent label, SerializedProperty property, 
            Vector4Param vector4Param, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector4(label, property, vector4Param, FloatRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawNormalizedVector4Start(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4Start(label, property, Vector2Range.Normalized, indentLevel, onChangedCallback);
        
        public Vector4 DrawNormalizedVector4End(GUIContent label, SerializedProperty property, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4End(label, property, Vector2Range.Normalized, indentLevel, onChangedCallback);
        
        public float DrawMinFloat(GUIContent label, SerializedProperty property, float min = 0.0f, int indentLevel = 0,
            Action onChangedCallback = null) =>
            _vectorEditor.DrawFloat(label, property, FloatRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public double DrawMinDouble(GUIContent label, SerializedProperty property, double min = 0.0, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawDouble(label, property, DoubleRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector2 DrawMinVector2(GUIContent label, SerializedProperty property, Vector2 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector2(label, property, Vector2Range.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector3 DrawMinVector3(GUIContent label, SerializedProperty property, Vector3 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector3(label, property, Vector3Range.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector4 DrawMinVector4(GUIContent label, SerializedProperty property, Vector4 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4(label, property, Vector4Range.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector2 DrawMinFloatFromVector2(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector2(label, property, vector2Param, FloatRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector3 DrawMinFloatFromVector3(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector3(label, property, vector3Param, FloatRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector4 DrawMinFloatFromVector4(GUIContent label, SerializedProperty property, Vector4Param vector4Param, 
            float min = 0.0f, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorEditor.DrawFloatFromVector4(label, property, vector4Param, FloatRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector4 DrawMinVector4Start(GUIContent label, SerializedProperty property, Vector2 min, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawVector4Start(label, property, Vector2Range.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Bounds DrawBoundsField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawBoundsField(label, property, indentLevel, onChangedCallback);
        
        public Rect DrawRectField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorEditor.DrawRectField(label, property, indentLevel, onChangedCallback);
        
        #endregion
        
        #region VectorIntEditorRegion

        public int DrawInt(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawInt(label, property, range, indentLevel, onChangedCallback);
        
        public long DrawLong(GUIContent label, SerializedProperty property, LongRange range, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawLong(label, property, range, indentLevel, onChangedCallback);
        
        public Vector2Int DrawVector2Int(GUIContent label, SerializedProperty property, Vector2IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector2Int(label, property, range, indentLevel, onChangedCallback);
        
        public Vector3Int DrawVector3Int(GUIContent label, SerializedProperty property, Vector3IntRange range, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector3Int(label, property, range, indentLevel, onChangedCallback);
        
        public int DrawInt(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawInt(label, property, IntRange.Full, indentLevel, onChangedCallback);
        
        public long DrawLong(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawLong(label, property, LongRange.Full, indentLevel, onChangedCallback);
        
        public Vector2Int DrawVector2Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector2Int(label, property, Vector2IntRange.Full, indentLevel, onChangedCallback);
        
        public Vector3Int DrawVector3Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector3Int(label, property, Vector3IntRange.Full, indentLevel, onChangedCallback);
        
        public Vector2Int DrawIntFromVector2Int(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntFromVector2Int(label, property, vector2Param, range, indentLevel, onChangedCallback);
        
        public Vector3Int DrawIntFromVector3Int(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            IntRange range, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntFromVector3Int(label, property, vector3Param, range, indentLevel, onChangedCallback);
        
        public int DrawNormalizedInt(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawInt(label, property, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public long DrawNormalizedLong(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawLong(label, property, LongRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector2Int DrawNormalizedVector2Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector2Int(label, property, Vector2IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3Int DrawNormalizedVector3Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector3Int(label, property, Vector3IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector2Int DrawNormalizedIntFromVector2Int(GUIContent label, SerializedProperty property, 
            Vector2Param vector2Param, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntFromVector2Int(label, property, vector2Param, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public Vector3Int DrawNormalizedIntFromVector3Int(GUIContent label, SerializedProperty property, 
            Vector3Param vector3Param, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntFromVector3Int(label, property, vector3Param, IntRange.Normalized, indentLevel, onChangedCallback);
        
        public int DrawMinInt(GUIContent label, SerializedProperty property, int min = 0, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawInt(label, property, IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public long DrawNormalizedLong(GUIContent label, SerializedProperty property, long min = 0, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawLong(label, property, LongRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector2Int DrawMinVector2Int(GUIContent label, SerializedProperty property, Vector2Int min, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector2Int(label, property, Vector2IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector3Int DrawMinVector3Int(GUIContent label, SerializedProperty property, Vector3Int min, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawVector3Int(label, property, Vector3IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector2Int DrawMinIntFromVector2Int(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            int min = 0, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntFromVector2Int(label, property, vector2Param, IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public Vector3Int DrawMinIntFromVector3Int(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            int min = 0, int indentLevel = 0, Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntFromVector3Int(label, property, vector3Param, IntRange.ToMaxFrom(min), indentLevel, onChangedCallback);
        
        public BoundsInt DrawIntBoundsField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntBoundsField(label, property, indentLevel, onChangedCallback);
        
        public RectInt DrawIntRectField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) =>
            _vectorIntEditor.DrawIntRectField(label, property, indentLevel, onChangedCallback);
        
        #endregion
        
        #region ColorEditorRegion
        
        public Color DrawColor(GUIContent label, SerializedProperty property, bool showAlpha = true, 
            bool hdr = false, int indentLevel = 0, Action onChangedCallback = null) =>
            _colorEditor.DrawColor(label, property, showAlpha, hdr, indentLevel, onChangedCallback);
        
        public Gradient DrawGradient(GUIContent label, SerializedProperty property, bool hdr = false, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _colorEditor.DrawGradient(label, property, hdr, indentLevel, onChangedCallback);
        
        #endregion
        
        #region TextureEditorRegion

        public Texture DrawTexture(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null) =>
            _textureEditor.DrawTexture(label, property, indentLevel, onChangedCallback);
        
        #endregion
        
        #region PopupEditorRegion
        
        public TEnum DrawEnumPopup<TEnum>(SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawEnumPopup<TEnum, SerializedProperty>(property, indentLevel, onChangedCallback);
        
        public TEnum DrawEnumPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawEnumPopup<TEnum, SerializedProperty>(label, property, indentLevel, onChangedCallback);
        
        public TEnum DrawEnumFlagsField<TEnum>(GUIContent label, SerializedProperty property, bool includeObsolete = false,  
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawEnumFlagsField<TEnum>(label, property, includeObsolete, indentLevel, onChangedCallback);
        
        public TEnum DrawBooleanPopup<TEnum>(SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawBooleanPopup<TEnum, SerializedProperty>(property, indentLevel, onChangedCallback);
        
        public TEnum DrawBooleanPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawBooleanPopup<TEnum, SerializedProperty>(label, property, indentLevel, onChangedCallback);
        
        public TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(SerializedProperty property, string shaderGlobalKeyword, 
            int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawShaderGlobalKeywordBooleanPopup<TEnum, SerializedProperty>(property, shaderGlobalKeyword, 
                indentLevel, onChangedCallback);
        
        public TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, SerializedProperty property, 
            string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) where TEnum : Enum =>
            _popupEditor.DrawShaderGlobalKeywordBooleanPopup<TEnum, SerializedProperty>(label, property, 
                shaderGlobalKeyword, indentLevel, onChangedCallback);
        
        public int DrawPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null)  =>
            _popupEditor.DrawPopup(label, property, displayedOptions, indentLevel, onChangedCallback);
        
        public int DrawBooleanPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _popupEditor.DrawBooleanPopup(label, property, displayedOptions, indentLevel, onChangedCallback);
        
        public int DrawShaderGlobalKeywordBooleanPopup(GUIContent label, SerializedProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0, Action onChangedCallback = null) =>
            _popupEditor.DrawShaderGlobalKeywordBooleanPopup(label, property, displayedOptions, shaderGlobalKeyword, 
                indentLevel, onChangedCallback);
        
        public string DrawTagField(GUIContent label, SerializedProperty property,
            int indentLevel = 0, Action onChangedCallback = null) =>
            _popupEditor.DrawTagField(label, property, indentLevel, onChangedCallback);
        
        public int DrawLayerField(GUIContent label, SerializedProperty property,
            int indentLevel = 0, Action onChangedCallback = null) =>
            _popupEditor.DrawLayerField(label, property, indentLevel, onChangedCallback);
        
        public int DrawMaskField(GUIContent label, SerializedProperty property, string[] displayedOptions, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _popupEditor.DrawMaskField(label, property, displayedOptions, indentLevel, onChangedCallback);
        
        #endregion
        
        #region ObjectEditorRegion

        public void DrawObjectField<TObject>(GUIContent label, SerializedProperty property, int indentLevel = 0,
            bool allowSceneObjects = true, Action<TObject> onChangedCallback = null) where TObject : Object =>
            _objectEditor.DrawObjectField(label, property, indentLevel, allowSceneObjects, onChangedCallback);
        
        #endregion
        
        #region TextEditorRegion
        
        public string DrawTextField(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawTextField(label, property, indentLevel, onChangedCallback);
        
        public string DrawTextArea(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawTextArea(label, property, indentLevel, onChangedCallback);
        
        public string DrawTextArea(SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawTextArea(new GUIContent(string.Empty), property, indentLevel, onChangedCallback);
        
        public string DrawPasswordField(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawPasswordField(label, property, indentLevel, onChangedCallback);
        
        public string DrawFolderPathField(GUIContent label, SerializedProperty property, string defaultDirectory, 
            int indentLevel = 0, Action onChangedCallback = null) =>
            _textEditor.DrawFolderPathField(label, property, defaultDirectory, indentLevel, onChangedCallback);
        
        #endregion
        
        #region CurveEditorRegion

        public AnimationCurve DrawAnimationCurve(GUIContent label, SerializedProperty property, int indentLevel = 0, Action onChangedCallback = null) =>
            _curveEditor.DrawAnimationCurve(label, property, indentLevel, onChangedCallback);
        
        #endregion
    }
}