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
        public readonly SliderEditor SliderEditor;
        public readonly ToggleEditor ToggleEditor;
        public readonly VectorEditor VectorEditor;
        public readonly TextureEditor TextureEditor;
        public readonly PopupEditor PopupEditor;
        
        public ShadowShardEditor()
        {
            Utils = new EditorUtils();
            
            SliderEditor = new SliderEditor(Utils);
            ToggleEditor = new ToggleEditor(Utils);
            VectorEditor = new VectorEditor(Utils);
            TextureEditor = new TextureEditor(Utils);
            PopupEditor = new PopupEditor(Utils);
        }

        #region SliderEditorRegion
        
        public float DrawSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0) =>
            SliderEditor.DrawSlider(label, property, range, indentLevel);
        
        public float DrawSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            SliderEditor.DrawSlider(label, property, indentLevel);

        public int DrawIntSlider(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0) =>
            SliderEditor.DrawIntSlider(label, property, range, indentLevel);
        
        public int DrawIntSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            SliderEditor.DrawIntSlider(label, property, indentLevel);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, SerializedProperty maxProperty, FloatRange range, int indentLevel = 0) =>
            SliderEditor.DrawMinMaxSlider(label, minProperty, maxProperty, range, indentLevel);
        
        public FloatRange DrawMinMaxSlider(GUIContent label, SerializedProperty minProperty, SerializedProperty maxProperty, int indentLevel = 0) =>
            SliderEditor.DrawMinMaxSlider(label, minProperty, maxProperty, indentLevel);
        
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
        
        public void IncludeMaterialEditor(MaterialEditor materialEditor) => 
            MaterialEditor = materialEditor;
        
        public IEnumerable<Object> GetTargets() => 
            MaterialEditor.targets;
    }
}