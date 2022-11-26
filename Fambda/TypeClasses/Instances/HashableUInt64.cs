namespace Fambda
{
    /// <summary>
    /// UInt64 type hash-code.
    /// </summary>
    public struct HashableUInt64 : Hashable<UInt64>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="UInt64"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="UInt64"/> value.</returns>
        public int GetHashCode(UInt64 t)
            => t.GetHashCode();
    }
}
