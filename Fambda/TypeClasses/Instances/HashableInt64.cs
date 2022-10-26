using System;

namespace Fambda
{
    /// <summary>
    /// Int64 type hash-code.
    /// </summary>
    public struct HashableInt64 : Hashable<Int64>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="Int64"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int64"/> value.</returns>
        public int GetHashCode(Int64 t)
            => t.GetHashCode();
    }
}
