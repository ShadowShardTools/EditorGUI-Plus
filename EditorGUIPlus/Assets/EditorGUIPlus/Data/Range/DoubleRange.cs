using System;

namespace EditorGUIPlus.Data.Range
{
    [Serializable]
    public readonly struct DoubleRange
    {
        public readonly double Min;
        public readonly double Max;

        public DoubleRange(double min, double max)
        {
            Min = min;
            Max = max;
        }

        public static DoubleRange Normalized => new DoubleRange(0.0f, 1.0f);
        public static DoubleRange Full => new DoubleRange(double.MinValue, double.MaxValue);
        
        public static DoubleRange ToMaxFrom(double min) => new DoubleRange(min, double.MaxValue);
    }
}