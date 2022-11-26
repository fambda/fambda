using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Fambda functions.
    /// </summary>
    /// <remarks>
    /// Add to the top of .cs file:
    /// <code>
    /// <![CDATA[
    /// using static Fambda.F;
    /// ]]>
    /// </code>
    /// </remarks>
    public static partial class F
    {
        #region Identity

        /// <summary>
        /// <para>The identity function. Takes one argument and returns the argument without modifications.</para>
        /// <para><c>T -> T</c></para>
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="x">The <typeparamref name="T" /> argument.</param>
        /// <returns>The <typeparamref name="T" /> argument to return.</returns>
        /// <remarks>
        /// See <a href="https://en.wikipedia.org/wiki/Identity_function">this link</a> for more information.
        /// </remarks>
        [Pure]
        public static T Identity<T>(T x)
            => x;

        #endregion

        #region Curry

        /// <summary>
        /// Curry a function with two parameters.
        /// </summary>
        /// <typeparam name="T1">The type of first parameter.</typeparam>
        /// <typeparam name="T2">The type of second parameter.</typeparam>
        /// <typeparam name="Res">The type of the return value.</typeparam>
        /// <param name="func">Function to be curried.</param>
        /// <returns>Curried function.</returns>
        /// <remarks>Transforms (T1, T2) -> Res to T1 -> T2 -> Res.</remarks>
        [Pure]
        public static Func<T1, Func<T2, Res>> Curry<T1, T2, Res>(Func<T1, T2, Res> func)
            => (T1 t1) => (T2 t2) => func(t1, t2);


        /// <summary>
        /// Curry function with three parameters.
        /// </summary>
        /// <typeparam name="T1">The type of first parameter.</typeparam>
        /// <typeparam name="T2">The type of second parameter.</typeparam>
        /// <typeparam name="T3">The type of third parameter.</typeparam>
        /// <typeparam name="Res">The type of the return value.</typeparam>
        /// <param name="func">Function to be curried.</param>
        /// <returns>Curried function.</returns>
        /// <remarks>Transforms (T1, T2, T3) -> Res to T1 -> T2 -> T3 -> Res.</remarks>
        [Pure]
        public static Func<T1, Func<T2, Func<T3, Res>>> Curry<T1, T2, T3, Res>(Func<T1, T2, T3, Res> func)
            => (T1 t1) => (T2 t2) => (T3 t3) => func(t1, t2, t3);

        /// <summary>
        /// Curry function with four parameters.
        /// </summary>
        /// <typeparam name="T1">The type of first parameter.</typeparam>
        /// <typeparam name="T2">The type of second parameter.</typeparam>
        /// <typeparam name="T3">The type of third parameter.</typeparam>
        /// <typeparam name="T4">The type of fourth parameter.</typeparam>
        /// <typeparam name="Res">The type of the return value.</typeparam>
        /// <param name="func">Function to be curried.</param>
        /// <returns>Curried function.</returns>
        /// <remarks>Transforms (T1, T2, T3, T4) -> Res to T1 -> T2 -> T3 -> T4 -> Res.</remarks>
        [Pure]
        public static Func<T1, Func<T2, Func<T3, Func<T4, Res>>>> Curry<T1, T2, T3, T4, Res>(Func<T1, T2, T3, T4, Res> func)
            => (T1 t1) => (T2 t2) => (T3 t3) => (T4 t4) => func(t1, t2, t3, t4);

        #endregion

        #region Uncurry

        /// <summary>
        /// Converts curried function to a function in uncurried format with two parameters.
        /// </summary>
        /// <typeparam name="T1">The type of first parameter.</typeparam>
        /// <typeparam name="T2">The type of second parameter.</typeparam>
        /// <typeparam name="Res">The type of the return value.</typeparam>
        /// <param name="func">Function to be uncurried.</param>
        /// <returns>Uncurried function.</returns>
        /// <remarks>Transforms T1 -> T2 -> Res to (T1, T2) -> Res.</remarks>
        [Pure]
        public static Func<T1, T2, Res> Uncurry<T1, T2, Res>(Func<T1, Func<T2, Res>> func)
            => (t1, t2) => func(t1)(t2);

        /// <summary>
        /// Converts curried function to a function in uncurried format with three parameters.
        /// </summary>
        /// <typeparam name="T1">The type of first parameter.</typeparam>
        /// <typeparam name="T2">The type of second parameter.</typeparam>
        /// <typeparam name="T3">The type of third parameter.</typeparam>
        /// <typeparam name="Res">The type of the return value.</typeparam>
        /// <param name="func">Function to be uncurried.</param>
        /// <returns>Uncurried function.</returns>
        /// <remarks>Transforms T1 -> T2 -> T3 -> Res to (T1, T2, T3) -> Res.</remarks>
        [Pure]
        public static Func<T1, T2, T3, Res> Uncurry<T1, T2, T3, Res>(Func<T1, Func<T2, Func<T3, Res>>> func)
            => (t1, t2, t3) => func(t1)(t2)(t3);

        /// <summary>
        /// Converts curried function to a function in uncurried format with four parameters.
        /// </summary>
        /// <typeparam name="T1">The type of first parameter.</typeparam>
        /// <typeparam name="T2">The type of second parameter.</typeparam>
        /// <typeparam name="T3">The type of third parameter.</typeparam>
        /// <typeparam name="T4">The type of fourth parameter.</typeparam>
        /// <typeparam name="Res">The type of the return value.</typeparam>
        /// <param name="func">Function to be uncurried.</param>
        /// <returns>Uncurried function.</returns>
        /// <remarks>Transforms T1 -> T2 -> T3 -> T4 -> Res to (T1, T2, T3, T4) -> Res.</remarks>
        [Pure]
        public static Func<T1, T2, T3, T4, Res> Uncurry<T1, T2, T3, T4, Res>(Func<T1, Func<T2, Func<T3, Func<T4, Res>>>> func)
            => (t1, t2, t3, t4) => func(t1)(t2)(t3)(t4);

        #endregion

        #region IsNull

        /// <summary>
        /// Indicates whether the specified <typeparamref name="T" /> value is null.
        /// </summary>
        /// <param name="value">The <typeparamref name="T" /> value to test.</param>
        /// <returns>true if the specified <paramref name="value"/> is null; otherwise, false.</returns>
        [Pure]
        public static bool IsNull<T>(T value)
            => CheckHelper<T>.IsNull(value);

        #endregion
    }
}
