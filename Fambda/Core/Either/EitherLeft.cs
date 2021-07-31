using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Represents an EitherLeft 'L' type.
    /// </summary>
    /// <typeparam name="L">Left</typeparam>
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
            => Value.GetHashCode();

        /// <summary>
        /// Indicates whether the current <see cref="EitherLeft{L}"/> is equal to another <see cref="EitherLeft{L}"/>
        /// </summary>
        /// <param name="other">An <see cref="EitherLeft{L}"/> to compare with this <see cref="EitherLeft{L}"/>.</param>
        /// <returns>true if the current <see cref="EitherLeft{L}"/> object is equal to the other parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(EitherLeft<L> other)
            => Value.Equals(other.Value);

        /// <summary>
        /// Determines whether specified object is equal to the current <see cref="EitherLeft{L}"/> object.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="EitherLeft{L}"/> object.</param>
        /// <returns>true if the specified object is equal to the current <see cref="EitherLeft{L}"/> object; otherwise, false.</returns>
        [Pure]
        public override bool Equals(object obj)
            => obj is EitherLeft<L> eitherLeft && Value.Equals(eitherLeft.Value);

        /// <summary>
        /// Returns a string that represents the current <see cref="EitherLeft{L}"/> object.
        /// </summary>
        /// <returns>A string that represents the current <see cref="EitherLeft{L}"/> object.</returns>
        public override string ToString() => $"Left({Value})";
    }
}
