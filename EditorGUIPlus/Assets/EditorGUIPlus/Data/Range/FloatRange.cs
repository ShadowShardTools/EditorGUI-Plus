using System;

namespace EditorGUIPlus.Data.Range
{
    [Serializable]
    public readonly struct FloatRange
    {
        public readonly float Min;
        public readonly float Max;

        public FloatRange(float min, float max)
        {
            Min = min;
            Max = max;
        }

        public static FloatRange Normalized => new FloatRange(0.0f, 1.0f);
        public static FloatRange Full => new FloatRange(float.MinValue, float.MaxValue);
        
        public static FloatRange ToMaxFrom(float min) => new FloatRange(min, float.MaxValue);
    }
}