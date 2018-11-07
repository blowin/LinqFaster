using LinqMeta.CollectionWrapper;
using LinqMeta.Functors;

namespace LinqMeta.Extensions.Operators
{
    public static class FindOperator
    {
        internal static T FindElementInAllCollection<TCollection, TCond, T>(this TCollection collection, TCond cond)
            where TCollection : struct, ICollectionWrapper<T>
            where TCond : struct, IFunctor<T, T, bool>
        {
            if (collection.HasIndexOverhead)
            {
                if (collection.HasNext)
                {
                    var firstItem = collection.Value;
                    while (collection.HasNext)
                    {
                        var item = collection.Value;
                        if (cond.Invoke(item, firstItem))
                            firstItem = item;
                    }

                    return firstItem;
                }
            }
            else
            {
                var size = collection.Size;
                if (size > 0)
                {
                    var firstItem = collection[0];
                    for (var i = 1u; i < size; ++i)
                    {
                        var curItem = collection[i];
                        if (cond.Invoke(curItem, firstItem))
                            firstItem = curItem;
                    }

                    return firstItem;
                }
            }

            return default(T);
        }
    }
}