using System;
using LinqMeta.Functors;

namespace LinqMeta.Operators.IOperator
{
    public interface IMax<T>
    {
        T Max<TComparer>(TComparer firstGreat)
            where TComparer : struct, IFunctor<T, T, bool>;

        T Max(Func<T, T, bool> firstGreat);
        
        // For number collection
        T Max();
    }
}