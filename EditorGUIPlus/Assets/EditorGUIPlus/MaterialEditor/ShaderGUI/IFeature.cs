using UnityEditor;
using UnityEngine;

namespace EditorGUIPlus.MaterialEditor.ShaderGUI
{
    public interface IFeature
    {
        public void FindProperties(MaterialProperty[] properties);

        public void Draw(MaterialEditorGUIPlus materialEditorGUIPlus);

        public void SetKeywords(Material material);
    }
}