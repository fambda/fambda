
namespace Fambda
{
    /// <summary>
    /// Option type hash-code.
    /// </summary>
    public struct HashableOption<T> : Hashable<Option<T>>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="option"><see cref="Option{T}"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Option{T}"/>.</returns>
        public int GetHashCode(Option<T> option)
            => option.ToString().GetHashCode();
    }
}
