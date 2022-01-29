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
        /// <typeparam name="T">Bound value type</typeparam>
        /// <param name="value">T value</param>
        /// <param name="guardException"><see cref="GuardException"/></param>
        /// <returns><see cref="Guard{T}"/>.</returns>
        public static Guard<T> On<T>(T value, GuardException guardException)
        {
            return new Guard<T>(value, guardException);
        }

        /// <summary>
        /// Guard on <see cref="T:object[]"/>.
        /// </summary>
        /// <param name="values">object values</param>
        /// <param name="guardException"><see cref="GuardException"/></param>
        /// <returns><see cref="Guard{object[]}"/>.</returns>
        public static Guard<object[]> On(object[] values, GuardException guardException)
        {
            return new Guard<object[]>(values, guardException);
        }
    }
}
