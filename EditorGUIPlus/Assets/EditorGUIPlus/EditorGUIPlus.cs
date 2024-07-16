using System;
using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using EditorGUIPlus.EditorModules;
using EditorGUIPlus.EditorModules.PropertyBased;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EditorGUIPlus
{
    public sealed partial class EditorGUIPlus : IEditorGUIPlus
    {
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
        private readonly CurvePropertyEditor _curvePropertyEditor;
        private readonly FieldDrawer _fieldDrawer;
        
        public EditorGUIPlus()
        {
            PropertyService propertyService = new();
            GroupEditor groupEditor = new();

            InitializeBaseEditors();
            
            _sliderPropertyEditor = new SliderPropertyEditor(propertyService, groupEditor);
            _intSliderPropertyEditor = new IntSliderPropertyEditor(propertyService, groupEditor);
            _togglePropertyEditor = new TogglePropertyEditor(propertyService, groupEditor);
            _vectorPropertyEditor = new VectorPropertyEditor(propertyService, groupEditor);
            _intVectorPropertyEditor = new IntVectorPropertyEditor(propertyService, groupEditor);
            _colorPropertyEditor = new ColorPropertyEditor(propertyService, groupEditor);
            _texturePropertyEditor = new TexturePropertyEditor(propertyService, groupEditor);
            _popupPropertyEditor = new PopupPropertyEditor(propertyService, groupEditor);
            _objectPropertyEditor = new ObjectPropertyEditor(groupEditor);
            _textPropertyEditor = new TextPropertyEditor(groupEditor);
            _curvePropertyEditor = new CurvePropertyEditor(groupEditor);
            _fieldDrawer = new FieldDrawer();
        }
        
        #region SliderEditorRegion
        
        public float DrawSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawSlider(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public float DrawSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawSlider(label, property, FloatRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3 DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawFromVector3ParamSlider(label, property, vectorParam, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3 DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawFromVector3ParamSlider(label, property, vectorParam, FloatRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3 DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawVector3Sliders(labelX, labelY, labelZ, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3 DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawVector3Sliders(labelX, labelY, labelZ, property, FloatRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, 
            SerializedProperty maxProperty, FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawMinMaxSlider(label, minProperty, maxProperty, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, 
            SerializedProperty maxProperty, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawMinMaxSlider(label, minProperty, maxProperty, FloatRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, FloatRange range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawMinMaxVector4StartSlider(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawMinMaxVector4StartSlider(label, property, FloatRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, FloatRange range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawMinMaxVector4EndSlider(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _sliderPropertyEditor.DrawMinMaxVector4EndSlider(label, property, FloatRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);

        #endregion
        
        #region SliderIntEditorRegion

        public int DrawIntSlider(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intSliderPropertyEditor.DrawIntSlider(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public int DrawIntSlider(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intSliderPropertyEditor.DrawIntSlider(label, property, IntRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3Int DrawFromVector3IntParamSlider(GUIContent label, SerializedProperty property, 
            Vector3Param vectorParam, IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intSliderPropertyEditor.DrawFromVector3IntParamSlider(label, property, vectorParam, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3Int DrawFromVector3IntParamSlider(GUIContent label, SerializedProperty property, 
            Vector3Param vectorParam, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intSliderPropertyEditor.DrawFromVector3IntParamSlider(label, property, vectorParam, IntRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3Int DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intSliderPropertyEditor.DrawVector3IntSliders(labelX, labelY, labelZ, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3Int DrawVector3IntSliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, 
            SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intSliderPropertyEditor.DrawVector3IntSliders(labelX, labelY, labelZ, property, IntRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);

        #endregion
        
        #region ToggleEditorRegion

        public bool DrawToggle(GUIContent label, SerializedProperty property, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _togglePropertyEditor.DrawToggle(label, property, toggleAlign, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public bool DrawToggle(GUIContent label, SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _togglePropertyEditor.DrawToggle(label, property, ToggleAlign.Right, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, SerializedProperty property,
            string shaderLocalKeyword, ToggleAlign toggleAlign = ToggleAlign.Right, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _togglePropertyEditor.DrawShaderLocalKeywordToggle(label, material, property, shaderLocalKeyword, toggleAlign, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public bool DrawShaderLocalKeywordToggle(GUIContent label, Material material, SerializedProperty property,
            string shaderLocalKeyword, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _togglePropertyEditor.DrawShaderLocalKeywordToggle(label, material, property, shaderLocalKeyword, ToggleAlign.Right, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public bool DrawShaderGlobalKeywordToggle(GUIContent label, SerializedProperty property, string shaderGlobalKeyword, 
            ToggleAlign toggleAlign = ToggleAlign.Right, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _togglePropertyEditor.DrawShaderGlobalKeywordToggle(label, property, shaderGlobalKeyword, toggleAlign, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public bool DrawShaderGlobalKeywordToggle(GUIContent label, SerializedProperty property, string shaderGlobalKeyword, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _togglePropertyEditor.DrawShaderGlobalKeywordToggle(label, property, shaderGlobalKeyword, ToggleAlign.Right, indentLevel, applyModifiedProperties, onChangedCallback);
        
        #endregion
        
        #region VectorEditorRegion

        public float DrawFloat(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloat(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public double DrawDouble(GUIContent label, SerializedProperty property, DoubleRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawDouble(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector2 DrawVector2(GUIContent label, SerializedProperty property, Vector2Range range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector2(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3 DrawVector3(GUIContent label, SerializedProperty property, Vector3Range range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector3(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawVector4(GUIContent label, SerializedProperty property, Vector4Range range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public float DrawFloat(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloat(label, property, FloatRange.Full, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public double DrawDouble(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawDouble(label, property, DoubleRange.Full, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector2 DrawVector2(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector2(label, property, Vector2Range.Full, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3 DrawVector3(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector3(label, property, Vector3Range.Full, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawVector4(GUIContent label, SerializedProperty property, int indentLevel = 0,
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4(label, property, Vector4Range.Full, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawVector4Start(GUIContent label, SerializedProperty property, Vector2Range range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4Start(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawVector4Start(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4Start(label, property, Vector2Range.Full, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawVector4End(GUIContent label, SerializedProperty property, Vector2Range range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4End(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawVector4End(GUIContent label, SerializedProperty property, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4End(label, property, Vector2Range.Full, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector2 DrawFloatFromVector2(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector2(label, property, vector2Param, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3 DrawFloatFromVector3(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector3(label, property, vector3Param, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawFloatFromVector4(GUIContent label, SerializedProperty property, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector4(label, property, vector4Param, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public float DrawNormalizedFloat(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloat(label, property, FloatRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public double DrawNormalizedDouble(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawDouble(label, property, DoubleRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector2 DrawNormalizedVector2(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector2(label, property, Vector2Range.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3 DrawNormalizedVector3(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector3(label, property, Vector3Range.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawNormalizedVector4(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4(label, property, Vector4Range.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector2 DrawNormalizedFloatFromVector2(GUIContent label, SerializedProperty property, 
            Vector2Param vector2Param, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector2(label, property, vector2Param, FloatRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3 DrawNormalizedFloatFromVector3(GUIContent label, SerializedProperty property, 
            Vector3Param vector3Param, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector3(label, property, vector3Param, FloatRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawNormalizedFloatFromVector4(GUIContent label, SerializedProperty property, 
            Vector4Param vector4Param, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector4(label, property, vector4Param, FloatRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawNormalizedVector4Start(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4Start(label, property, Vector2Range.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawNormalizedVector4End(GUIContent label, SerializedProperty property, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4End(label, property, Vector2Range.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public float DrawMinFloat(GUIContent label, SerializedProperty property, float min = 0.0f, int indentLevel = 0,
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloat(label, property, FloatRange.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public double DrawMinDouble(GUIContent label, SerializedProperty property, double min = 0.0, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawDouble(label, property, DoubleRange.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector2 DrawMinVector2(GUIContent label, SerializedProperty property, Vector2 min, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector2(label, property, Vector2Range.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3 DrawMinVector3(GUIContent label, SerializedProperty property, Vector3 min, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector3(label, property, Vector3Range.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawMinVector4(GUIContent label, SerializedProperty property, Vector4 min, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4(label, property, Vector4Range.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector2 DrawMinFloatFromVector2(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            float min = 0.0f, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector2(label, property, vector2Param, FloatRange.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3 DrawMinFloatFromVector3(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            float min = 0.0f, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector3(label, property, vector3Param, FloatRange.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawMinFloatFromVector4(GUIContent label, SerializedProperty property, Vector4Param vector4Param, 
            float min = 0.0f, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawFloatFromVector4(label, property, vector4Param, FloatRange.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector4 DrawMinVector4Start(GUIContent label, SerializedProperty property, Vector2 min, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawVector4Start(label, property, Vector2Range.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Bounds DrawBoundsField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawBoundsField(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Rect DrawRectField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _vectorPropertyEditor.DrawRectField(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        #endregion
        
        #region VectorIntEditorRegion

        public int DrawInt(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawInt(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public long DrawLong(GUIContent label, SerializedProperty property, LongRange range, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawLong(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector2Int DrawVector2Int(GUIContent label, SerializedProperty property, Vector2IntRange range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector2Int(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3Int DrawVector3Int(GUIContent label, SerializedProperty property, Vector3IntRange range, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector3Int(label, property, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public int DrawInt(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawInt(label, property, IntRange.Full, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public long DrawLong(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawLong(label, property, LongRange.Full, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector2Int DrawVector2Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector2Int(label, property, Vector2IntRange.Full, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3Int DrawVector3Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector3Int(label, property, Vector3IntRange.Full, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector2Int DrawIntFromVector2Int(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawIntFromVector2Int(label, property, vector2Param, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3Int DrawIntFromVector3Int(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            IntRange range, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawIntFromVector3Int(label, property, vector3Param, range, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public int DrawNormalizedInt(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawInt(label, property, IntRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public long DrawNormalizedLong(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawLong(label, property, LongRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector2Int DrawNormalizedVector2Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector2Int(label, property, Vector2IntRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3Int DrawNormalizedVector3Int(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector3Int(label, property, Vector3IntRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector2Int DrawNormalizedIntFromVector2Int(GUIContent label, SerializedProperty property, 
            Vector2Param vector2Param, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawIntFromVector2Int(label, property, vector2Param, IntRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3Int DrawNormalizedIntFromVector3Int(GUIContent label, SerializedProperty property, 
            Vector3Param vector3Param, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawIntFromVector3Int(label, property, vector3Param, IntRange.Normalized, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public int DrawMinInt(GUIContent label, SerializedProperty property, int min = 0, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawInt(label, property, IntRange.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public long DrawNormalizedLong(GUIContent label, SerializedProperty property, long min = 0, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawLong(label, property, LongRange.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector2Int DrawMinVector2Int(GUIContent label, SerializedProperty property, Vector2Int min, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector2Int(label, property, Vector2IntRange.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3Int DrawMinVector3Int(GUIContent label, SerializedProperty property, Vector3Int min, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawVector3Int(label, property, Vector3IntRange.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector2Int DrawMinIntFromVector2Int(GUIContent label, SerializedProperty property, Vector2Param vector2Param, 
            int min = 0, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawIntFromVector2Int(label, property, vector2Param, IntRange.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Vector3Int DrawMinIntFromVector3Int(GUIContent label, SerializedProperty property, Vector3Param vector3Param, 
            int min = 0, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawIntFromVector3Int(label, property, vector3Param, IntRange.ToMaxFrom(min), indentLevel, applyModifiedProperties, onChangedCallback);
        
        public BoundsInt DrawIntBoundsField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawIntBoundsField(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public RectInt DrawIntRectField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _intVectorPropertyEditor.DrawIntRectField(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        #endregion
        
        #region ColorEditorRegion
        
        public Color DrawColor(GUIContent label, SerializedProperty property, bool showAlpha = true, 
            bool hdr = false, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _colorPropertyEditor.DrawColor(label, property, showAlpha, hdr, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public Gradient DrawGradient(GUIContent label, SerializedProperty property, bool hdr = false, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _colorPropertyEditor.DrawGradient(label, property, hdr, indentLevel, applyModifiedProperties, onChangedCallback);
        
        #endregion
        
        #region TextureEditorRegion

        public Texture DrawTexture(GUIContent label, SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _texturePropertyEditor.DrawTexture(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        #endregion
        
        #region PopupEditorRegion
        
        public TEnum DrawEnumPopup<TEnum>(SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawEnumPopup<TEnum, SerializedProperty>(property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public TEnum DrawEnumPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawEnumPopup<TEnum, SerializedProperty>(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public void DrawEnumPopup(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _popupPropertyEditor.DrawEnumPopup(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public TEnum DrawEnumFlagsField<TEnum>(GUIContent label, SerializedProperty property, bool includeObsolete = false,  
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawEnumFlagsField<TEnum>(label, property, includeObsolete, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public TEnum DrawBooleanPopup<TEnum>(SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawBooleanPopup<TEnum, SerializedProperty>(property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public TEnum DrawBooleanPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawBooleanPopup<TEnum, SerializedProperty>(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(SerializedProperty property, string shaderGlobalKeyword, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawShaderGlobalKeywordBooleanPopup<TEnum, SerializedProperty>(property, shaderGlobalKeyword, 
                indentLevel, applyModifiedProperties, onChangedCallback);
        
        public TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, SerializedProperty property, 
            string shaderGlobalKeyword, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) where TEnum : Enum =>
            _popupPropertyEditor.DrawShaderGlobalKeywordBooleanPopup<TEnum, SerializedProperty>(label, property, 
                shaderGlobalKeyword, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public int DrawPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)  =>
            _popupPropertyEditor.DrawPopup(label, property, displayedOptions, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public int DrawBooleanPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _popupPropertyEditor.DrawBooleanPopup(label, property, displayedOptions, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public int DrawShaderGlobalKeywordBooleanPopup(GUIContent label, SerializedProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _popupPropertyEditor.DrawShaderGlobalKeywordBooleanPopup(label, property, displayedOptions, shaderGlobalKeyword, 
                indentLevel, applyModifiedProperties, onChangedCallback);
        
        public string DrawTagField(GUIContent label, SerializedProperty property,
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _popupPropertyEditor.DrawTagField(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public int DrawLayerField(GUIContent label, SerializedProperty property,
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _popupPropertyEditor.DrawLayerField(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public int DrawMaskField(GUIContent label, SerializedProperty property, string[] displayedOptions, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _popupPropertyEditor.DrawMaskField(label, property, displayedOptions, indentLevel, applyModifiedProperties, onChangedCallback);
        
        #endregion
        
        #region ObjectEditorRegion

        public void DrawObjectField<TObject>(GUIContent label, SerializedProperty property, int indentLevel = 0,
            bool allowSceneObjects = true, bool applyModifiedProperties = false, Action<TObject> onChangedCallback = null) where TObject : Object =>
            _objectPropertyEditor.DrawObjectField(label, property, indentLevel, allowSceneObjects, applyModifiedProperties, onChangedCallback);
        
        public void DrawObjectField(GUIContent label, SerializedProperty property, int indentLevel = 0,
            bool allowSceneObjects = true, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _objectPropertyEditor.DrawObjectField(label, property, indentLevel, allowSceneObjects, applyModifiedProperties, onChangedCallback);
        
        #endregion
        
        #region TextEditorRegion
        
        public string DrawTextField(GUIContent label, SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _textPropertyEditor.DrawTextField(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public string DrawTextArea(GUIContent label, SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _textPropertyEditor.DrawTextArea(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public string DrawTextArea(SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _textPropertyEditor.DrawTextArea(new GUIContent(string.Empty), property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public string DrawPasswordField(GUIContent label, SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _textPropertyEditor.DrawPasswordField(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        public string DrawFolderPathField(GUIContent label, SerializedProperty property, string defaultDirectory, 
            string defaultName, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _textPropertyEditor.DrawFolderPathField(label, property, defaultDirectory, defaultName, indentLevel, applyModifiedProperties, onChangedCallback);
        
        #endregion
        
        #region CurveEditorRegion

        public AnimationCurve DrawAnimationCurve(GUIContent label, SerializedProperty property, int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _curvePropertyEditor.DrawAnimationCurve(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
        
        #endregion

        public void DrawField(GUIContent label, SerializedProperty property, int indentLevel = 0, 
            bool applyModifiedProperties = false, Action onChangedCallback = null) =>
            _fieldDrawer.DrawField(this, label, property, indentLevel, applyModifiedProperties, onChangedCallback);
    }
}