using System;
using UnityEngine;

namespace ShadowShard.Editor.Range
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

        private static Vector2 MinValue => new(float.MinValue, float.MinValue);
        private static Vector2 MaxValue => new(float.MaxValue, float.MaxValue);

        public static Vector2Range Normalized => new(Vector2.zero, Vector2.one);
        public static Vector2Range Full => new(MinValue, MaxValue);
        
        public static Vector2Range ToMaxFrom(Vector2 min) => new(min, MaxValue);
    }
}