using System;
using UnityEditor;
using UnityEngine;

namespace ShadowShard.Editor
{
    public class PropertyService
    {
        internal float GetFloat(object property)
        {
            return property switch
            {
                MaterialProperty matProperty => matProperty.floatValue,
                SerializedProperty serializedProperty => serializedProperty.floatValue,
                _ => default
            };
        }
        
        internal void SetFloat(object property, float newValue)
        {
            switch (property)
            {
                case MaterialProperty matProperty:
                    matProperty.floatValue = newValue;
                    break;
                case SerializedProperty serializedProperty:
                    serializedProperty.floatValue = newValue;
                    break;
            }
        }
        
        internal int GetInt(object property)
        {
            return property switch
            {
                MaterialProperty matProperty => (int)matProperty.floatValue,
                SerializedProperty serializedProperty => serializedProperty.intValue,
                _ => default
            };
        }
        
        internal void SetInt(object property, int newValue)
        {
            switch (property)
            {
                case MaterialProperty matProperty:
                    matProperty.floatValue = newValue;
                    break;
                case SerializedProperty serializedProperty:
                    serializedProperty.intValue = newValue;
                    break;
            }
        }
        
        internal bool GetBool(object property)
        {
            return property switch
            {
                MaterialProperty matProperty => matProperty.floatValue > 0.5f,
                SerializedProperty serializedProperty => serializedProperty.boolValue,
                _ => default
            };
        }
        
        internal void SetBool(object property, bool newValue)
        {
            switch (property)
            {
                case MaterialProperty matProperty:
                    matProperty.floatValue = newValue ? 1.0f : 0.0f;
                    break;
                case SerializedProperty serializedProperty:
                    serializedProperty.boolValue = newValue;
                    break;
            }
        }
        
        internal Vector2 GetVector2(object property)
        {
            return property switch
            {
                MaterialProperty matProperty => matProperty.vectorValue,
                SerializedProperty serializedProperty => serializedProperty.vector3Value,
                _ => default
            };
        }
        
        internal void SetVector2(object property, Vector2 newValue)
        {
            switch (property)
            {
                case MaterialProperty matProperty:
                    matProperty.vectorValue = new Vector4(newValue.x, newValue.y, matProperty.vectorValue.z, matProperty.vectorValue.w);
                    break;
                case SerializedProperty serializedProperty:
                    serializedProperty.vector3Value = newValue;
                    break;
            }
        }
        
        internal Vector3 GetVector3(object property)
        {
            return property switch
            {
                MaterialProperty matProperty => matProperty.vectorValue,
                SerializedProperty serializedProperty => serializedProperty.vector3Value,
                _ => default
            };
        }
        
        internal void SetVector3(object property, Vector3 newValue)
        {
            switch (property)
            {
                case MaterialProperty matProperty:
                    matProperty.vectorValue = new Vector4(newValue.x, newValue.y, newValue.z, matProperty.vectorValue.w);
                    break;
                case SerializedProperty serializedProperty:
                    serializedProperty.vector3Value = newValue;
                    break;
            }
        }
        
        internal Vector4 GetVector4(object property)
        {
            return property switch
            {
                MaterialProperty matProperty => matProperty.vectorValue,
                SerializedProperty serializedProperty => serializedProperty.vector4Value,
                _ => default
            };
        }
        
        internal void SetVector4(object property, Vector4 newValue)
        {
            switch (property)
            {
                case MaterialProperty matProperty:
                    matProperty.vectorValue = newValue;
                    break;
                case SerializedProperty serializedProperty:
                    serializedProperty.vector4Value = newValue;
                    break;
            }
        }
        
        internal Vector4 GetColor(object property)
        {
            return property switch
            {
                MaterialProperty matProperty => matProperty.colorValue,
                SerializedProperty serializedProperty => serializedProperty.colorValue,
                _ => default
            };
        }
        
        internal void SetColor(object property, Vector4 newValue)
        {
            switch (property)
            {
                case MaterialProperty matProperty:
                    matProperty.colorValue = newValue;
                    break;
                case SerializedProperty serializedProperty:
                    serializedProperty.colorValue = newValue;
                    break;
            }
        }
        
        internal bool HasMixedValue<TProperty>(TProperty property)
        {
            return property switch
            {
                MaterialProperty materialProperty => materialProperty.hasMixedValue,
                SerializedProperty serializedProperty => serializedProperty.hasMultipleDifferentValues,
                _ => throw new ArgumentOutOfRangeException(nameof(property), $"Unsupported property type: {property.GetType().Name}")
            };
        }
    }
}