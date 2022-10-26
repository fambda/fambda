using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Boolean type equality.
    /// </summary>
    public struct EqBoolean : Eq<Boolean>
    {
        /// <summary>
        /// Determines whether two <see cref="Boolean"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="Boolean"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Boolean"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(Boolean lhs, Boolean rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableBoolean"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Int32"/> object.</returns>
        public int GetHashCode(Boolean t)
            => default(HashableBoolean).GetHashCode(t);
    }
}
