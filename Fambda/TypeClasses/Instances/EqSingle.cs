using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Single type equality.
    /// </summary>
    public struct EqSingle : Eq<Single>
    {
        /// <summary>
        /// Determines whether two <see cref="Single"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="Single"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Single"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(Single lhs, Single rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableSingle"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Int32"/> object.</returns>
        public int GetHashCode(Single t)
            => default(HashableSingle).GetHashCode(t);
    }
}
