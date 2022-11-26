using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Byte type equality.
    /// </summary>
    public struct EqByte : Eq<Byte>
    {
        /// <summary>
        /// Determines whether two <see cref="Byte"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="Byte"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Byte"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(Byte lhs, Byte rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableByte"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Byte"/> object.</returns>
        public int GetHashCode(Byte t)
            => default(HashableByte).GetHashCode(t);
    }
}
