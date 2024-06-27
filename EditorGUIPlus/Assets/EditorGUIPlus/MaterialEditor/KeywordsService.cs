using UnityEngine;

namespace EditorGUIPlus.MaterialEditor
{
    public static class KeywordsService
    {
        public static void SetGlobalKeyword(string keyword, bool state)
        {
            if (state)
                Shader.EnableKeyword(keyword);
            else
                Shader.DisableKeyword(keyword);
        }
        
        public static void SetKeyword(Material material, string keyword, bool state)
        {
            if (state)
                material.EnableKeyword(keyword);
            else
                material.DisableKeyword(keyword);
        }
    }
}