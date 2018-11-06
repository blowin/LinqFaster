using LinqMeta.CollectionWrapper;
using LinqMeta.Core;

namespace LinqMeta.Extensions.Operators
{
    public static class FirstLastOperators
    {
        public static Option<T> FirstMeta<TCollect, T>(this TCollect collect)
            where TCollect : struct, ICollectionWrapper<T>
        {
            if (collect.HasIndexOverhead)
            {
                return collect.HasNext ? new Option<T>(collect.Value) : Option<T>.None;
            }
            else
            {
                return collect.Size > 0 ? new Option<T>(collect[0]) : Option<T>.None;
            }
        }
        
        public static Option<T> LastMeta<TCollect, T>(this TCollect collect)
            where TCollect : struct, ICollectionWrapper<T>
        {
            if (collect.HasIndexOverhead)
            {
                if (collect.HasNext)
                {
                    while (collect.HasNext)
                    {
                    }

                    return new Option<T>(collect.Value);
                }
                else
                {
                    return Option<T>.None;
                }
            }
            else
            {
                var size = collect.Size;
                return size > 0 ? new Option<T>(collect[(uint)(size - 1)]) : Option<T>.None;
            }
        }
        
        public static Option<T> NthMeta<TCollect, T>(this TCollect collect, uint index)
            where TCollect : struct, ICollectionWrapper<T>
        {
            if (collect.HasIndexOverhead)
            {
                var curIndex = 0u;
                if (collect.HasNext)
                {
                    while (curIndex != index && collect.HasNext)
                    {
                    }

                    return curIndex == index ? new Option<T>(collect.Value) : Option<T>.None;
                }
                else
                {
                    return Option<T>.None;
                }
            }
            else
            {
                var size = collect.Size;
                return size > index ? new Option<T>(collect[index]) : Option<T>.None;
            }
        }
    }
}