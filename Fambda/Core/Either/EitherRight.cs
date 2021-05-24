namespace Fambda
{
    /// <summary>
    /// Represents an EitherRight 'R' type.
    /// </summary>
    /// <typeparam name="R">Right</typeparam>
    public struct EitherRight<R>
    {
        internal R Value { get; }

        internal EitherRight(R value) { Value = value; }

        /// <summary>
        /// Returns a string that represents the current <see cref="EitherLeft{L}"/> object.
        /// </summary>
        /// <returns>A string that represents the current <see cref="EitherLeft{L}"/> object.</returns>
        public override string ToString() => $"Right({Value})";
    }
}
