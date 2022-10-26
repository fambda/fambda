using System;

namespace Fambda
{
    /// <summary>
    /// Guid type hash-code.
    /// </summary>
    public struct HashableGuid : Hashable<Guid>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="Guid"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int32"/> value.</returns>
        public int GetHashCode(Guid t)
            => t.GetHashCode();
    }
}
