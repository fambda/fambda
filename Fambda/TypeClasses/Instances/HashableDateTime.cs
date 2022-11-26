namespace Fambda
{
    /// <summary>
    /// DateTime type hash-code.
    /// </summary>
    public struct HashableDateTime : Hashable<DateTime>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="DateTime"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int32"/> value.</returns>
        public int GetHashCode(DateTime t)
            => t.GetHashCode();
    }
}
