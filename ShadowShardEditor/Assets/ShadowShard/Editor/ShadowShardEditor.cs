using System;
using System.Collections.Generic;
using System.IO;
using ShadowShard.Editor.Range;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShadowShard.Editor
{
    public class ShadowShardEditor
    {
        public UnityEditor.MaterialEditor MaterialEditor;
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

        public float DrawSlider(GUIContent label, SerializedProperty property, FloatRange range, int indentLevel = 0) =>
            SliderEditor.DrawSlider(label, property, range, indentLevel);
        
        public float DrawSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            SliderEditor.DrawSlider(label, property, indentLevel);

        public int DrawIntSlider(GUIContent label, SerializedProperty property, IntRange range, int indentLevel = 0) =>
            SliderEditor.DrawIntSlider(label, property, range, indentLevel);
        
        public int DrawIntSlider(GUIContent label, SerializedProperty property, int indentLevel = 0) =>
            SliderEditor.DrawIntSlider(label, property, indentLevel);
        
        
        public void IncludeMaterialEditor(UnityEditor.MaterialEditor materialEditor) => 
            MaterialEditor = materialEditor;
        
        public IEnumerable<Object> GetTargets() => 
            MaterialEditor.targets;
    }
}