using System;

namespace Fambda
{
    /// <summary>
    /// Double type hash-code.
    /// </summary>
    public struct HashableDouble : Hashable<Double>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="Double"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int32"/> value.</returns>
        public int GetHashCode(Double t)
            => t.GetHashCode();
    }
}
