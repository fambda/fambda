using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Int type equality.
    /// </summary>
    public struct EqInt64 : Eq<Int64>
    {
        /// <summary>
        /// Determines whether two <see cref="Int64"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="Int64"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Int64"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(Int64 lhs, Int64 rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableInt64"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Int64"/> object.</returns>
        public int GetHashCode(Int64 t)
            => default(HashableInt64).GetHashCode(t);
    }
}
