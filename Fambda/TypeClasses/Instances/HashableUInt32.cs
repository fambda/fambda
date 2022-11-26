namespace Fambda
{
    /// <summary>
    /// UInt32 type hash-code.
    /// </summary>
    public struct HashableUInt32 : Hashable<UInt32>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="UInt32"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="UInt32"/> value.</returns>
        public int GetHashCode(UInt32 t)
            => t.GetHashCode();
    }
}
