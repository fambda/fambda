using System;
using System.Diagnostics.Contracts;
using Fambda.Contracts;

namespace Fambda
{
    /// <summary>
    /// Represents an option type. 
    /// </summary>
    /// <typeparam name="T">Value</typeparam>
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

        /// <summary>
        /// Implicit conversion operator from <see cref="OptionSome{T}"/> to <see cref="Option{T}"/>.
        /// </summary>
        /// <param name="some"><see cref="OptionSome{T}"/> object.</param>
        public static implicit operator Option<T>(OptionSome<T> some)
            => new Option<T>(some.Value);

        /// <summary>
        /// Implicit conversion operator from <see cref="OptionNone"/> to <see cref="Option{T}"/>.
        /// </summary>
        /// <param name="_"><see cref="OptionNone"/> object.</param>
        public static implicit operator Option<T>(OptionNone _)
            => new Option<T>();

        /// <summary>
        /// Implicit conversion operator from T to <see cref="Option{T}"/>.
        /// </summary>
        /// <param name="value">T value.</param>
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

        /// <summary>
        /// Match the Some and None states of the <see cref="Option{T}"/> and return Res.
        /// </summary>
        /// <typeparam name="Res">Return type.</typeparam>
        /// <param name="Some">Some match operation.</param>
        /// <param name="None">None match operation.</param>
        [Pure]
        public Res Match<Res>(Func<T, Res> Some, Func<Res> None)
        {
            var result = _isSome ? Some(_value) : None();

            Guard.On(result, Error.OptionMatchReturnMustNotBeNull()).AgainstNull();
            return result;
        }

        /// <summary>
        /// Calculates the hash-code based on whether <see cref="Option{T}"/> is in Some or None.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Option{T}"/> object.</returns>
        public override int GetHashCode()
            => ToString().GetHashCode();

        /// <summary>
        /// Indicates whether the current <see cref="Option{T}"/> is equal to another <see cref="Option{T}"/>
        /// </summary>
        /// <param name="other">An <see cref="Option{T}"/> to compare with this <see cref="Option{T}"/>.</param>
        /// <returns>true if the current <see cref="Option{T}"/> object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Option<T> other)
            => (_isSome && _isSome == other._isSome && _value.Equals(other._value))
               || (!_isSome && !other._isSome);

        /// <summary>
        /// Indicates whether the current <see cref="Option{T}"/> is equal to <see cref="OptionNone"/>
        /// </summary>
        /// <param name="other">An <see cref="OptionNone"/> to compare with this <see cref="Option{T}"/>.</param>
        /// <returns>true if the current <see cref="Option{T}"/> object is equal to the other <see cref="OptionNone"/> parameter; otherwise, false.</returns>
        public bool Equals(OptionNone other)
            => !_isSome;

        /// <summary>
        /// Determines whether specified object is equal to the current <see cref="Option{T}"/> object.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="Option{T}"/> object.</param>
        /// <returns>true if the specified object is equal to the current <see cref="Option{T}"/> object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            else if (obj is OptionNone) return Equals((OptionNone)obj);
            else if (obj is OptionSome<T> optionSome) return Equals(optionSome);
            return base.Equals(obj);
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="Option{T}"/> object.
        /// </summary>
        /// <returns>A string that represents the current <see cref="Option{T}"/> object.</returns>
        public override string ToString()
            => _isSome ? $"Some({_value})" : "None";
    }
}
