using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace EditorGUIPlus.MaterialEditor.ShaderGUI
{
    public static class ShaderPropertyFinder
    {
        public static MaterialProperty FindOptionalProperty(string propertyName, MaterialProperty[] properties) => 
            FindProperty(propertyName, properties, false);

        public static MaterialProperty FindProperty(string propertyName, MaterialProperty[] properties) => 
            FindProperty(propertyName, properties, true);

        private static MaterialProperty FindProperty(string propertyName, IReadOnlyCollection<MaterialProperty> properties, bool propertyIsMandatory)
        {
            MaterialProperty property = properties.FirstOrDefault(prop => prop != null && prop.name == propertyName);
            if (property == null && propertyIsMandatory)
                throw new ArgumentException($"Could not find MaterialProperty: '{propertyName}', Num properties: {properties.Count}");
            
            return property;
        }
    }
}