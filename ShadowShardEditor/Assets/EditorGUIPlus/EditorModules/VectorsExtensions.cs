using UnityEngine;

namespace EditorGUIPlus.EditorModules
{
    public static class VectorsExtensions
    {
        public static Vector2 Clamp(this Vector2 value, Vector2 min, Vector2 max)
        {
            value.x = Mathf.Clamp(value.x, min.x, max.x);
            value.y = Mathf.Clamp(value.y, min.y, max.y);
            
            return value;
        }

        public static Vector3 Clamp(this Vector3 value, Vector3 min, Vector3 max)
        {
            value.x = Mathf.Clamp(value.x, min.x, max.x);
            value.y = Mathf.Clamp(value.y, min.y, max.y);
            value.z = Mathf.Clamp(value.z, min.z, max.z);
            
            return value;
        }

        public static Vector4 Clamp(this Vector4 value, Vector4 min, Vector4 max)
        {
            value.x = Mathf.Clamp(value.x, min.x, max.x);
            value.y = Mathf.Clamp(value.y, min.y, max.y);
            value.z = Mathf.Clamp(value.z, min.z, max.z);
            value.w = Mathf.Clamp(value.w, min.w, max.w);
            
            return value;
        }
        
        public static Vector2Int ClampInt(this Vector2Int value, Vector2Int min, Vector2Int max)
        {
            value.x = Mathf.Clamp(value.x, min.x, max.x);
            value.y = Mathf.Clamp(value.y, min.y, max.y);
            
            return value;
        }

        public static Vector3Int ClampInt(this Vector3Int value, Vector3Int min, Vector3Int max)
        {
            value.x = Mathf.Clamp(value.x, min.x, max.x);
            value.y = Mathf.Clamp(value.y, min.y, max.y);
            value.z = Mathf.Clamp(value.z, min.z, max.z);
            
            return value;
        }
    }
}