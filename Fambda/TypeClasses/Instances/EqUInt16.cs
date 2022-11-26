using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// UInt16 type equality.
    /// </summary>
    public struct EqUInt16 : Eq<UInt16>
    {
        /// <summary>
        /// Determines whether two <see cref="Int16"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="UInt16"/> left hand side object.</param>
        /// <param name="rhs"><see cref="UInt16"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(UInt16 lhs, UInt16 rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableUInt16"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="UInt16"/> object.</returns>
        public int GetHashCode(UInt16 t)
            => default(HashableUInt16).GetHashCode(t);
    }
}
