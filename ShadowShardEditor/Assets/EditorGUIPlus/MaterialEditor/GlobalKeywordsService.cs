using UnityEngine;

namespace EditorGUIPlus.MaterialEditor
{
    public static class GlobalKeywordsService
    {
        public static void SetGlobalKeyword(string keyword, bool state)
        {
            if (state)
                Shader.EnableKeyword(keyword);
            else
                Shader.DisableKeyword(keyword);
        }
    }
}