using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Int16 type equality.
    /// </summary>
    public struct EqInt16 : Eq<Int16>
    {
        /// <summary>
        /// Determines whether two <see cref="Int16"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="Int16"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Int16"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(Int16 lhs, Int16 rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableInt16"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Int16"/> object.</returns>
        public int GetHashCode(Int16 t)
            => default(HashableInt16).GetHashCode(t);
    }
}
