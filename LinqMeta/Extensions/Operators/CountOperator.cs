using System.Runtime.CompilerServices;
using LinqMetaCore.Intefaces;

namespace LinqMeta.Extensions.Operators
{
    public static class CountOperator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountMeta<TCollect, T>(ref TCollect collect)
            where TCollect : struct, ICollectionWrapper<T>
        {
            if (collect.HasIndexOverhead)
            {
                var count = 0;
                while (collect.HasNext)
                    ++count;

                return count;
            }
            else
            {
                return collect.Size;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CountMeta<TCollect, T, TPredicat>(ref TCollect collect, ref TPredicat predicat)
            where TCollect : struct, ICollectionWrapper<T>
            where TPredicat : struct, IFunctor<T, bool>
        {
            var count = 0;
            if (collect.HasIndexOverhead)
            {
                while (collect.HasNext)
                {
                    if(predicat.Invoke(collect.Value))
                        ++count;
                }
            }
            else
            {
                var size = collect.Size;
                for (var i = 0u; i < size; ++i)
                {
                    if(predicat.Invoke(collect[i]))
                        ++count;
                }
            }

            return count;
        }
    }
}