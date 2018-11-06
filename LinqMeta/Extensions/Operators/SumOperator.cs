using LinqMeta.CollectionWrapper;
using LinqMeta.Operators.Numbers;

namespace LinqMeta.Extensions.Operators
{
    public static class SumOperator
    {
        public static T SumMeta<TCollect, T>(this TCollect collect)
            where TCollect : struct, ICollectionWrapper<T>
        {
            var sum = default(T);
            if (collect.HasIndexOverhead)
            {
                while (collect.HasNext)
                {
                    checked
                    {
                        sum = default(SumOperator<T>).Invoke(sum, collect.Value);
                    }
                }
            }
            else
            {
                var size = collect.Size;
                for (var i = 0u; i < size; ++i)
                {
                    checked
                    {
                        sum = default(SumOperator<T>).Invoke(sum, collect[i]);
                    }   
                }   
            }

            return sum;
        }
    }
}