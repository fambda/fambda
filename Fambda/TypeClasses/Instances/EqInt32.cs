using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Int32 type equality.
    /// </summary>
    public struct EqInt32 : Eq<Int32>
    {
        /// <summary>
        /// Determines whether two <see cref="Int32"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="Int32"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Int32"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(Int32 lhs, Int32 rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableInt32"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Int32"/> object.</returns>
        public int GetHashCode(Int32 t)
            => default(HashableInt32).GetHashCode(t);
    }
}
