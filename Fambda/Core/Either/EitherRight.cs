using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Represents an EitherRight 'R' type.
    /// </summary>
    /// <typeparam name="R">The type of the right value to be wrapped.</typeparam>
    public readonly struct EitherRight<R> : IEquatable<EitherRight<R>>
    {
        internal R Value { get; }

        internal EitherRight(R value) { Value = value; }

        /// <summary>
        /// Calculates the hash-code for current <see cref="EitherRight{R}"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="EitherRight{R}"/> object.</returns>
        [Pure]
        public override int GetHashCode()
            => HashCode.Combine(Value);

        /// <summary>
        /// Indicates whether the current <see cref="EitherRight{R}"/> is equal to another <see cref="EitherRight{R}"/>
        /// </summary>
        /// <param name="other">An <see cref="EitherRight{R}"/> to compare with this <see cref="EitherRight{R}"/>.</param>
        /// <returns>true if the current <see cref="EitherRight{R}"/> object is equal to the other parameter; otherwise, false.</returns>
        [Pure]
        public bool Equals(EitherRight<R> other)
            => Equals(Value, other.Value);

        /// <summary>
        /// Determines whether specified object is equal to the current <see cref="EitherRight{R}"/> object.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="EitherRight{R}"/> object.</param>
        /// <returns>true if the specified object is equal to the current <see cref="EitherRight{R}"/> object; otherwise, false.</returns>
        [Pure]
        public override bool Equals(object? obj)
            => !object.ReferenceEquals(obj, null) && obj is EitherRight<R> eitherRight && Equals(eitherRight);

        /// <summary>
        /// Returns a string that represents the current <see cref="EitherRight{R}"/> object.
        /// </summary>
        /// <returns>A string that represents the current <see cref="EitherRight{R}"/> object.</returns>
        public override string ToString() => $"Right({Value})";

        /// <summary>
        /// Compares two <see cref="EitherRight{R}"/> objects through equality operator.
        /// </summary>
        /// <param name="lhs"><see cref="EitherRight{R}"/> left hand side object.</param>
        /// <param name="rhs"><see cref="EitherRight{R}"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public static bool operator ==(EitherRight<R> lhs, EitherRight<R> rhs)
            => Equals(lhs, rhs);

        /// <summary>
        /// Compares two <see cref="EitherRight{R}"/> objects through inequality operator.
        /// </summary>
        /// <param name="lhs"><see cref="EitherRight{R}"/> left hand side object.</param>
        /// <param name="rhs"><see cref="EitherRight{R}"/> right hand side object.</param>
        /// <returns>true if the <paramref name="lhs"/> object is not equal to <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public static bool operator !=(EitherRight<R> lhs, EitherRight<R> rhs)
            => !Equals(lhs, rhs);
    }
}
