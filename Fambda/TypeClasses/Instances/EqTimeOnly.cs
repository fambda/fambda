using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// TimeOnly type equality.
    /// </summary>
    public struct EqTimeOnly : Eq<TimeOnly>
    {
        /// <summary>
        /// Determines whether two <see cref="TimeOnly"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="TimeOnly"/> left hand side object.</param>
        /// <param name="rhs"><see cref="TimeOnly"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(TimeOnly lhs, TimeOnly rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableTimeOnly"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Int32"/> object.</returns>
        public int GetHashCode(TimeOnly t)
            => default(HashableTimeOnly).GetHashCode(t);
    }
}
