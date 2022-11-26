using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Char type equality.
    /// </summary>
    public struct EqChar : Eq<Char>
    {
        /// <summary>
        /// Determines whether two <see cref="Char"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="Char"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Char"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(Char lhs, Char rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableChar"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Int32"/> object.</returns>
        public int GetHashCode(Char t)
            => default(HashableChar).GetHashCode(t);
    }
}
