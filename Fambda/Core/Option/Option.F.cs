using Fambda.Contracts;

namespace Fambda
{
    public static partial class F
    {
        /// <summary>
        /// Create a <see cref="Option{T}"/> in Some state.
        /// </summary>
        /// <typeparam name="T">Bound value type</typeparam>
        /// <param name="value">T value to be made optional</param>
        /// <exception cref="OptionSomeValueMustNotBeNullException">Thrown when some value is null.</exception>
        /// <returns>An <see cref="Option{T}"/> instance.</returns>
        public static Option<T> Some<T>(T value)
            => new OptionSome<T>(value);


        /// <summary>
        /// None state of <see cref="Option{T}"/>.
        /// </summary>
        /// <returns>An <see cref="OptionNone"/> instance.</returns>
        public static OptionNone None
            => OptionNone.Default;
    }
}
