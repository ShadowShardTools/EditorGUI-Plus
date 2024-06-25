using System;
using EditorGUIPlus.Data.Enums;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules.AutoDrawer
{
    public sealed class AutoDrawer
    {
        private readonly EditorGUIPlus _editorGUIPlus = new();

        public void DrawField(GUIContent label, SerializedProperty property)
        {
            SerializedPropertyType type = property.propertyType;
            switch(type)
            {
                case SerializedPropertyType.Integer:
                    _editorGUIPlus.DrawInt(label, property);
                    break;
                case SerializedPropertyType.Boolean:
                    _editorGUIPlus.DrawToggle(label, property, ToggleAlign.Right);
                    break;
                case SerializedPropertyType.Float:
                    _editorGUIPlus.DrawFloat(label, property);
                    break;
                case SerializedPropertyType.String:
                    _editorGUIPlus.DrawTextField(label, property);
                    break;
                case SerializedPropertyType.Color:
                    _editorGUIPlus.DrawColor(label, property);
                    break;
                case SerializedPropertyType.ObjectReference:
                    _editorGUIPlus.DrawObjectField(label, property: property);
                    break;
                case SerializedPropertyType.LayerMask:
                    _editorGUIPlus.DrawLayerField(label, property);
                    break;
                case SerializedPropertyType.Enum:
                    _editorGUIPlus.DrawEnumPopup(label, property);
                    break;
                case SerializedPropertyType.Vector2:
                    _editorGUIPlus.DrawVector2(label, property);
                    break;
                case SerializedPropertyType.Vector3:
                    _editorGUIPlus.DrawVector3(label, property);
                    break;
                case SerializedPropertyType.Vector4:
                    _editorGUIPlus.DrawVector4(label, property);
                    break;
                case SerializedPropertyType.Rect:
                    _editorGUIPlus.DrawRectField(label, property);
                    break;
                case SerializedPropertyType.AnimationCurve:
                    _editorGUIPlus.DrawAnimationCurve(label, property);
                    break;
                case SerializedPropertyType.Bounds:
                    _editorGUIPlus.DrawBoundsField(label, property);
                    break;
                case SerializedPropertyType.Gradient:
                    _editorGUIPlus.DrawGradient(label, property);
                    break;
                case SerializedPropertyType.Vector2Int:
                    _editorGUIPlus.DrawVector2Int(label, property);
                    break;
                case SerializedPropertyType.Vector3Int:
                    _editorGUIPlus.DrawVector3Int(label, property);
                    break;
                case SerializedPropertyType.RectInt:
                    _editorGUIPlus.DrawIntRectField(label, property);
                    break;
                case SerializedPropertyType.BoundsInt:
                    _editorGUIPlus.DrawIntBoundsField(label, property);
                    break;
                case SerializedPropertyType.Generic:
                case SerializedPropertyType.ArraySize:
                case SerializedPropertyType.Character:
                case SerializedPropertyType.Quaternion:
                case SerializedPropertyType.ExposedReference:
                case SerializedPropertyType.FixedBufferSize:
                case SerializedPropertyType.ManagedReference:
                case SerializedPropertyType.Hash128:
                default:
                    throw new ArgumentException($"Type {type} is not supported.");
            }
        }

        public TType DrawField<TType>(GUIContent label, TType value)
        {
            return value switch
            {
                int number => (TType)(object)_editorGUIPlus.DrawInt(label, number),
                bool boolean => (TType)(object)_editorGUIPlus.DrawToggle(label, boolean, ToggleAlign.Right),
                float number => (TType)(object)_editorGUIPlus.DrawFloat(label, number),
                string text => (TType)(object)_editorGUIPlus.DrawTextField(label, text),
                Color color => (TType)(object)_editorGUIPlus.DrawColor(label, color),
                Vector2 vector2 => (TType)(object)_editorGUIPlus.DrawVector2(label, vector2),
                Vector3 vector3 => (TType)(object)_editorGUIPlus.DrawVector3(label, vector3),
                Vector4 vector4 => (TType)(object)_editorGUIPlus.DrawVector4(label, vector4),
                Rect rect => (TType)(object)_editorGUIPlus.DrawRectField(label, rect),
                Bounds bounds => (TType)(object)_editorGUIPlus.DrawBoundsField(label, bounds),
                AnimationCurve curve => (TType)(object)_editorGUIPlus.DrawAnimationCurve(label, curve),
                Gradient gradient => (TType)(object)_editorGUIPlus.DrawGradient(label, gradient),
                Vector2Int vector2Int => (TType)(object)_editorGUIPlus.DrawVector2Int(label, vector2Int),
                Vector3Int vector3Int => (TType)(object)_editorGUIPlus.DrawVector3Int(label, vector3Int),
                RectInt rectInt => (TType)(object)_editorGUIPlus.DrawIntRectField(label, rectInt),
                BoundsInt boundsInt => (TType)(object)_editorGUIPlus.DrawIntBoundsField(label, boundsInt),
                _ => throw new ArgumentException($"Unsupported type: {typeof(TType)}"),
            };
        }
    }
}