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
        public MaterialEditor MaterialEditor;
        public readonly EditorUtils Utils;
        public readonly GroupEditor GroupEditor;
        public readonly SliderEditor SliderEditor;
        public readonly ToggleEditor ToggleEditor;
        public readonly VectorEditor VectorEditor;
        public readonly TextureEditor TextureEditor;
        public readonly PopupEditor PopupEditor;
        
        public ShadowShardEditor()
        {
            Utils = new EditorUtils();
            GroupEditor = new GroupEditor();
            SliderEditor = new SliderEditor(GroupEditor);
            ToggleEditor = new ToggleEditor(GroupEditor);
            VectorEditor = new VectorEditor(GroupEditor);
            TextureEditor = new TextureEditor(GroupEditor);
            PopupEditor = new PopupEditor(GroupEditor);
        }
        
        #region GroupEditorRegion

        public void DrawVertical(GUIStyle styles, Action drawCall) =>
            GroupEditor.DrawVertical(styles, drawCall);
        
        public void DrawIndented(int indentLevel, Action drawCall) =>
            GroupEditor.DrawIndented(indentLevel, drawCall);
        
        public void DrawDisabled(bool isDisabled, Action drawCall) =>
            GroupEditor.DrawDisabled(isDisabled, drawCall);
        
        public void DrawIndentedDisabled(int indentLevel, bool isDisabled, Action drawCall) =>
            GroupEditor.DrawIndentedDisabled(indentLevel, isDisabled, drawCall);
        
        public void DrawGroup(bool isDisabled, Action drawCall) =>
            GroupEditor.DrawGroup(isDisabled, drawCall);
        
        public void DrawGroup(Action drawCall) =>
            GroupEditor.DrawGroup(false, drawCall);
        
        public void DrawGroup(GUIContent label, bool isDisabled, Action drawCall) =>
            GroupEditor.DrawGroup(label, isDisabled, drawCall);
        
        public void DrawGroup(GUIContent label, Action drawCall) =>
            GroupEditor.DrawGroup(label, false, drawCall);
        
        #endregion

        #region SliderEditorRegion
        
        public float DrawSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0) =>
            SliderEditor.DrawSlider(label, property, range, indentLevel);
        
        public float DrawSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            SliderEditor.DrawSlider(label, property, FloatRange.Normalized, indentLevel);

        public int DrawIntSlider(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0) =>
            SliderEditor.DrawIntSlider(label, property, range, indentLevel);
        
        public int DrawIntSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            SliderEditor.DrawIntSlider(label, property, IntRange.Normalized, indentLevel);
        public void DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, FloatRange range, int indentLevel = 0) =>
            SliderEditor.DrawFromVector3ParamSlider(label, property, vectorParam, range, indentLevel);
        
        public void DrawFromVector3ParamSlider(GUIContent label, SerializedProperty property, Vector3Param vectorParam, int indentLevel = 0) =>
            SliderEditor.DrawFromVector3ParamSlider(label, property, vectorParam, FloatRange.Normalized, indentLevel);
        
        public void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, SerializedProperty property, FloatRange range, int indentLevel = 0) =>
            SliderEditor.DrawVector3Sliders(labelX, labelY, labelZ, property, range, indentLevel);
        
        public void DrawVector3Sliders(GUIContent labelX, GUIContent labelY, GUIContent labelZ, SerializedProperty property, int indentLevel = 0) =>
            SliderEditor.DrawVector3Sliders(labelX, labelY, labelZ, property, FloatRange.Normalized, indentLevel);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, SerializedProperty maxProperty, FloatRange range, int indentLevel = 0) =>
            SliderEditor.DrawMinMaxSlider(label, minProperty, maxProperty, range, indentLevel);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, SerializedProperty maxProperty, int indentLevel = 0) =>
            SliderEditor.DrawMinMaxSlider(label, minProperty, maxProperty, FloatRange.Normalized, indentLevel);
        
        public FloatRange DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0) =>
            SliderEditor.DrawMinMaxVector4StartSlider(label, property, range, indentLevel);
        
        public FloatRange DrawMinMaxVector4StartSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            SliderEditor.DrawMinMaxVector4StartSlider(label, property, indentLevel);
        
        public FloatRange DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0) =>
            SliderEditor.DrawMinMaxVector4EndSlider(label, property, range, indentLevel);
        
        public FloatRange DrawMinMaxVector4EndSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            SliderEditor.DrawMinMaxVector4EndSlider(label, property, indentLevel);

        #endregion
        
        #region ToggleEditorRegion

        public bool DrawToggle(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            ToggleEditor.DrawToggle(label, property, indentLevel);
        
        public bool DrawShaderGlobalKeywordToggle(GUIContent label, SerializedProperty property, string shaderGlobalKeyword, int indentLevel = 0) =>
            ToggleEditor.DrawShaderGlobalKeywordToggle(label, property, shaderGlobalKeyword, indentLevel);
        
        #endregion
        
        #region VectorEditorRegion

        public float DrawFloat(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0) =>
            VectorEditor.DrawFloat(label, property, range, indentLevel);
        
        public float DrawFloat(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            VectorEditor.DrawFloat(label, property, indentLevel);
        
        public float DrawNormalizedFloat(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            VectorEditor.DrawNormalizedFloat(label, property, indentLevel);
        
        public float DrawMinFloat(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            VectorEditor.DrawMinFloat(label, property, indentLevel);
        
        public Vector2 DrawVector2(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            VectorEditor.DrawVector2(label, property, indentLevel);
        
        public Vector3 DrawVector3(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            VectorEditor.DrawVector3(label, property, indentLevel);
        
        public Vector4 DrawVector4(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            VectorEditor.DrawVector4(label, property, indentLevel);
        
        public Color DrawColor(GUIContent label, SerializedProperty property, bool showAlpha = true, bool hdr = false, int indentLevel = 0) =>
            VectorEditor.DrawColor(label, property, showAlpha, hdr, indentLevel);
        
        #endregion
        
        #region TextureEditorRegion

        public Texture2D DrawTexture(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            TextureEditor.DrawTexture(label, property, indentLevel);
        
        public Texture2D DrawSmallTextureField(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            TextureEditor.DrawSmallTextureField(label, property, indentLevel);
        
        #endregion
        
        #region PopupEditorRegion
        
        public TEnum DrawEnumPopup<TEnum>(SerializedProperty property, int indentLevel = 0) where TEnum : Enum =>
            PopupEditor.DrawEnumPopup<TEnum>(property, indentLevel);
        
        public TEnum DrawEnumPopup<TEnum>(GUIContent label, SerializedProperty property, int indentLevel = 0) where TEnum : Enum =>
            PopupEditor.DrawEnumPopup<TEnum>(label, property, indentLevel);
        
        public int DrawPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, int indentLevel = 0) =>
            PopupEditor.DrawPopup(label, property, displayedOptions, indentLevel);
        
        public bool DrawBooleanPopup(GUIContent label, SerializedProperty property, string[] displayedOptions, int indentLevel = 0) =>
            PopupEditor.DrawBooleanPopup(label, property, displayedOptions, indentLevel);
        
        public bool DrawShaderGlobalKeywordBooleanPopup(GUIContent label, SerializedProperty property, 
            string[] displayedOptions, string shaderGlobalKeyword, int indentLevel = 0) =>
            PopupEditor.DrawShaderGlobalKeywordBooleanPopup(label, property, displayedOptions, shaderGlobalKeyword, indentLevel);
        
        #endregion
        
        public void IncludeMaterialEditor(MaterialEditor materialEditor) => 
            MaterialEditor = materialEditor;
        
        public IEnumerable<Object> GetTargets() => 
            MaterialEditor.targets;
    }
}