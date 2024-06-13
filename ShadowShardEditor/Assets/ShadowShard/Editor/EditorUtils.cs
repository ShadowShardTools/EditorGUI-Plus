using System;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class EditorUtils
    {
        public void DrawVertical(GUIStyle styles, Action drawCall)
        {
            EditorGUILayout.BeginVertical(styles);
            drawCall.Invoke();
            EditorGUILayout.EndVertical();
        }

        public void DrawIndentedGroup(int level, bool isDisabled, Action drawCall) => 
            DrawDisabledGroup(isDisabled, () => DrawIndented(level, drawCall));
        
        public void DrawIndented(int level, Action drawCall)
        {
            EditorGUI.indentLevel += level;
            drawCall.Invoke();
            EditorGUI.indentLevel -= level;
        }
        
        public void DrawGroup(GUIContent styles, Action drawCall) =>
            DrawGroup(styles, false, drawCall);
        
        public void DrawGroup(GUIContent styles, bool isDisabled, Action drawCall)
        {
            DrawVertical(EditorStyles.helpBox, () =>
            {
                EditorGUILayout.LabelField(styles, EditorStyles.boldLabel);
                DrawDisabledGroup(isDisabled, drawCall);
            });
        }
        
        public void DrawDisabledGroup(bool isDisabled, Action drawCall)
        {
            EditorGUI.BeginDisabledGroup(isDisabled);
            drawCall.Invoke();
            EditorGUI.EndDisabledGroup();
        }
        
        public T GetPropertyValue<T>(object property)
        {
            return property switch
            {
                MaterialProperty matProperty => (T)GetMaterialPropertyValue(matProperty),
                SerializedProperty serializedProperty => (T)GetSerializedPropertyValue(serializedProperty),
                _ => default
            };
        }
        
        public object GetMaterialPropertyValue(MaterialProperty property)
        {
            return property.type switch
            {
                MaterialProperty.PropType.Int => property.intValue,
                MaterialProperty.PropType.Float => property.floatValue,
                MaterialProperty.PropType.Range => property.floatValue,
                MaterialProperty.PropType.Color => property.colorValue,
                MaterialProperty.PropType.Vector => property.vectorValue,
                MaterialProperty.PropType.Texture => property.textureValue,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public object GetSerializedPropertyValue(SerializedProperty property)
        {
            return property.propertyType switch
            {
                SerializedPropertyType.Boolean => property.boolValue,
                SerializedPropertyType.Integer => property.intValue,
                SerializedPropertyType.Float => property.floatValue,
                SerializedPropertyType.Enum => property.enumValueIndex,
                SerializedPropertyType.Vector2 => (Vector4)property.vector2Value,
                SerializedPropertyType.Vector3 => (Vector4)property.vector3Value,
                SerializedPropertyType.Vector4 => property.vector4Value,
                SerializedPropertyType.Color => property.colorValue,
                SerializedPropertyType.ObjectReference when property.objectReferenceValue is Texture => property.objectReferenceValue,
                SerializedPropertyType.ObjectReference when property.objectReferenceValue is Texture2D => property.objectReferenceValue,
                _ => null
            };
        }
        
        public void SetPropertyValue<T>(object property, T value)
        {
            switch (property)
            {
                case MaterialProperty matProperty:
                    SetMaterialPropertyValue(matProperty, value);
                    break;
                case SerializedProperty serializedProperty:
                    SetSerializedPropertyValue(serializedProperty, value);
                    break;
            }
        }
        
        public int GetIntPropertyValue(object property)
        {
            return property switch
            {
                MaterialProperty matProperty => (int)matProperty.floatValue,
                SerializedProperty serializedProperty => serializedProperty.intValue,
                _ => default
            };
        }
        
        public void SetIntPropertyValue(object property, int value)
        {
            switch (property)
            {
                case MaterialProperty matProperty:
                    matProperty.floatValue = value;
                    break;
                case SerializedProperty serializedProperty:
                    serializedProperty.intValue = value;
                    break;
            }
        }
        
        public Vector4 GetVectorPropertyValue(object property)
        {
            return property switch
            {
                MaterialProperty matProperty => matProperty.vectorValue,
                SerializedProperty serializedProperty => serializedProperty.propertyType switch
                {
                    SerializedPropertyType.Vector2 => serializedProperty.vector2Value,
                    SerializedPropertyType.Vector3 => serializedProperty.vector3Value,
                    SerializedPropertyType.Vector4 => serializedProperty.vector4Value,
                    _ => default
                },
                _ => default
            };
        }
        
        public int GetEnumPropertyValue(object property)
        {
            return property switch
            {
                MaterialProperty matProperty => (int)matProperty.floatValue,
                SerializedProperty serializedProperty => serializedProperty.enumValueIndex,
                _ => default
            };
        }
        
        public void SetEnumPropertyValue(object property, int value)
        {
            switch (property)
            {
                case MaterialProperty matProperty:
                    matProperty.floatValue = value;
                    break;
                case SerializedProperty serializedProperty:
                    serializedProperty.enumValueIndex = value;
                    break;
            }
        }
        
        public void SetMaterialPropertyValue(MaterialProperty property, object value)
        {
            switch (value)
            {
                case int i when property.type == MaterialProperty.PropType.Int:
                    property.intValue = i;
                    break;
                case float f when property.type == MaterialProperty.PropType.Float:
                    property.floatValue = f;
                    break;
                case float rangeValue when property.type == MaterialProperty.PropType.Range:
                    property.floatValue = rangeValue;
                    break;
                case Color color when property.type == MaterialProperty.PropType.Color:
                    property.colorValue = color;
                    break;
                case Vector2 vector2 when property.type == MaterialProperty.PropType.Vector:
                    property.vectorValue = vector2;
                    break;
                case Vector3 vector3 when property.type == MaterialProperty.PropType.Vector:
                    property.vectorValue = vector3;
                    break;
                case Vector4 vector4 when property.type == MaterialProperty.PropType.Vector:
                    property.vectorValue = vector4;
                    break;
                case Texture2D texture2D when property.type == MaterialProperty.PropType.Texture:
                    property.textureValue = texture2D;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SetSerializedPropertyValue(SerializedProperty property, object value)
        {
            switch (value)
            {
                case bool b when property.propertyType == SerializedPropertyType.Boolean:
                    property.boolValue = b;
                    break;
                case int i when property.propertyType == SerializedPropertyType.Integer:
                    property.intValue = i;
                    break;
                case float f when property.propertyType == SerializedPropertyType.Float:
                    property.floatValue = f;
                    break;
                case int enumIndex when property.propertyType == SerializedPropertyType.Enum:
                    property.enumValueIndex = enumIndex;
                    break;
                case Color color when property.propertyType == SerializedPropertyType.Color:
                    property.colorValue = color;
                    break;
                case Vector2 vector2 when property.propertyType == SerializedPropertyType.Vector2:
                    property.vector2Value = vector2;
                    break;
                case Vector3 vector3 when property.propertyType == SerializedPropertyType.Vector3:
                    property.vector3Value = vector3;
                    break;
                case Vector4 vector4 when property.propertyType == SerializedPropertyType.Vector4:
                    property.vector4Value = vector4;
                    break;
                case Texture2D texture2D when property.propertyType == SerializedPropertyType.ObjectReference:
                    property.objectReferenceValue = texture2D;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public bool HasMixedValue<T>(T property) where T : class
        {
            return property switch
            {
                MaterialProperty matProperty => matProperty.hasMixedValue,
                SerializedProperty _ => false,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        public bool IsMobilePlatform() => 
            UnityEditorInternal.InternalEditorUtility.IsMobilePlatform(EditorUserBuildSettings.activeBuildTarget);
        
        public Rect GetRect(MaterialProperty prop) => 
            EditorGUILayout.GetControlRect(true, MaterialEditor.GetDefaultPropertyHeight(prop), EditorStyles.layerMaskField);
    }
}