using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Equality type-class, defines equality behavior. 
    /// </summary>
    /// <typeparam name="T">Type for which equality is required.</typeparam>
    public interface Eq<in T> : Hashable<T>
    {
        /// <summary>
        /// Compares two objects for equality.
        /// </summary>
        /// <param name="lhs">The left hand side object.</param>
        /// <param name="rhs">The right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        bool Equals(T lhs, T rhs);
    }
}
