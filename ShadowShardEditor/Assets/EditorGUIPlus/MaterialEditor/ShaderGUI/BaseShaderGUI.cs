﻿using System;
using System.Collections.Generic;
using System.Linq;
using EditorGUIPlus.Section;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.MaterialEditor.ShaderGUI
{
    public class BaseShaderGUI : UnityEditor.ShaderGUI
    {
        private readonly MaterialEditorGUIPlus _materialEditorGUIPlus = new();
        private UnityEditor.MaterialEditor _materialEditor;
        
        protected bool FirstTimeApply = true;
        protected static Vector2 IconSize = new(5, 5);

        protected List<MaterialSection> Sections = new();

        public virtual void MaterialChanged(Material material) => 
            ValidateMaterial(material);
        
        public override void ValidateMaterial(Material material) => 
            SetKeywords(material);
        
        public virtual void OnOpenGUI(Material material) => 
            Sections = new List<MaterialSection>(SetSections(material));

        public virtual void OnUpdateGUI(Material material) { }
        
        public virtual IEnumerable<MaterialSection> SetSections(Material material) => 
            Sections = new List<MaterialSection>();

        public override void OnGUI(UnityEditor.MaterialEditor materialEditorIn, MaterialProperty[] properties)
        {
            if (materialEditorIn == null)
                throw new ArgumentNullException(nameof(materialEditorIn));
            
            _materialEditor = materialEditorIn;
            _materialEditorGUIPlus.InitializeMaterialEditor(_materialEditor);
            Material material = _materialEditor != null ? _materialEditor.target as Material : null;
            
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
            
            foreach (MaterialSection section in Sections)
                section.FindProperties(properties);
        }
        
        protected virtual void RenderSections()
        {
            foreach (MaterialSection section in Sections.Where(section => section.IsRendered))
                RenderSection(section);
        }

        protected virtual void RenderSection(MaterialSection section)
        {
            EditorGUIUtility.SetIconSize(IconSize);

            using HeaderScope header = new(section, _materialEditor);
            if (header.Expanded)
                section.DrawProperties(_materialEditorGUIPlus);
        }
        
        protected virtual void SetKeywords(Material material)
        {
            foreach (MaterialSection section in Sections)
                section.SetKeywords(material);
        }
    }
}