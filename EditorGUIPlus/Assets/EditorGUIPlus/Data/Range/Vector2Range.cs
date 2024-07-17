using System;
using UnityEngine;

namespace EditorGUIPlus.Data.Range
{
    [Serializable]
    public readonly struct Vector2Range
    {
        public readonly Vector2 Min;
        public readonly Vector2 Max;

        public Vector2Range(Vector2 min, Vector2 max)
        {
            Min = min;
            Max = max;
        }

        private static Vector2 MinValue => new Vector2(float.MinValue, float.MinValue);
        private static Vector2 MaxValue => new Vector2(float.MaxValue, float.MaxValue);

        public static Vector2Range Normalized => new Vector2Range(Vector2.zero, Vector2.one);
        public static Vector2Range Full => new Vector2Range(MinValue, MaxValue);
        
        public static Vector2Range ToMaxFrom(Vector2 min) => new Vector2Range(min, MaxValue);
    }
}