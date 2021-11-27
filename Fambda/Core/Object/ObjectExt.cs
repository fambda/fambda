using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Object extensions.
    /// </summary>
    internal static class ObjectExt
    {
        /// <summary>
        /// Indicates whether the specified T value is null.
        /// </summary>
        /// <param name="value">The T value to test.</param>
        /// <returns>true if the specified value is null; otherwise, false.</returns>
        [Pure]
        public static bool IsNull<T>(this T value) =>
            CheckHelper<T>.IsNull(value);
    }
}