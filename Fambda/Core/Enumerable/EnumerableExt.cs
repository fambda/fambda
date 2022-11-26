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
        public static IEnumerable<Res> Map<T, Res>(this IEnumerable<T> self, Func<T, Res> func)
            => self.Select(func);

        /// <summary>
        /// Binds <see cref="IEnumerable{T}"/> into <see cref="IEnumerable{Res}"/>
        /// </summary>
        public static IEnumerable<Res> Bind<T, Res>(this IEnumerable<T> self, Func<T, IEnumerable<Res>> func)
            => self.SelectMany(func);

        /// <summary>
        /// <para>Flattens <see cref="IEnumerable{T}">IEnumerable&lt;IEnumerable&lt;T>></see> into <see cref="IEnumerable{T}">IEnumerable&lt;T></see>.</para>
        /// <para><c>IEnumerable&lt;IEnumerable&lt;T>> → IEnumerable&lt;T></c></para>
        /// </summary>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> self)
            => self.SelectMany(x => x);
    }
}
