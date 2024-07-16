using System;
using EditorGUIPlus.Data.Enums;
using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.EditorModules
{
    public sealed class FieldDrawer
    {
        internal void DrawField(EditorGUIPlus editorGUIPlus, GUIContent label, SerializedProperty property, 
            int indentLevel = 0, bool applyModifiedProperties = false, Action onChangedCallback = null)
        {
            SerializedPropertyType type = property.propertyType;
            switch(type)
            {
                case SerializedPropertyType.Integer:
                    editorGUIPlus.DrawInt(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.Boolean:
                    editorGUIPlus.DrawToggle(label, property, ToggleAlign.Right, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.Float:
                    editorGUIPlus.DrawFloat(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.String:
                    editorGUIPlus.DrawTextField(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.Color:
                    editorGUIPlus.DrawColor(label, property, true, false, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.ObjectReference:
                    editorGUIPlus.DrawObjectField(label, property, indentLevel, true, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.LayerMask:
                    editorGUIPlus.DrawLayerField(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.Enum:
                    editorGUIPlus.DrawEnumPopup(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.Vector2:
                    editorGUIPlus.DrawVector2(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.Vector3:
                    editorGUIPlus.DrawVector3(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.Vector4:
                    editorGUIPlus.DrawVector4(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.Rect:
                    editorGUIPlus.DrawRectField(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.AnimationCurve:
                    editorGUIPlus.DrawAnimationCurve(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.Bounds:
                    editorGUIPlus.DrawBoundsField(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.Gradient:
                    editorGUIPlus.DrawGradient(label, property, false, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.Vector2Int:
                    editorGUIPlus.DrawVector2Int(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.Vector3Int:
                    editorGUIPlus.DrawVector3Int(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.RectInt:
                    editorGUIPlus.DrawIntRectField(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
                    break;
                case SerializedPropertyType.BoundsInt:
                    editorGUIPlus.DrawIntBoundsField(label, property, indentLevel, applyModifiedProperties, onChangedCallback);
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

        internal TType DrawField<TType>(EditorGUIPlus editorGUIPlus, GUIContent label, TType value, int indentLevel = 0, 
            Action onChangedCallback = null)
        {
            return value switch
            {
                int number => (TType)(object)editorGUIPlus.DrawInt(label, number, indentLevel, onChangedCallback),
                bool boolean => (TType)(object)editorGUIPlus.DrawToggle(label, boolean, ToggleAlign.Right, indentLevel, onChangedCallback),
                float number => (TType)(object)editorGUIPlus.DrawFloat(label, number, indentLevel, onChangedCallback),
                string text => (TType)(object)editorGUIPlus.DrawTextField(label, text, indentLevel, onChangedCallback),
                Color color => (TType)(object)editorGUIPlus.DrawColor(label, color, true, false, indentLevel, onChangedCallback),
                Vector2 vector2 => (TType)(object)editorGUIPlus.DrawVector2(label, vector2, indentLevel, onChangedCallback),
                Vector3 vector3 => (TType)(object)editorGUIPlus.DrawVector3(label, vector3, indentLevel, onChangedCallback),
                Vector4 vector4 => (TType)(object)editorGUIPlus.DrawVector4(label, vector4, indentLevel, onChangedCallback),
                Rect rect => (TType)(object)editorGUIPlus.DrawRectField(label, rect, indentLevel, onChangedCallback),
                Bounds bounds => (TType)(object)editorGUIPlus.DrawBoundsField(label, bounds, indentLevel, onChangedCallback),
                AnimationCurve curve => (TType)(object)editorGUIPlus.DrawAnimationCurve(label, curve, indentLevel, onChangedCallback),
                Gradient gradient => (TType)(object)editorGUIPlus.DrawGradient(label, gradient, false, indentLevel, onChangedCallback),
                Vector2Int vector2Int => (TType)(object)editorGUIPlus.DrawVector2Int(label, vector2Int, indentLevel, onChangedCallback),
                Vector3Int vector3Int => (TType)(object)editorGUIPlus.DrawVector3Int(label, vector3Int, indentLevel, onChangedCallback),
                RectInt rectInt => (TType)(object)editorGUIPlus.DrawIntRectField(label, rectInt, indentLevel, onChangedCallback),
                BoundsInt boundsInt => (TType)(object)editorGUIPlus.DrawIntBoundsField(label, boundsInt, indentLevel, onChangedCallback),
                _ => throw new ArgumentException($"Unsupported type: {typeof(TType)}"),
            };
        }
    }
}