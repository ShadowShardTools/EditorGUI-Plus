using System;

namespace ShadowShard.Editor.Range
{
    [Serializable]
    public class IntRange : Range<int>
    {
        public IntRange(int min, int max) : base(min, max) { }
    }
}