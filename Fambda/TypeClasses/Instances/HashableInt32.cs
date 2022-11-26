namespace Fambda
{
    /// <summary>
    /// Int32 type hash-code.
    /// </summary>
    public struct HashableInt32 : Hashable<Int32>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="Int32"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int32"/> value.</returns>
        public int GetHashCode(Int32 t)
            => t.GetHashCode();
    }
}
