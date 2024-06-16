using System;
using ShadowShard.Editor.Enums;
using ShadowShard.Editor.MaterialEditor.AssetObject;
using ShadowShard.Editor.Range;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor.MaterialEditor
{
    public class ShadowShardMaterialEditor
    {
        private readonly GroupEditor _groupEditor;
        private readonly SliderEditor _sliderEditor;
        private readonly ToggleEditor _toggleEditor;
        private readonly VectorEditor _vectorEditor;
        private readonly VectorIntEditor _vectorIntEditor;
        private readonly TextureEditor _textureEditor;
        private readonly PopupEditor _popupEditor;
        private readonly ObjectEditor _objectEditor;
        
        public UnityEditor.MaterialEditor MaterialEditor;
        
        public ShadowShardMaterialEditor()
        {
            PropertyService propertyService = new();
            
            _groupEditor = new GroupEditor();
            _sliderEditor = new SliderEditor(propertyService, _groupEditor);
            _toggleEditor = new ToggleEditor(propertyService, _groupEditor);
            _vectorEditor = new VectorEditor(propertyService, _groupEditor);
            _vectorIntEditor = new VectorIntEditor(propertyService, _groupEditor);
            _textureEditor = new TextureEditor(propertyService, _groupEditor);
            _popupEditor = new PopupEditor(propertyService, _groupEditor);
            _objectEditor = new ObjectEditor(_groupEditor);
        }
        
        public void InitializeMaterialEditor(UnityEditor.MaterialEditor materialEditor) => 
            MaterialEditor = materialEditor;
        
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
        
        public float DrawSlider(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0) =>
            _sliderEditor.DrawSlider(label, property, range, indentLevel);
        
        public float DrawSlider(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _sliderEditor.DrawSlider(label, property, FloatRange.Normalized, indentLevel);

        public int DrawIntSlider(GUIContent label, MaterialProperty property, IntRange range, int indentLevel = 0) =>
            _sliderEditor.DrawIntSlider(label, property, range, indentLevel);
        
        public int DrawIntSlider(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _sliderEditor.DrawIntSlider(label, property, IntRange.Normalized, indentLevel);
        public void DrawFromVector3ParamSlider(GUIContent label, MaterialProperty property, Vector3Param vectorParam, FloatRange range, int indentLevel = 0) =>
            _sliderEditor.DrawFromVector3ParamSlider(label, property, vectorParam, range, indentLevel);
        
        public void DrawFromVector3ParamSlider(GUIContent label, MaterialProperty property, Vector3Param vectorParam, int indentLevel = 0) =>
            _sliderEditor.DrawFromVector3ParamSlider(label, property, vectorParam, FloatRange.Normalized, indentLevel);
        
        public void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, MaterialProperty property, FloatRange range, int indentLevel = 0) =>
            _sliderEditor.DrawVector3Sliders(labelX, labelY, labelZ, property, range, indentLevel);
        
        public void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, MaterialProperty property, int indentLevel = 0) =>
            _sliderEditor.DrawVector3Sliders(labelX, labelY, labelZ, property, FloatRange.Normalized, indentLevel);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, MaterialProperty minProperty, MaterialProperty maxProperty, FloatRange range, int indentLevel = 0) =>
            _sliderEditor.DrawMinMaxSlider(label, minProperty, maxProperty, range, indentLevel);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, MaterialProperty minProperty, MaterialProperty maxProperty, int indentLevel = 0) =>
            _sliderEditor.DrawMinMaxSlider(label, minProperty, maxProperty, FloatRange.Normalized, indentLevel);
        
        public FloatRange DrawMinMaxVector4StartSlider(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0) =>
            _sliderEditor.DrawMinMaxVector4StartSlider(label, property, range, indentLevel);
        
        public FloatRange DrawMinMaxVector4StartSlider(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _sliderEditor.DrawMinMaxVector4StartSlider(label, property, indentLevel);
        
        public FloatRange DrawMinMaxVector4EndSlider(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0) =>
            _sliderEditor.DrawMinMaxVector4EndSlider(label, property, range, indentLevel);
        
        public FloatRange DrawMinMaxVector4EndSlider(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _sliderEditor.DrawMinMaxVector4EndSlider(label, property, indentLevel);

        #endregion
        
        #region ToggleEditorRegion

        public bool DrawToggle(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _toggleEditor.DrawToggle(label, property, indentLevel);
        
        public bool DrawShaderGlobalKeywordToggle(GUIContent label, MaterialProperty property, string shaderGlobalKeyword, int indentLevel = 0) =>
            _toggleEditor.DrawShaderGlobalKeywordToggle(label, property, shaderGlobalKeyword, indentLevel);
        
        #endregion
        
        #region VectorEditorRegion

        public float DrawFloat(GUIContent label, MaterialProperty property, FloatRange range, int indentLevel = 0) =>
            _vectorEditor.DrawFloat(label, property, range, indentLevel);
        
        public Vector2 DrawVector2(GUIContent label, MaterialProperty property, Vector2Range range, int indentLevel = 0) =>
            _vectorEditor.DrawVector2(label, property, range, indentLevel);
        
        public Vector3 DrawVector3(GUIContent label, MaterialProperty property, Vector3Range range, int indentLevel = 0) =>
            _vectorEditor.DrawVector3(label, property, range, indentLevel);
        
        public Vector4 DrawVector4(GUIContent label, MaterialProperty property, Vector4Range range, int indentLevel = 0) =>
            _vectorEditor.DrawVector4(label, property, range, indentLevel);
        
        public float DrawFloat(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawFloat(label, property, FloatRange.Full, indentLevel);
        
        public Vector2 DrawVector2(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawVector2(label, property, Vector2Range.Full, indentLevel);
        
        public Vector3 DrawVector3(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawVector3(label, property, Vector3Range.Full, indentLevel);
        
        public Vector4 DrawVector4(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawVector4(label, property, Vector4Range.Full, indentLevel);
        
        public float DrawNormalizedFloat(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawFloat(label, property, FloatRange.Normalized, indentLevel);
        
        public Vector2 DrawNormalizedVector2(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawVector2(label, property, Vector2Range.Normalized, indentLevel);
        
        public Vector2 DrawNormalizedVector3(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawVector3(label, property, Vector3Range.Normalized, indentLevel);
        
        public Vector2 DrawNormalizedVector4(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawVector4(label, property, Vector4Range.Normalized, indentLevel);
        
        public Vector2 DrawNormalizedFloatFromVector2(GUIContent label, MaterialProperty property, 
            Vector2Param vector2Param, int indentLevel = 0) =>
            _vectorEditor.DrawFloatFromVector2(label, property, vector2Param, FloatRange.Normalized, indentLevel);
        
        public Vector3 DrawNormalizedFloatFromVector3(GUIContent label, MaterialProperty property, 
            Vector3Param vector3Param, int indentLevel = 0) =>
            _vectorEditor.DrawFloatFromVector3(label, property, vector3Param, FloatRange.Normalized, indentLevel);
        
        public Vector4 DrawNormalizedFloatFromVector4(GUIContent label, MaterialProperty property, 
            Vector4Param vector4Param, int indentLevel = 0) =>
            _vectorEditor.DrawFloatFromVector4(label, property, vector4Param, FloatRange.Normalized, indentLevel);
        
        public float DrawMinFloat(GUIContent label, MaterialProperty property, float min = 0.0f, int indentLevel = 0) =>
            _vectorEditor.DrawFloat(label, property, FloatRange.ToMaxFrom(min), indentLevel);
        
        public Vector2 DrawMinVector2(GUIContent label, MaterialProperty property, Vector2 min, int indentLevel = 0) =>
            _vectorEditor.DrawVector2(label, property, Vector2Range.ToMaxFrom(min), indentLevel);
        
        public Vector2 DrawMinVector3(GUIContent label, MaterialProperty property, Vector3 min, int indentLevel = 0) =>
            _vectorEditor.DrawVector3(label, property, Vector3Range.ToMaxFrom(min), indentLevel);
        
        public Vector2 DrawMinVector4(GUIContent label, MaterialProperty property, Vector4 min, int indentLevel = 0) =>
            _vectorEditor.DrawVector4(label, property, Vector4Range.ToMaxFrom(min), indentLevel);
        
        public Vector2 DrawMinFloatFromVector2(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            float min = 0.0f, int indentLevel = 0) =>
            _vectorEditor.DrawFloatFromVector2(label, property, vector2Param, FloatRange.ToMaxFrom(min), indentLevel);
        
        public Vector3 DrawMinFloatFromVector3(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            float min = 0.0f, int indentLevel = 0) =>
            _vectorEditor.DrawFloatFromVector3(label, property, vector3Param, FloatRange.ToMaxFrom(min), indentLevel);
        
        public Vector4 DrawMinFloatFromVector4(GUIContent label, MaterialProperty property, Vector4Param vector4Param, 
            float min = 0.0f, int indentLevel = 0) =>
            _vectorEditor.DrawFloatFromVector4(label, property, vector4Param, FloatRange.ToMaxFrom(min), indentLevel);
        
        public Vector2 DrawFloatFromVector2(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            FloatRange range, int indentLevel = 0) =>
            _vectorEditor.DrawFloatFromVector2(label, property, vector2Param, range, indentLevel);
        
        public Vector3 DrawFloatFromVector3(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            FloatRange range, int indentLevel = 0) =>
            _vectorEditor.DrawFloatFromVector3(label, property, vector3Param, range, indentLevel);
        
        public Vector4 DrawFloatFromVector4(GUIContent label, MaterialProperty property, Vector4Param vector4Param, 
            FloatRange range, int indentLevel = 0) =>
            _vectorEditor.DrawFloatFromVector4(label, property, vector4Param, range, indentLevel);
        public Vector4 DrawVector4Start(GUIContent label, MaterialProperty property, Vector2Range range, int indentLevel = 0) =>
            _vectorEditor.DrawVector4Start(label, property, range, indentLevel);
        
        public Vector4 DrawVector4Start(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawVector4Start(label, property, Vector2Range.Full, indentLevel);
        
        public Vector4 DrawVector4End(GUIContent label, MaterialProperty property, Vector2Range range, int indentLevel = 0) =>
            _vectorEditor.DrawVector4End(label, property, range, indentLevel);
        
        public Vector4 DrawVector4End(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _vectorEditor.DrawVector4End(label, property, Vector2Range.Full, indentLevel);
        
        public Color DrawColor(GUIContent label, MaterialProperty property, bool showAlpha = true, bool hdr = false, int indentLevel = 0) =>
            _vectorEditor.DrawColor(label, property, showAlpha, hdr, indentLevel);
        
        #endregion
        
        #region VectorIntEditorRegion

        public float DrawInt(GUIContent label, MaterialProperty property, IntRange range, int indentLevel = 0) =>
            _vectorIntEditor.DrawInt(label, property, range, indentLevel);
        
        public float DrawInt(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _vectorIntEditor.DrawInt(label, property, IntRange.Full, indentLevel);
        
        public Vector2Int DrawVector2Int(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _vectorIntEditor.DrawVector2Int(label, property, indentLevel);
        
        public Vector3Int DrawVector3Int(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _vectorIntEditor.DrawVector3Int(label, property, indentLevel);
        
        public Vector2Int DrawFloatFromVector2Int(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            IntRange range, int indentLevel = 0) =>
            _vectorIntEditor.DrawFloatFromVector2Int(label, property, vector2Param, range, indentLevel);
        
        public Vector3Int DrawFloatFromVector3(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            IntRange range, int indentLevel = 0) =>
            _vectorIntEditor.DrawFloatFromVector3Int(label, property, vector3Param, range, indentLevel);
        
        public float DrawNormalizedInt(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _vectorIntEditor.DrawInt(label, property, IntRange.Normalized, indentLevel);
        
        public Vector2Int DrawNormalizedFloatFromVector2Int(GUIContent label, MaterialProperty property, 
            Vector2Param vector2Param, int indentLevel = 0) =>
            _vectorIntEditor.DrawFloatFromVector2Int(label, property, vector2Param, IntRange.Normalized, indentLevel);
        
        public Vector3Int DrawNormalizedFloatFromVector3Int(GUIContent label, MaterialProperty property, 
            Vector3Param vector3Param, int indentLevel = 0) =>
            _vectorIntEditor.DrawFloatFromVector3Int(label, property, vector3Param, IntRange.Normalized, indentLevel);
        
        public int DrawMinInt(GUIContent label, MaterialProperty property, int min = 0, int indentLevel = 0) =>
            _vectorIntEditor.DrawInt(label, property, IntRange.ToMaxFrom(min), indentLevel);
        
        public Vector2Int DrawMinFloatFromVector2Int(GUIContent label, MaterialProperty property, Vector2Param vector2Param, 
            int min = 0, int indentLevel = 0) =>
            _vectorIntEditor.DrawFloatFromVector2Int(label, property, vector2Param, IntRange.ToMaxFrom(min), indentLevel);
        
        public Vector3Int DrawMinFloatFromVector3Int(GUIContent label, MaterialProperty property, Vector3Param vector3Param, 
            int min = 0, int indentLevel = 0) =>
            _vectorIntEditor.DrawFloatFromVector3Int(label, property, vector3Param, IntRange.ToMaxFrom(min), indentLevel);
        
        #endregion
        
        #region TextureEditorRegion

        public Texture DrawTexture(GUIContent label, MaterialProperty property, int indentLevel = 0) =>
            _textureEditor.DrawTexture(label, property, indentLevel);
        
        public void DrawSingleLineTexture(GUIContent label, MaterialProperty textureProperty, int indentLevel = 0) =>
            _textureEditor.DrawSingleLineTexture(MaterialEditor, label, textureProperty, indentLevel);
        
        public void DrawSingleLineTexture(GUIContent label, MaterialProperty textureProperty, 
            MaterialProperty secondProperty, int indentLevel = 0) =>
            _textureEditor.DrawSingleLineTexture(MaterialEditor, label, textureProperty, secondProperty, indentLevel);
        
        public void DrawSingleLineTextureWithHDRColor(GUIContent label, MaterialProperty textureProperty, 
            MaterialProperty colorProperty, bool showAlpha = false, int indentLevel = 0) =>
            _textureEditor.DrawSingleLineTextureWithHDRColor(MaterialEditor, label, textureProperty, colorProperty, showAlpha, indentLevel);
        
        public void DrawSingleLineTextureWithHDRColor(GUIContent label, MaterialProperty textureProperty, 
            MaterialProperty colorProperty, int indentLevel = 0) =>
            _textureEditor.DrawSingleLineTextureWithHDRColor(MaterialEditor, label, textureProperty, colorProperty, false, indentLevel);
        
        public void DrawSingleLineNormalTexture(GUIContent label, MaterialProperty normalMap, 
            MaterialProperty normalMapScale = null, int indentLevel = 0) =>
            _textureEditor.DrawSingleLineNormalTexture(MaterialEditor, label, normalMap, normalMapScale, indentLevel);
        
        public void DrawTextureScaleOffset(MaterialProperty textureProperty, int indentLevel = 0) =>
            _textureEditor.DrawTextureScaleOffset(MaterialEditor, textureProperty, indentLevel);
        
        #endregion
        
        #region PopupEditorRegion
        
        public TEnum DrawEnumPopup<TEnum>(MaterialProperty property, int indentLevel = 0) where TEnum : Enum =>
            _popupEditor.DrawEnumPopup<TEnum, MaterialProperty>(property, indentLevel);
        
        public TEnum DrawEnumPopup<TEnum>(GUIContent label, MaterialProperty property, int indentLevel = 0) where TEnum : Enum =>
            _popupEditor.DrawEnumPopup<TEnum, MaterialProperty>(label, property, indentLevel);
        
        public TEnum DrawBooleanPopup<TEnum>(MaterialProperty property, int indentLevel = 0) where TEnum : Enum =>
            _popupEditor.DrawBooleanPopup<TEnum, MaterialProperty>(property, indentLevel);
        
        public TEnum DrawBooleanPopup<TEnum>(GUIContent label, MaterialProperty property, int indentLevel = 0) where TEnum : Enum =>
            _popupEditor.DrawBooleanPopup<TEnum, MaterialProperty>(label, property, indentLevel);
        
        public TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(MaterialProperty property, string shaderGlobalKeyword, int indentLevel = 0) where TEnum : Enum =>
            _popupEditor.DrawShaderGlobalKeywordBooleanPopup<TEnum, MaterialProperty>(property, shaderGlobalKeyword, indentLevel);
        
        public TEnum DrawShaderGlobalKeywordBooleanPopup<TEnum>(GUIContent label, MaterialProperty property, string shaderGlobalKeyword, int indentLevel = 0) where TEnum : Enum =>
            _popupEditor.DrawShaderGlobalKeywordBooleanPopup<TEnum, MaterialProperty>(label, property, shaderGlobalKeyword, indentLevel);
        
        public int DrawPopup(GUIContent label, MaterialProperty property, string[] displayedOptions, int indentLevel = 0) =>
            _popupEditor.DrawPopup(label, property, displayedOptions, indentLevel);
        
        public int DrawBooleanPopup(GUIContent label, MaterialProperty property, string[] displayedOptions, int indentLevel = 0) =>
            _popupEditor.DrawBooleanPopup(label, property, displayedOptions, indentLevel);
        
        public int DrawShaderGlobalKeywordBooleanPopup(GUIContent label, MaterialProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0) =>
            _popupEditor.DrawShaderGlobalKeywordBooleanPopup(label, property, displayedOptions, shaderGlobalKeyword, indentLevel);
        
        #endregion
        
        #region ObjectEditorRegion
            
        public void DrawObjectField(
            GUIContent label, 
            Material material, 
            MaterialProperty assetProperty, 
            MaterialProperty hashProperty, 
            int indentLevel = 0,
            bool allowSceneObjects = false, 
            Action<MaterialAssetObject> onChangedCallback = null)=>
            _objectEditor.DrawObjectField(label, material, MaterialEditor, assetProperty, hashProperty, indentLevel, allowSceneObjects, onChangedCallback);
        
        #endregion
    }
}