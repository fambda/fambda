namespace Fambda.Contracts
{
    /// <summary>
    /// Represents Guard 'T' type.
    /// </summary>
    public sealed class Guard<T>
    {
        /// <summary>
        /// Value to guard.
        /// </summary>
        public T Value { get; }
        public object[] Values { get; }

        /// <summary>
        /// <see cref="GuardException"/>
        /// </summary>
        public GuardException GuardException { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guard"/>.
        /// </summary>
        /// <param name="value">T value</param>
        /// <param name="guardException"><see cref="GuardException"/></param>
        public Guard(T value, GuardException guardException)
        {
            if (guardException == null)
            {
                throw Error.GuardExceptionMustNotBeNull();
            }

            Value = value;
            GuardException = guardException;
        }

        public Guard(object[] values, GuardException guardException)
        {
            if (guardException == null)
            {
                throw Error.GuardExceptionMustNotBeNull();
            }

            Values = values;
            GuardException = guardException;
        }
    }
}
