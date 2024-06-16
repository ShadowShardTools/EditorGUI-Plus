using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.MaterialEditor.ShaderGUI
{
    public struct Property
    {
        private readonly string _name;
        public int ID { get; }
        public MaterialProperty MaterialProperty { get; set; }

        public Property(string name)
        {
            _name = name;
            ID = Shader.PropertyToID(name);
            MaterialProperty = null;
        }

        public void Find(MaterialProperty[] properties) => 
            MaterialProperty = PropertyFinder.FindOptionalProperty(_name, properties);
    }
}