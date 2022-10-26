using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Decimal type equality.
    /// </summary>
    public struct EqDecimal : Eq<Decimal>
    {
        /// <summary>
        /// Determines whether two <see cref="Decimal"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="Decimal"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Decimal"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(Decimal lhs, Decimal rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableDecimal"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Int32"/> object.</returns>
        public int GetHashCode(Decimal t)
            => default(HashableDecimal).GetHashCode(t);
    }
}
