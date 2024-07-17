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

        public static LongRange Normalized => new LongRange(0, 1);
        public static LongRange Full => new LongRange(long.MinValue, long.MaxValue);
        
        public static LongRange ToMaxFrom(long min) => new LongRange(min, long.MaxValue);
    }
}