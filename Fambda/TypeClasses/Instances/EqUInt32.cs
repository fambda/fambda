using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// UInt32 type equality.
    /// </summary>
    public struct EqUInt32 : Eq<UInt32>
    {
        /// <summary>
        /// Determines whether two <see cref="UInt32"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="UInt32"/> left hand side object.</param>
        /// <param name="rhs"><see cref="UInt32"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(UInt32 lhs, UInt32 rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableUInt32"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="UInt32"/> object.</returns>
        public int GetHashCode(UInt32 t)
            => default(HashableUInt32).GetHashCode(t);
    }
}
