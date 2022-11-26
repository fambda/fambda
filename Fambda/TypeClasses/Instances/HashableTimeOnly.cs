namespace Fambda
{
    /// <summary>
    /// TimeOnly type hash-code.
    /// </summary>
    public struct HashableTimeOnly : Hashable<TimeOnly>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="TimeOnly"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int32"/> value.</returns>
        public int GetHashCode(TimeOnly t)
            => t.GetHashCode();
    }
}
