using System;
using UnityEngine;

namespace EditorGUIPlus.Data.Range
{
    [Serializable]
    public readonly struct Vector2IntRange
    {
        public readonly Vector2Int Min;
        public readonly Vector2Int Max;

        public Vector2IntRange(Vector2Int min, Vector2Int max)
        {
            Min = min;
            Max = max;
        }

        private static Vector2Int MinValue => new Vector2Int(int.MinValue, int.MinValue);
        private static Vector2Int MaxValue => new Vector2Int(int.MaxValue, int.MaxValue);

        public static Vector2IntRange Normalized => new Vector2IntRange(Vector2Int.zero, Vector2Int.one);
        public static Vector2IntRange Full => new Vector2IntRange(MinValue, MaxValue);
        
        public static Vector2IntRange ToMaxFrom(Vector2Int min) => new Vector2IntRange(min, MaxValue);
    }
}