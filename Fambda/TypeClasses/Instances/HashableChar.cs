using System;

namespace Fambda
{
    /// <summary>
    /// Char type hash-code.
    /// </summary>
    public struct HashableChar : Hashable<Char>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="Char"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int32"/> value.</returns>
        public int GetHashCode(Char t)
            => t.GetHashCode();
    }
}
