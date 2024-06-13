using System;
using System.Collections.Generic;
using System.Linq;
using ShadowShard.Editor.ShaderGUI.Section;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor.ShaderGUI
{
    public class BaseShaderGUI : UnityEditor.ShaderGUI
    {
        private readonly ShadowShardEditor _shadowShardEditor = new();
        private MaterialEditor _materialEditor;
        
        protected bool FirstTimeApply = true;
        protected static Vector2 IconSize = new(5, 5);
        protected const string BaseOffsetPropertyName = "_BaseMap";

        protected List<ISection> Sections = new();

        public virtual void MaterialChanged(Material material) => 
            ValidateMaterial(material);
        
        public override void ValidateMaterial(Material material) => 
            SetKeywords(material);
        
        public virtual void OnOpenGUI(Material material) => 
            Sections = new List<ISection>();

        public virtual void OnUpdateGUI(Material material) { }
        
        public virtual IEnumerable<ISection> SetSections(Material material) => 
            Sections = new List<ISection>();

        public override void OnGUI(MaterialEditor materialEditorIn, MaterialProperty[] properties)
        {
            if (materialEditorIn == null)
                throw new ArgumentNullException(nameof(materialEditorIn));
            
            _materialEditor = materialEditorIn;
            _shadowShardEditor.IncludeMaterialEditor(_materialEditor);
            var material = _materialEditor != null ? _materialEditor.target as Material : null;
            
            if (material == null)
                return;
            
            if (FirstTimeApply)
            {
                OnOpenGUI(material);
                FirstTimeApply = false;
            }
            
            OnUpdateGUI(material);
            FindProperties(properties);
            RenderSections();
        }
        
        protected virtual void FindProperties(MaterialProperty[] properties)
        {
            if (properties == null)
                return;
            
            foreach (var section in Sections)
                section.FindProperties(properties);
        }
        
        protected virtual void RenderSections()
        {
            foreach (var section in Sections.Where(section => section.IsRendered))
                RenderSection(section);
        }

        protected virtual void RenderSection(ISection section)
        {
            EditorGUIUtility.SetIconSize(IconSize);

            using var header = new HeaderScope(section, _materialEditor);
            if (header.Expanded)
                section.DrawProperties(_shadowShardEditor);
        }
        
        protected virtual void SetKeywords(Material material)
        {
            foreach (var section in Sections)
                section.SetKeywords(material);
        }
    }
}