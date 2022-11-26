using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Double type equality.
    /// </summary>
    public struct EqDouble : Eq<Double>
    {
        /// <summary>
        /// Determines whether two <see cref="Double"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="Double"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Double"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(Double lhs, Double rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableDouble"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Int32"/> object.</returns>
        public int GetHashCode(Double t)
            => default(HashableDouble).GetHashCode(t);
    }
}
