namespace Fambda
{
    /// <summary>
    /// Byte type hash-code.
    /// </summary>
    public struct HashableByte : Hashable<Byte>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="Byte"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int32"/> value.</returns>
        public int GetHashCode(Byte t)
            => t.GetHashCode();
    }
}
