using System;

namespace Fambda
{
    /// <summary>
    /// Decimal type hash-code.
    /// </summary>
    public struct HashableDecimal : Hashable<Decimal>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="Decimal"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int32"/> value.</returns>
        public int GetHashCode(Decimal t)
            => t.GetHashCode();
    }
}
