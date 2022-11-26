namespace Fambda
{
    /// <summary>
    /// UInt16 type hash-code.
    /// </summary>
    public struct HashableUInt16 : Hashable<UInt16>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="UInt16"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="UInt16"/> value.</returns>
        public int GetHashCode(UInt16 t)
            => t.GetHashCode();
    }
}
