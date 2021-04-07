using System;
using Fambda.Contracts;

namespace Fambda
{
    public struct Option<T> : IEquatable<Option<T>>, IEquatable<OptionNone>
    {
        private readonly T _value;
        private readonly bool _isSome;

        private Option(T value)
        {
            Guard.On(value, Error.OptionValueMustNotBeNull()).AgainstNull();

            _value = value;
            _isSome = true;
        }

        public static implicit operator Option<T>(OptionSome<T> some)
            => new Option<T>(some.Value);

        public static implicit operator Option<T>(OptionNone _)
            => new Option<T>();

        public static implicit operator Option<T>(T value)
        {
            if (value != null)
            {
                return new OptionSome<T>(value);
            }
            else
            {
                return OptionNone.Default;
            }
        }

        public Res Match<Res>(Func<T, Res> Some, Func<Res> None)
            => _isSome ? Some(_value) : None();

        public bool Equals(Option<T> other)
            => (_isSome && _isSome == other._isSome && _value.Equals(other._value))
               || (!_isSome && !other._isSome);

        public bool Equals(OptionNone other)
            => !_isSome;

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            else if (obj is OptionNone) return Equals((OptionNone)obj);
            else if (obj is OptionSome<T> optionSome) return Equals(optionSome);
            return base.Equals(obj);
        }

        public override string ToString()
            => _isSome ? $"Some({_value})" : "None";

        public override int GetHashCode()
            => ToString().GetHashCode();


    }
}
