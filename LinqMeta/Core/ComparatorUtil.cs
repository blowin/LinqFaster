using System.Collections.Generic;

namespace LinqMeta.Core
{
    public static class ComparatorUtil<T>
    {
        public static readonly Comparer<T> Default = Comparer<T>.Default;
    }
}