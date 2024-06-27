﻿using System.Collections.Generic;
using EditorGUIPlus.MaterialEditor.ShaderGUI;
using UnityEngine;

namespace ManualTesting.MaterialEditor
{
    public class TestMaterialGUI : BaseShaderGUI
    {
        public override void OnOpenGUI(Material material)
        {
            Sections = new List<MaterialSection>(SetSections(material));
        }
        public override IEnumerable<MaterialSection> SetSections(Material material)
        {
            return new List<MaterialSection>
            {
                new SlidersTestSection(),
                new IntSlidersTestSection(),
                new ToggleTestSection(),
                new VectorTestSection(),
                new VectorIntTestSection(),
                new TextureTestSection(),
                new PopupTestSection(),
                new ObjectTestSection(material)
            };
        }
    }
}