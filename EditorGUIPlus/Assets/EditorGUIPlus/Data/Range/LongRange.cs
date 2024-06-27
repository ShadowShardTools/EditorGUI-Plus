using System;

namespace EditorGUIPlus.Data.Range
{
    [Serializable]
    public readonly struct LongRange
    {
        public readonly long Min;
        public readonly long Max;

        public LongRange(long min, long max)
        {
            Min = min;
            Max = max;
        }

        public static LongRange Normalized => new(0, 1);
        public static LongRange Full => new(long.MinValue, long.MaxValue);
        
        public static LongRange ToMaxFrom(long min) => new(min, long.MaxValue);
    }
}