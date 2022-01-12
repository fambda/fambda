namespace Fambda
{
    /// <summary>
    /// Either type hash-code.
    /// </summary>
    public struct HashableEither<L, R> : Hashable<Either<L, R>>
    {
        /// <summary>
        /// Get hash code of the value.
        /// </summary>
        /// <param name="either"><see cref="Either{L,R}"/> to get the hash-code.</param>
        /// <returns>The hash-code of <see cref="Either{L,R}"/>.</returns>
        public int GetHashCode(Either<L, R> either)
            => either.ToString().GetHashCode();
    }
}
