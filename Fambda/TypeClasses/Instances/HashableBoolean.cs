namespace Fambda
{
    /// <summary>
    /// Boolean type hash-code.
    /// </summary>
    public struct HashableBoolean : Hashable<Boolean>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="Boolean"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int32"/> value.</returns>
        public int GetHashCode(Boolean t)
            => t.GetHashCode();
    }
}
