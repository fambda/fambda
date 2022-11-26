namespace Fambda
{
    public static partial class F
    {
        /// <summary>
        /// Create an <see cref="EitherLeft{L}"/>.
        /// </summary>
        /// <typeparam name="L">Left</typeparam>
        /// <param name="left">Left value</param>
        /// <returns>An <see cref="EitherLeft{L}"/> instance.</returns>
        public static EitherLeft<L> Left<L>(L left) => new(left);

        /// <summary>
        /// Create an <see cref="EitherRight{R}"/>.
        /// </summary>
        /// <typeparam name="R">Right</typeparam>
        /// <param name="right">Right value</param>
        /// <returns>An <see cref="EitherRight{R}"/> instance.</returns>
        public static EitherRight<R> Right<R>(R right) => new(right);
    }
}
