using UnityEngine;

namespace ShadowShard.Editor
{
    public static class RPUtils
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