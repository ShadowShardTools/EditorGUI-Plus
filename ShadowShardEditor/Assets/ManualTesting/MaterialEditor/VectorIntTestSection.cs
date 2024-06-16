using EditorGUIPlus.Data.Enums;
using EditorGUIPlus.Data.Range;
using EditorGUIPlus.MaterialEditor;
using EditorGUIPlus.MaterialEditor.ShaderGUI;
using UnityEditor;
using UnityEngine;

namespace ManualTesting.MaterialEditor
{
    public class VectorIntTestSection : MaterialSection
    {
        protected Property Color = new("_Color");
        protected Property BaseMap = new("_BaseMap");
        protected Property IntValue = new("_IntValue");
        protected Property VectorValue = new("_VectorValue");
        protected Property EnumValue = new("_EnumValue");

        private readonly GUIContent _colorLabel = new("Color Test");
        private readonly GUIContent _floatLabel = new("Float Test");
        private readonly GUIContent _vectorLabel = new("Vector Test");
        
        private readonly IntRange _testIntRange = new(0, 10);
        private readonly Vector2IntRange _testVector2Range = new(Vector2Int.zero, new Vector2Int(10, 10));
        private readonly Vector3IntRange _testVector3Range = new(Vector3Int.zero, new Vector3Int(10, 10, 10));

        public VectorIntTestSection() : base(new GUIContent("Test Label"))
        {
        }

        public override void FindProperties(MaterialProperty[] properties)
        {
            Color.Find(properties);
            BaseMap.Find(properties);
            IntValue.Find(properties);
            VectorValue.Find(properties);
            EnumValue.Find(properties);
        }

        public override void DrawProperties(MaterialEditorGUIPlus editor)
        {
            editor.DrawInt(_floatLabel, IntValue.MaterialProperty, _testIntRange, 1);
            editor.DrawVector2Int(_vectorLabel, VectorValue.MaterialProperty, _testVector2Range, 1);
            editor.DrawVector3Int(_vectorLabel, VectorValue.MaterialProperty, _testVector3Range, 1);
            
            editor.DrawInt(_floatLabel, IntValue.MaterialProperty, 1);
            editor.DrawVector2Int(_vectorLabel, VectorValue.MaterialProperty, 1);
            editor.DrawVector3Int(_vectorLabel, VectorValue.MaterialProperty, 1);
            
            editor.DrawIntFromVector2Int(_vectorLabel, VectorValue.MaterialProperty, Vector2Param.X, _testIntRange, 1);
            editor.DrawIntFromVector3Int(_vectorLabel, VectorValue.MaterialProperty, Vector3Param.Z, _testIntRange, 1);
            
            editor.DrawNormalizedInt(_floatLabel, IntValue.MaterialProperty, 1);
            editor.DrawNormalizedVector2Int(_vectorLabel, VectorValue.MaterialProperty, 1);
            editor.DrawNormalizedVector3Int(_vectorLabel, VectorValue.MaterialProperty, 1);
            
            editor.DrawNormalizedIntFromVector2Int(_vectorLabel, VectorValue.MaterialProperty, Vector2Param.X, 1);
            editor.DrawNormalizedIntFromVector3Int(_vectorLabel, VectorValue.MaterialProperty, Vector3Param.Z, 1);
            
            editor.DrawMinInt(_floatLabel, IntValue.MaterialProperty, 0, 1);
            editor.DrawMinVector2Int(_vectorLabel, VectorValue.MaterialProperty, Vector2Int.zero, 1);
            editor.DrawMinVector3Int(_vectorLabel, VectorValue.MaterialProperty, Vector3Int.zero, 1);
            
            editor.DrawMinIntFromVector2Int(_vectorLabel, VectorValue.MaterialProperty, Vector2Param.X, 0, 1);
            editor.DrawMinIntFromVector3Int(_vectorLabel, VectorValue.MaterialProperty, Vector3Param.Z, 0, 1);
        }

        public override void SetKeywords(Material material)
        {
        }
    }
}