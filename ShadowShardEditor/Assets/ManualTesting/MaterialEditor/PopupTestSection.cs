using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using EditorGUIPlus.MaterialEditor;
using EditorGUIPlus.MaterialEditor.ShaderGUI;
using UnityEditor;
using UnityEngine;

namespace ManualTesting.MaterialEditor
{
    public class PopupTestSection : MaterialSection
    {
        protected Property Color = new("_Color");
        protected Property BaseMap = new("_BaseMap");
        protected Property _EnumValue = new("_EnumValue");
        protected Property VectorValue = new("_VectorValue");
        protected Property EnumValue = new("_EnumValue");

        private readonly GUIContent _colorLabel = new("Color Test");
        private readonly GUIContent _floatLabel = new("Float Test");
        private readonly GUIContent _vectorLabel = new("Vector Test");
        
        private readonly IntRange _testIntRange = new(0, 10);
        private readonly Vector2IntRange _testVector2Range = new(Vector2Int.zero, new Vector2Int(10, 10));
        private readonly Vector3IntRange _testVector3Range = new(Vector3Int.zero, new Vector3Int(10, 10, 10));

        public PopupTestSection() : base(new GUIContent("Test Label"))
        {
        }

        public override void FindProperties(MaterialProperty[] properties)
        {
            Color.Find(properties);
            BaseMap.Find(properties);
            EnumValue.Find(properties);
            VectorValue.Find(properties);
            EnumValue.Find(properties);
        }

        public override void DrawProperties(MaterialEditorGUIPlus editor)
        {
            editor.DrawEnumPopup<TestEnum>(EnumValue.MaterialProperty, 1);
            editor.DrawEnumPopup<TestEnum>(_colorLabel, EnumValue.MaterialProperty, 1);
            
            editor.DrawBooleanPopup<TestEnum>(EnumValue.MaterialProperty, 1);
            editor.DrawBooleanPopup<TestEnum>(_colorLabel, EnumValue.MaterialProperty, 1);
        }

        public override void SetKeywords(Material material)
        {
        }
    }

    public enum TestEnum
    {
        Option1,
        Option2
    }
}