namespace Fambda.Contracts
{
    /// <summary>
    /// Represents contract guard.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Guard on 'T'.
        /// </summary>
        /// <typeparam name="T">Bound value type</typeparam>
        /// <param name="value">T value</param>
        /// <param name="guardException"><see cref="GuardException"/></param>
        /// <returns></returns>
        public static Guard<T> On<T>(T value, GuardException guardException)
        {
            return new Guard<T>(value, guardException);
        }
    }
}
