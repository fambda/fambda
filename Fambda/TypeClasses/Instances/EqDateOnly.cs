using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// DateOnly type equality.
    /// </summary>
    public struct EqDateOnly : Eq<DateOnly>
    {
        /// <summary>
        /// Determines whether two <see cref="DateOnly"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="DateOnly"/> left hand side object.</param>
        /// <param name="rhs"><see cref="DateOnly"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(DateOnly lhs, DateOnly rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableDateOnly"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Int32"/> object.</returns>
        public int GetHashCode(DateOnly t)
            => default(HashableDateOnly).GetHashCode(t);
    }
}
