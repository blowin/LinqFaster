using System;
using LinqMeta.Functors;

namespace LinqMeta.Operators.IOperator
{
    public interface IMin<T>
    {
        T Min<TComparer>(TComparer firstGreat)
            where TComparer : struct, IFunctor<T, T, bool>;

        T Min(Func<T, T, bool> firstGreat);
        
        // For number collection
        T Min();
    }
}