using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Hashable type-class, defines hash-code behavior. 
    /// </summary>
    /// <typeparam name="T">The type for which GetHashCode is required.</typeparam>
    public interface Hashable<in T> : Typeclass
    {
        /// <summary>
        /// Returns the hash-code.
        /// </summary>
        /// <returns>A hash code for the <c>t</c> object.</returns>
        [Pure]
        int GetHashCode(T t);
    }
}
