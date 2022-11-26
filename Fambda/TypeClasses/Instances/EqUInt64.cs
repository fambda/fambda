using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// UInt64 type equality.
    /// </summary>
    public struct EqUInt64 : Eq<UInt64>
    {
        /// <summary>
        /// Determines whether two <see cref="UInt64"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="UInt64"/> left hand side object.</param>
        /// <param name="rhs"><see cref="UInt64"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(UInt64 lhs, UInt64 rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableUInt64"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="UInt64"/> object.</returns>
        public int GetHashCode(UInt64 t)
            => default(HashableUInt64).GetHashCode(t);
    }
}
