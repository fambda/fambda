namespace Fambda.Contracts
{
    /// <summary>
    /// Represents Guard <typeparamref name="T"/> type.
    /// </summary>
    /// <typeparam name="T">Type for which guard is required.</typeparam>
    public sealed class Guard<T>
    {
        /// <summary>
        /// Value to guard.
        /// </summary>
        public T? Value { get; }

        /// <summary>
        /// Object values to guard.
        /// </summary>
        public object?[]? Values { get; }

        /// <summary>
        /// <see cref="GuardException"/>
        /// </summary>
        public GuardException GuardException { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guard"/>.
        /// </summary>
        /// <param name="value"><typeparamref name="T"/> value</param>
        /// <param name="guardException"><see cref="GuardException"/></param>
        public Guard(T? value, GuardException? guardException)
        {
            if (guardException is null)
            {
                throw Error.GuardExceptionMustNotBeNull();
            }

            Value = value;
            GuardException = guardException;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guard"/>.
        /// </summary>
        /// <param name="values">Object values</param>
        /// <param name="guardException"><see cref="GuardException"/></param>
        public Guard(object?[]? values, GuardException? guardException)
        {
            if (guardException is null)
            {
                throw Error.GuardExceptionMustNotBeNull();
            }

            Values = values;
            GuardException = guardException;
        }
    }
}
