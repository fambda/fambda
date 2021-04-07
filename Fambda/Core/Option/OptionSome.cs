using System;
using System.Diagnostics.Contracts;
using Fambda.Contracts;

namespace Fambda
{
    public struct OptionSome<T> : IEquatable<OptionSome<T>>
    {
        internal T Value { get; }

        internal OptionSome(T value)
        {
            Guard.On(value, Error.OptionSomeValueMustNotBeNull()).AgainstNull();

            Value = value;
        }

        [Pure]
        public override bool Equals(object obj)
            => obj is OptionSome<T> optionSome && Value.Equals(optionSome.Value);

        [Pure]
        public bool Equals(OptionSome<T> other)
            => Value.Equals(other.Value);

        [Pure]
        public override int GetHashCode()
            => Value.GetHashCode();
    }
}
