using System;
using System.Collections.Generic;
using System.IO;
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
        
        public void IncludeMaterialEditor(UnityEditor.MaterialEditor materialEditor) => 
            MaterialEditor = materialEditor;
        
        public IEnumerable<Object> GetTargets() => 
            MaterialEditor.targets;
    }
}