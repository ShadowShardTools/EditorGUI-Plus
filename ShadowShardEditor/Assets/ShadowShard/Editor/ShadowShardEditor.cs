using System;
using System.Collections.Generic;
using ShadowShard.Editor.Range;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShadowShard.Editor
{
    public class ShadowShardEditor
    {
        private readonly PropertyService _propertyService;
        private readonly GroupEditor _groupEditor;
        private readonly SliderEditor _sliderEditor;
        private readonly ToggleEditor _toggleEditor;
        private readonly VectorEditor _vectorEditor;
        private readonly TextureEditor _textureEditor;
        private readonly PopupEditor _popupEditor;
        private readonly TextEditor _textEditor;
        private readonly ObjectEditor _objectEditor;
        
        public ShadowShardEditor()
        {
            _propertyService = new PropertyService();
            _groupEditor = new GroupEditor();
            _sliderEditor = new SliderEditor(_propertyService, _groupEditor);
            _toggleEditor = new ToggleEditor(_groupEditor);
            _vectorEditor = new VectorEditor(_groupEditor);
            _textureEditor = new TextureEditor(_groupEditor);
            _popupEditor = new PopupEditor(_groupEditor);
            _textEditor = new TextEditor(_groupEditor);
            _objectEditor = new ObjectEditor(_groupEditor);
        }
        
        #region GroupEditorRegion

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
        
        #endregion

        #region SliderEditorRegion
        
        public float DrawSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0) =>
            _sliderEditor.DrawSlider(label, property, range, indentLevel);
        
        public float DrawSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            _sliderEditor.DrawSlider(label, property, FloatRange.Normalized, indentLevel);

        public int DrawIntSlider(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0) =>
            _sliderEditor.DrawIntSlider(label, property, range, indentLevel);
        
        public int DrawIntSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            _sliderEditor.DrawIntSlider(label, property, IntRange.Normalized, indentLevel);
        public void DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, FloatRange range, int indentLevel = 0) =>
            _sliderEditor.DrawFromVector3ParamSlider(label, property, vectorParam, range, indentLevel);
        
        public void DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, int indentLevel = 0) =>
            _sliderEditor.DrawFromVector3ParamSlider(label, property, vectorParam, FloatRange.Normalized, indentLevel);
        
        public void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, SerializedProperty property, FloatRange range, int indentLevel = 0) =>
            _sliderEditor.DrawVector3Sliders(labelX, labelY, labelZ, property, range, indentLevel);
        
        public void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, SerializedProperty property, int indentLevel = 0) =>
            _sliderEditor.DrawVector3Sliders(labelX, labelY, labelZ, property, FloatRange.Normalized, indentLevel);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, SerializedProperty maxProperty, FloatRange range, int indentLevel = 0) =>
            _sliderEditor.DrawMinMaxSlider(label, minProperty, maxProperty, range, indentLevel);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, SerializedProperty maxProperty, int indentLevel = 0) =>
            _sliderEditor.DrawMinMaxSlider(label, minProperty, maxProperty, FloatRange.Normalized, indentLevel);
        
        public FloatRange DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0) =>
            _sliderEditor.DrawMinMaxVector4StartSlider(label, property, range, indentLevel);
        
        public FloatRange DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            _sliderEditor.DrawMinMaxVector4StartSlider(label, property, indentLevel);
        
        public FloatRange DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0) =>
            _sliderEditor.DrawMinMaxVector4EndSlider(label, property, range, indentLevel);
        
        public FloatRange DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            _sliderEditor.DrawMinMaxVector4EndSlider(label, property, indentLevel);

        #endregion
        
        #region ToggleEditorRegion

        public bool DrawToggle(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            _toggleEditor.DrawToggle(label, property, indentLevel);
        
        public bool DrawShaderGlobalKeywordToggle(GUIContent label, SerializedProperty property, string shaderGlobalKeyword, int indentLevel = 0) =>
            _toggleEditor.DrawShaderGlobalKeywordToggle(label, property, shaderGlobalKeyword, indentLevel);
        
        #endregion
        
        #region VectorEditorRegion

        public float DrawFloat(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0) =>
            _vectorEditor.DrawFloat(label, property, range, indentLevel);
        
        public float DrawFloat(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawFloat(label, property, FloatRange.Full, indentLevel);
        
        public float DrawNormalizedFloat(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawFloat(label, property, FloatRange.Normalized, indentLevel);
        
        public float DrawMinFloat(GUIContent label, SerializedProperty property, float min = 0.0f, int indentLevel = 0) =>
            _vectorEditor.DrawFloat(label, property, FloatRange.ToMaxFrom(min), indentLevel);
        
        public Vector2 DrawVector2(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawVector2(label, property, indentLevel);
        
        public Vector3 DrawVector3(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawVector3(label, property, indentLevel);
        
        public Vector4 DrawVector4(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawVector4(label, property, indentLevel);
        
        public Color DrawColor(GUIContent label, SerializedProperty property, bool showAlpha = true, bool hdr = false, int indentLevel = 0) =>
            _vectorEditor.DrawColor(label, property, showAlpha, hdr, indentLevel);
        
        #endregion
        
        #region TextureEditorRegion

        public Texture2D DrawTexture(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            _textureEditor.DrawTexture(label, property, indentLevel);
        
        public Texture2D DrawSmallTextureField(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            _textureEditor.DrawSmallTextureField(label, property, indentLevel);
        
        #endregion
        
        #region PopupEditorRegion
        
        public TEnum DrawEnumPopup<TEnum>(SerializedProperty property, int indentLevel = 0) where TEnum : Enum =>
            _popupEditor.DrawEnumPopup<TEnum>(property, indentLevel);
        
        public TEnum DrawEnumPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0) where TEnum : Enum =>
            _popupEditor.DrawEnumPopup<TEnum>(label, property, indentLevel);
        
        public int DrawPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, int indentLevel = 0) =>
            _popupEditor.DrawPopup(label, property, displayedOptions, indentLevel);
        
        public bool DrawBooleanPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, int indentLevel = 0) =>
            _popupEditor.DrawBooleanPopup(label, property, displayedOptions, indentLevel);
        
        public bool DrawShaderGlobalKeywordBooleanPopup(GUIContent label, SerializedProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0) =>
            _popupEditor.DrawShaderGlobalKeywordBooleanPopup(label, property, displayedOptions, shaderGlobalKeyword, indentLevel);
        
        #endregion
        
        #region TextEditorRegion

        public string DrawTextField(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            _textEditor.DrawTextField(label, property, indentLevel);
        
        public string DrawFolderPathField(GUIContent label, SerializedProperty property, string defaultDirectory) =>
            _textEditor.DrawFolderPathField(label, property, defaultDirectory);
        
        #endregion
        
        #region ObjectEditorRegion

        public void DrawObjectField<TObject>(GUIContent label, SerializedProperty property, int indentLevel = 0,
            bool allowSceneObjects = true, Action<TObject> onChangedCallback = null) where TObject : Object =>
            _objectEditor.DrawObjectField<TObject>(label, property, indentLevel, allowSceneObjects, onChangedCallback);
        
        #endregion
    }
}