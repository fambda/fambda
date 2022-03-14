namespace Fambda.Contracts
{
    /// <summary>
    /// Represents contract guard.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Guard on <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type of bound value.</typeparam>
        /// <param name="value">The <typeparamref name="T"/> value.</param>
        /// <param name="guardException"><see cref="GuardException"/>.</param>
        /// <returns><see cref="Guard{T}">Guard&lt;T></see>.</returns>
        public static Guard<T> On<T>(T value, GuardException guardException)
        {
            return new Guard<T>(value, guardException);
        }

        /// <summary>
        /// Guard on <see cref="T:object[]"/>.
        /// </summary>
        /// <param name="values">The object values.</param>
        /// <param name="guardException"><see cref="GuardException"/>.</param>
        /// <returns><see cref="Guard{T}">Guard&lt;object[]></see>.</returns>
        public static Guard<object[]> On(object[] values, GuardException guardException)
        {
            return new Guard<object[]>(values, guardException);
        }
    }
}
