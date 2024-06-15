using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace ShadowShard.Editor.MaterialEditor.ShaderGUI
{
    public static class PropertyFinder
    {
        public static MaterialProperty FindOptionalProperty(string propertyName, MaterialProperty[] properties) => 
            FindProperty(propertyName, properties, false);

        public static MaterialProperty FindProperty(string propertyName, MaterialProperty[] properties) => 
            FindProperty(propertyName, properties, true);

        private static MaterialProperty FindProperty(string propertyName, IReadOnlyCollection<MaterialProperty> properties, bool propertyIsMandatory)
        {
            var property = properties.FirstOrDefault(prop => prop != null && prop.name == propertyName);
            if (property == null && propertyIsMandatory)
            {
                throw new ArgumentException($"Could not find MaterialProperty: '{propertyName}', Num properties: {properties.Count}");
            }
            return property;
        }
    }
}