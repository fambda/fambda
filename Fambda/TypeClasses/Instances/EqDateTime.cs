using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// DateTime type equality.
    /// </summary>
    public struct EqDateTime : Eq<DateTime>
    {
        /// <summary>
        /// Determines whether two <see cref="DateTime"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="DateTime"/> left hand side object.</param>
        /// <param name="rhs"><see cref="DateTime"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(DateTime lhs, DateTime rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableDateTime"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Int32"/> object.</returns>
        public int GetHashCode(DateTime t)
            => default(HashableDateTime).GetHashCode(t);
    }
}
