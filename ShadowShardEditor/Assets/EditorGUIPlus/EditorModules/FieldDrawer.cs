using System;
using EditorGUIPlus.Data.Enums;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules
{
    public sealed class FieldDrawer
    {
        internal void DrawField(EditorGUIPlus editorGUIPlus, GUIContent label, SerializedProperty property)
        {
            SerializedPropertyType type = property.propertyType;
            switch(type)
            {
                case SerializedPropertyType.Integer:
                    editorGUIPlus.DrawInt(label, property);
                    break;
                case SerializedPropertyType.Boolean:
                    editorGUIPlus.DrawToggle(label, property, ToggleAlign.Right);
                    break;
                case SerializedPropertyType.Float:
                    editorGUIPlus.DrawFloat(label, property);
                    break;
                case SerializedPropertyType.String:
                    editorGUIPlus.DrawTextField(label, property);
                    break;
                case SerializedPropertyType.Color:
                    editorGUIPlus.DrawColor(label, property);
                    break;
                case SerializedPropertyType.ObjectReference:
                    editorGUIPlus.DrawObjectField(label, property: property);
                    break;
                case SerializedPropertyType.LayerMask:
                    editorGUIPlus.DrawLayerField(label, property);
                    break;
                case SerializedPropertyType.Enum:
                    editorGUIPlus.DrawEnumPopup(label, property);
                    break;
                case SerializedPropertyType.Vector2:
                    editorGUIPlus.DrawVector2(label, property);
                    break;
                case SerializedPropertyType.Vector3:
                    editorGUIPlus.DrawVector3(label, property);
                    break;
                case SerializedPropertyType.Vector4:
                    editorGUIPlus.DrawVector4(label, property);
                    break;
                case SerializedPropertyType.Rect:
                    editorGUIPlus.DrawRectField(label, property);
                    break;
                case SerializedPropertyType.AnimationCurve:
                    editorGUIPlus.DrawAnimationCurve(label, property);
                    break;
                case SerializedPropertyType.Bounds:
                    editorGUIPlus.DrawBoundsField(label, property);
                    break;
                case SerializedPropertyType.Gradient:
                    editorGUIPlus.DrawGradient(label, property);
                    break;
                case SerializedPropertyType.Vector2Int:
                    editorGUIPlus.DrawVector2Int(label, property);
                    break;
                case SerializedPropertyType.Vector3Int:
                    editorGUIPlus.DrawVector3Int(label, property);
                    break;
                case SerializedPropertyType.RectInt:
                    editorGUIPlus.DrawIntRectField(label, property);
                    break;
                case SerializedPropertyType.BoundsInt:
                    editorGUIPlus.DrawIntBoundsField(label, property);
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

        internal TType DrawField<TType>(EditorGUIPlus editorGUIPlus, GUIContent label, TType value)
        {
            return value switch
            {
                int number => (TType)(object)editorGUIPlus.DrawInt(label, number),
                bool boolean => (TType)(object)editorGUIPlus.DrawToggle(label, boolean, ToggleAlign.Right),
                float number => (TType)(object)editorGUIPlus.DrawFloat(label, number),
                string text => (TType)(object)editorGUIPlus.DrawTextField(label, text),
                Color color => (TType)(object)editorGUIPlus.DrawColor(label, color),
                Vector2 vector2 => (TType)(object)editorGUIPlus.DrawVector2(label, vector2),
                Vector3 vector3 => (TType)(object)editorGUIPlus.DrawVector3(label, vector3),
                Vector4 vector4 => (TType)(object)editorGUIPlus.DrawVector4(label, vector4),
                Rect rect => (TType)(object)editorGUIPlus.DrawRectField(label, rect),
                Bounds bounds => (TType)(object)editorGUIPlus.DrawBoundsField(label, bounds),
                AnimationCurve curve => (TType)(object)editorGUIPlus.DrawAnimationCurve(label, curve),
                Gradient gradient => (TType)(object)editorGUIPlus.DrawGradient(label, gradient),
                Vector2Int vector2Int => (TType)(object)editorGUIPlus.DrawVector2Int(label, vector2Int),
                Vector3Int vector3Int => (TType)(object)editorGUIPlus.DrawVector3Int(label, vector3Int),
                RectInt rectInt => (TType)(object)editorGUIPlus.DrawIntRectField(label, rectInt),
                BoundsInt boundsInt => (TType)(object)editorGUIPlus.DrawIntBoundsField(label, boundsInt),
                _ => throw new ArgumentException($"Unsupported type: {typeof(TType)}"),
            };
        }
    }
}