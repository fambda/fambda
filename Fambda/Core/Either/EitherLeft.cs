using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Represents an EitherLeft 'L' type.
    /// </summary>
    /// <typeparam name="L">The type of the left value to be wrapped.</typeparam>
    public struct EitherLeft<L> : IEquatable<EitherLeft<L>>
    {
        internal L Value { get; }

        internal EitherLeft(L value) { Value = value; }

        /// <summary>
        /// Calculates the hash-code for current <see cref="EitherLeft{L}"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="EitherLeft{L}"/> object.</returns>
        [Pure]
        public override int GetHashCode()
            => HashCode.Combine(Value);

        /// <summary>
        /// Indicates whether the current <see cref="EitherLeft{L}"/> is equal to another <see cref="EitherLeft{L}"/>
        /// </summary>
        /// <param name="other">An <see cref="EitherLeft{L}"/> to compare with this <see cref="EitherLeft{L}"/>.</param>
        /// <returns>true if the current <see cref="EitherLeft{L}"/> object is equal to the other parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(EitherLeft<L> other)
            => Equals(Value, other.Value);

        /// <summary>
        /// Determines whether specified object is equal to the current <see cref="EitherLeft{L}"/> object.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="EitherLeft{L}"/> object.</param>
        /// <returns>true if the specified object is equal to the current <see cref="EitherLeft{L}"/> object; otherwise, false.</returns>
        [Pure]
        public override bool Equals(object? obj)
            => obj is EitherLeft<L> eitherLeft && Equals(eitherLeft);

        /// <summary>
        /// Returns a string that represents the current <see cref="EitherLeft{L}"/> object.
        /// </summary>
        /// <returns>A string that represents the current <see cref="EitherLeft{L}"/> object.</returns>
        public override string ToString() => $"Left({Value})";

        /// <summary>
        /// Compares two <see cref="EitherLeft{L}"/> objects through equality operator.
        /// </summary>
        /// <param name="lhs"><see cref="EitherLeft{L}"/> left hand side object.</param>
        /// <param name="rhs"><see cref="EitherLeft{L}"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public static bool operator ==(EitherLeft<L> lhs, EitherLeft<L> rhs)
            => Equals(lhs, rhs);

        /// <summary>
        /// Compares two <see cref="EitherLeft{L}"/> objects through inequality operator.
        /// </summary>
        /// <param name="lhs"><see cref="EitherLeft{L}"/> left hand side object.</param>
        /// <param name="rhs"><see cref="EitherLeft{L}"/> right hand side object.</param>
        /// <returns>true if the <paramref name="lhs"/> object is not equal to <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public static bool operator !=(EitherLeft<L> lhs, EitherLeft<L> rhs)
            => !Equals(lhs, rhs);
    }
}
