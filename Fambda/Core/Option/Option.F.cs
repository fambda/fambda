using Fambda.Contracts;

namespace Fambda
{
    public static partial class F
    {
        /// <summary>
        /// None state of <see cref="Option{T}"/>.
        /// </summary>
        /// <returns>An <see cref="OptionNone"/> instance.</returns>
        public static OptionNone None
            => OptionNone.Default;

        /// <summary>
        /// Create a <see cref="Option{T}"/> in Some state.
        /// </summary>
        /// <typeparam name="T">The type of bound value.</typeparam>
        /// <param name="value">The <typeparamref name="T"/> value to wrap in <see cref="Option{T}"/></param>
        /// <exception cref="OptionSomeValueMustNotBeNullException">Thrown when some value is null.</exception>
        /// <returns>An <see cref="Option{T}"/> instance.</returns>
        public static Option<T> Some<T>(T value)
            => new OptionSome<T>(value);
    }
}
