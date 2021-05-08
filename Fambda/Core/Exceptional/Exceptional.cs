using System;
using Fambda.Contracts;

namespace Fambda
{
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

        public static implicit operator Exceptional<T>(Exception exception)
            => new Exceptional<T>(exception);

        public static implicit operator Exceptional<T>(T value)
            => new Exceptional<T>(value);
    }
}
