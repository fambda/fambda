using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Guid type equality.
    /// </summary>
    public struct EqGuid : Eq<Guid>
    {
        /// <summary>
        /// Determines whether two <see cref="Guid"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="Guid"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Guid"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(Guid lhs, Guid rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableGuid"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Guid"/> object.</returns>
        public int GetHashCode(Guid t)
            => default(HashableGuid).GetHashCode(t);
    }
}
