namespace ShadowShard.Editor.Range
{
    public class Range<T>
    {
        public readonly T Min;
        public readonly T Max;

        protected Range(T min, T max)
        {
            Min = min;
            Max = max;
        }
    }
}