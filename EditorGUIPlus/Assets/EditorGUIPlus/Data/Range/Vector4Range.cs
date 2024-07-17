using System;
using UnityEngine;

namespace EditorGUIPlus.Data.Range
{
    [Serializable]
    public readonly struct Vector4Range
    {
        public readonly Vector4 Min;
        public readonly Vector4 Max;

        public Vector4Range(Vector4 min, Vector4 max)
        {
            Min = min;
            Max = max;
        }

        private static Vector4 MinValue => new Vector4(float.MinValue, float.MinValue, float.MinValue, float.MinValue);
        private static Vector4 MaxValue => new Vector4(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);

        public static Vector4Range Normalized => new Vector4Range(Vector4.zero, Vector4.one);
        public static Vector4Range Full => new Vector4Range(MinValue, MaxValue);
        
        public static Vector4Range ToMaxFrom(Vector4 min) => new Vector4Range(min, MaxValue);
    }
}