using ShadowShard.Editor.Enums;
using ShadowShard.Editor.Range;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class VectorIntEditor
    {
        private readonly PropertyService _propertyService;
        private readonly GroupEditor _groupEditor;

        internal VectorIntEditor(PropertyService propertyService, GroupEditor groupEditor)
        {
            _propertyService = propertyService;
            _groupEditor = groupEditor;
        }
        
        internal int DrawInt<TProperty>(GUIContent label, TProperty property, IntRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetInt(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                int propertyValue = _propertyService.GetInt(property);
                int newValue = Mathf.Clamp(EditorGUILayout.IntField(label, propertyValue), range.Min, range.Max);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck()) 
                    _propertyService.SetInt(property, newValue);
            }
        }

        internal Vector2Int DrawVector2Int<TProperty>(GUIContent label, TProperty property, Vector2IntRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector2Int(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector2Int propertyValue = _propertyService.GetVector2Int(property);
                Vector2Int newValue = EditorGUILayout.Vector2IntField(label, propertyValue);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                    _propertyService.SetVector2Int(property, newValue);
            }
        }
        
        internal Vector3Int DrawVector3Int<TProperty>(GUIContent label, TProperty property, Vector3IntRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector3Int(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector3Int propertyValue = _propertyService.GetVector3Int(property);
                Vector3Int newValue = EditorGUILayout.Vector3IntField(label, propertyValue);
                EditorGUI.showMixedValue = false;
                
                if (EditorGUI.EndChangeCheck())
                    _propertyService.SetVector3Int(property, newValue);
            }
        }
        
        internal Vector2Int DrawIntFromVector2Int<TProperty>(GUIContent label, TProperty property, Vector2Param vector2Param, IntRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector2Int(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector2Int propertyValue = _propertyService.GetVector2Int(property);
                int val = propertyValue[(int)vector2Param];
                int newValue = Mathf.Clamp(EditorGUILayout.IntField(label, val), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vector2Param] = newValue;
                    _propertyService.SetVector2Int(property, propertyValue);
                }
            }
        }
        
        internal Vector3Int DrawIntFromVector3Int<TProperty>(GUIContent label, TProperty property, Vector3Param vector3Param, IntRange range, int indentLevel = 0)
        {
            _groupEditor.DrawIndented(indentLevel, Draw);
            return _propertyService.GetVector3Int(property);

            void Draw()
            {
                EditorGUI.BeginChangeCheck();
                
                EditorGUI.showMixedValue = _propertyService.HasMixedValue(property);
                Vector3Int propertyValue = _propertyService.GetVector3Int(property);
                int val = propertyValue[(int)vector3Param];
                int newValue = Mathf.Clamp(EditorGUILayout.IntField(label, val), range.Min, range.Max);
                EditorGUI.showMixedValue = false;

                if (EditorGUI.EndChangeCheck())
                {
                    propertyValue[(int)vector3Param] = newValue;
                    _propertyService.SetVector3Int(property, propertyValue);
                }
            }
        }
    }
}