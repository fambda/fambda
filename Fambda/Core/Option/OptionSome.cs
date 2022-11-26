using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Represents an OptionSome type.
    /// </summary>
    /// <typeparam name="T">The type of the value to be wrapped.</typeparam>
    public readonly struct OptionSome<T> : IEquatable<OptionSome<T>>
    {
        internal T Value { get; }

        internal OptionSome([NotNull] T? value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Calculates the hash-code for current <see cref="OptionSome{T}"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="OptionSome{T}"/> object.</returns>
        [Pure]
        public override int GetHashCode()
            => HashCode.Combine(Value);

        /// <summary>
        /// Indicates whether the current <see cref="OptionSome{T}"/> is equal to another <see cref="OptionSome{T}"/>
        /// </summary>
        /// <param name="other">An <see cref="OptionSome{T}"/> to compare with this <see cref="OptionSome{T}"/>.</param>
        /// <returns>true if the current <see cref="OptionSome{T}"/> object is equal to the other parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(OptionSome<T> other)
            => Value!.Equals(other.Value);

        /// <summary>
        /// Determines whether specified object is equal to the current <see cref="OptionSome{T}"/> object.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="OptionSome{T}"/> object.</param>
        /// <returns>true if the specified object is equal to the current <see cref="OptionSome{T}"/> object; otherwise, false.</returns>
        [Pure]
        public override bool Equals(object? obj)
            => obj is OptionSome<T> optionSome && Value!.Equals(optionSome.Value);

        /// <summary>
        /// Returns a string that represents the current <see cref="OptionSome{T}"/> object.
        /// </summary>
        /// <returns>A string that represents the current <see cref="OptionSome{T}"/> object.</returns>
        public override string ToString() => $"Some({Value})";

        /// <summary>
        /// Compares two <see cref="OptionSome{T}"/> objects through equality operator.
        /// </summary>
        /// <param name="lhs"><see cref="OptionSome{T}"/> left hand side object.</param>
        /// <param name="rhs"><see cref="OptionSome{T}"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public static bool operator ==(OptionSome<T> lhs, OptionSome<T> rhs)
            => Equals(lhs, rhs);

        /// <summary>
        /// Compares two <see cref="OptionSome{T}"/> objects through inequality operator.
        /// </summary>
        /// <param name="lhs"><see cref="OptionSome{T}"/> left hand side object.</param>
        /// <param name="rhs"><see cref="OptionSome{T}"/> right hand side object.</param>
        /// <returns>true if the <paramref name="lhs"/> object is not equal to <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public static bool operator !=(OptionSome<T> lhs, OptionSome<T> rhs)
            => !Equals(lhs, rhs);
    }
}
