using System;

namespace CodeBase.Infrastructure.Data
{
    [Serializable]
    public class MinMaxRange
    {
        public int Min;
        public int Max;
    }
    [Serializable]
    public class MinMaxRange<T>
    {
        public T Min;
        public T Max;
    }
}