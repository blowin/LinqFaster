using System.Runtime.CompilerServices;
using LinqMeta.Operators.Number;
using LinqMetaCore.Intefaces;

namespace LinqMeta.Functors.Math
{
    public struct MinusOperator<T> : IFunctor<T, T, T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Invoke(T a, T b)
        {
            return NumberOperators<T>.Minus(a, b);
        }
    }
}