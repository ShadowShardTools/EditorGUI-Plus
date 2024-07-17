using System;
using UnityEngine;

namespace EditorGUIPlus.Data.Range
{
    [Serializable]
    public readonly struct Vector3Range
    {
        public readonly Vector3 Min;
        public readonly Vector3 Max;

        public Vector3Range(Vector3 min, Vector3 max)
        {
            Min = min;
            Max = max;
        }

        private static Vector3 MinValue => new Vector3(float.MinValue, float.MinValue, float.MinValue);
        private static Vector3 MaxValue => new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);

        public static Vector3Range Normalized => new Vector3Range(Vector3.zero, Vector3.one);
        public static Vector3Range Full => new Vector3Range(MinValue, MaxValue);
        
        public static Vector3Range ToMaxFrom(Vector3 min) => new Vector3Range(min, MaxValue);
    }
}