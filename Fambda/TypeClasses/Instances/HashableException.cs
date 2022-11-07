using System;

namespace Fambda
{
    /// <summary>
    /// Exception type hash-code.
    /// </summary>
    public struct HashableException : Hashable<Exception>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="Exception"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int32"/> value.</returns>
        public int GetHashCode(Exception? t)
            => t is null ? 0 : (t.GetType().FullName, t.HResult, t.Message).GetHashCode();
    }
}
