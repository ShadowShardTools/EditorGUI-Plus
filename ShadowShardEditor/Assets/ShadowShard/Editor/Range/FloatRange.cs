using System;

namespace ShadowShard.Editor.Range
{
    [Serializable]
    public class FloatRange : Range<float>
    {
        public FloatRange(float min, float max) : base(min, max) { }
    }
}