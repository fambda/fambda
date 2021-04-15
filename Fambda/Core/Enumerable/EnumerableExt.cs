using System;
using System.Collections.Generic;
using System.Linq;

namespace Fambda
{
    public static class EnumerableExt
    {
        public static IEnumerable<Res> Map<T, Res>(this IEnumerable<T> enumerable, Func<T, Res> func)
            => enumerable.Select(func);

        public static IEnumerable<Res> Bind<T, Res>(this IEnumerable<T> enumerable, Func<T, IEnumerable<Res>> func)
            => enumerable.SelectMany(func);
    }
}