using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Exception type equality.
    /// </summary>
    public struct EqException : Eq<Exception>
    {
        /// <summary>
        /// Determines whether two <see cref="Guid"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="Exception"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Exception"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public bool Equals(Exception? lhs, Exception? rhs)
            => default(EqString).Equals(lhs?.GetType().FullName, rhs?.GetType().FullName) &&
               default(EqInt32).Equals(lhs is null ? 0 : lhs.HResult, rhs is null ? 0 : rhs.HResult) &&
               default(EqString).Equals(lhs?.Message, rhs?.Message);

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableException"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Exception"/> object.</returns>
        public int GetHashCode(Exception? t)
            => default(HashableException).GetHashCode(t);
    }
}
