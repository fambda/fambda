using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// String type equality.
    /// </summary>
    public struct EqString : Eq<String>
    {
        /// <summary>
        /// Determines whether two <see cref="String"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="String"/> left hand side object.</param>
        /// <param name="rhs"><see cref="String"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(String? lhs, String? rhs)
            => String.Equals(lhs, rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableString"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Int32"/> object.</returns>
        public int GetHashCode(String? t)
            => default(HashableString).GetHashCode(t);
    }
}
