using System;
using Fambda.Contracts;

namespace Fambda
{
    /// <summary>
    /// Represents Exceptional 'T' type.
    /// </summary>
    public struct Exceptional<T>
    {
        internal Exception Exception { get; }
        internal T Value { get; }

        private Exceptional(Exception exception)
        {
            Guard.On(exception, Error.ExceptionalExceptionMustNotBeNull()).AgainstNull();

            Exception = exception;
            Value = default(T);
        }

        private Exceptional(T value)
        {
            Exception = null;
            Value = value;
        }

        /// <summary>
        /// Implicit conversion operator from <see cref="Exception"/> to <see cref="Exceptional{T}"/>.
        /// </summary>
        /// <param name="exception"><see cref="Exception"/> object.</param>
        public static implicit operator Exceptional<T>(Exception exception)
            => new Exceptional<T>(exception);

        /// <summary>
        /// Implicit conversion operator from T to <see cref="Exceptional{T}"/>.
        /// </summary>
        /// <param name="value">T value.</param>
        public static implicit operator Exceptional<T>(T value)
            => new Exceptional<T>(value);
    }
}
