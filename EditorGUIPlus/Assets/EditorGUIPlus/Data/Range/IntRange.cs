﻿using System;

namespace EditorGUIPlus.Data.Range
{
    [Serializable]
    public readonly struct IntRange
    {
        public readonly int Min;
        public readonly int Max;

        public IntRange(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public static IntRange Normalized => new IntRange(0, 1);
        public static IntRange Full => new IntRange(int.MinValue, int.MaxValue);
        
        public static IntRange ToMaxFrom(int min) => new IntRange(min, int.MaxValue);
    }
}