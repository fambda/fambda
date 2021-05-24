namespace Fambda
{
    /// <summary>
    /// Represents an EitherLeft 'L' type.
    /// </summary>
    /// <typeparam name="L">Left</typeparam>
    public struct EitherLeft<L>
    {
        internal L Value { get; }

        internal EitherLeft(L value) { Value = value; }

        /// <summary>
        /// Returns a string that represents the current <see cref="EitherLeft{L}"/> object.
        /// </summary>
        /// <returns>A string that represents the current <see cref="EitherLeft{L}"/> object.</returns>
        public override string ToString() => $"Left({Value})";
    }
}
