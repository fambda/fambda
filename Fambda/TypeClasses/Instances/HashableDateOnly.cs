namespace Fambda
{
    /// <summary>
    /// DateOnly type hash-code.
    /// </summary>
    public struct HashableDateOnly : Hashable<DateOnly>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="DateOnly"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int32"/> value.</returns>
        public int GetHashCode(DateOnly t)
            => t.GetHashCode();
    }
}
