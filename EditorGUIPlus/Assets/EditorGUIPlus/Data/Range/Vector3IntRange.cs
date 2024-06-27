using System;
using UnityEngine;

namespace EditorGUIPlus.Data.Range
{
    [Serializable]
    public readonly struct Vector3IntRange
    {
        public readonly Vector3Int Min;
        public readonly Vector3Int Max;

        public Vector3IntRange(Vector3Int min, Vector3Int max)
        {
            Min = min;
            Max = max;
        }

        private static Vector3Int MinValue => new(int.MinValue, int.MinValue, int.MinValue);
        private static Vector3Int MaxValue => new(int.MaxValue, int.MaxValue, int.MaxValue);

        public static Vector3IntRange Normalized => new(Vector3Int.zero, Vector3Int.one);
        public static Vector3IntRange Full => new(MinValue, MaxValue);
        
        public static Vector3IntRange ToMaxFrom(Vector3Int min) => new(min, MaxValue);
    }
}