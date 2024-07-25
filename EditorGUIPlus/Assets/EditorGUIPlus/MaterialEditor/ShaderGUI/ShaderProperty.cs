using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.MaterialEditor.ShaderGUI
{
    public struct ShaderProperty
    {
        private readonly string _name;
        public int ID { get; }
        public MaterialProperty MaterialProperty { get; set; }

        public ShaderProperty(string name)
        {
            _name = name;
            ID = Shader.PropertyToID(name);
            MaterialProperty = null;
        }

        public void Find(MaterialProperty[] properties) => 
            MaterialProperty = ShaderPropertyFinder.FindOptionalProperty(_name, properties);
    }
}