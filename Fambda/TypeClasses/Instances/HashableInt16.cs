namespace Fambda
{
    /// <summary>
    /// Int16 type hash-code.
    /// </summary>
    public struct HashableInt16 : Hashable<Int16>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="Int16"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int32"/> value.</returns>
        public int GetHashCode(Int16 t)
            => t.GetHashCode();
    }
}
