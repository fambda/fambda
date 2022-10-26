using System;

namespace Fambda
{
    /// <summary>
    /// String type hash-code.
    /// </summary>
    public struct HashableString : Hashable<String>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="String"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int32"/> value.</returns>
        public int GetHashCode(String? t)
            => t is null ? 0 : t.GetHashCode();
    }
}
