namespace Fambda
{
    /// <summary>
    /// Single type hash-code.
    /// </summary>
    public struct HashableSingle : Hashable<Single>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="t"><see cref="Single"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Int32"/> value.</returns>
        public int GetHashCode(Single t)
            => t.GetHashCode();
    }
}
