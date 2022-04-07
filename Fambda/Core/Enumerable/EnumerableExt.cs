using System;
using System.Collections.Generic;
using System.Linq;

namespace Fambda
{
    /// <summary>
    /// Enumerable functional extensions.
    /// </summary>
    public static class EnumerableExt
    {
        /// <summary>
        /// Maps <see cref="IEnumerable{T}"/> into <see cref="IEnumerable{Res}"/>
        /// </summary>
        public static IEnumerable<Res> Map<T, Res>(this IEnumerable<T> enumerable, Func<T, Res> func)
            => enumerable.Select(func);

        /// <summary>
        /// Binds <see cref="IEnumerable{T}"/> into <see cref="IEnumerable{Res}"/>
        /// </summary>
        public static IEnumerable<Res> Bind<T, Res>(this IEnumerable<T> enumerable, Func<T, IEnumerable<Res>> func)
            => enumerable.SelectMany(func);

        /// <summary>
        /// <para>Flattens <see cref="IEnumerable{T}">IEnumerable&lt;IEnumerable&lt;T>></see> into <see cref="IEnumerable{T}">IEnumerable&lt;T></see>.</para>
        /// <para><c>IEnumerable&lt;IEnumerable&lt;T>> → IEnumerable&lt;T></c></para>
        /// </summary>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> enumerable)
            => enumerable.SelectMany(x => x);
    }
}
