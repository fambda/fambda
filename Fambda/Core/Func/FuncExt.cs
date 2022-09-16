using System;

namespace Fambda
{
    /// <summary>
    /// Func functional extensions.
    /// <list type="bullet">
    ///   <item>
    ///     <term>Apply</term>
    ///     <description>
    ///       Partially applies a n-ary function to its arguments.
    ///       <para>
    ///         Partial function application allows to take a function of many parameters and apply arguments to some of the parameters,
    ///         in order to create a new function that needs only the application of the remaining arguments to produce the equivalent of
    ///         applying all arguments to the original function.
    ///       </para>
    ///     </description>
    ///   </item>
    /// </list>
    /// </summary>
    public static class FuncExt
    {
        #region Map

        /// <summary>
        /// <para>Maps <see cref="Func{A, T}">Func&lt;A, T></see> into <see cref="Func{A, Res}">Func&lt;A, Res></see>.</para>
        /// <para><c>(A → T) → (T → Res) → (A → Res)</c></para>
        /// </summary>
        public static Func<A, Res> Map<A, T, Res>(this Func<A, T> f, Func<T, Res> func)
            => x => func(f(x));

        #endregion

        #region Apply

        /// <summary>
        /// <para>Partially applies a binary function <see cref="Func{T1, T2, Res}">Func&lt;T1, T2, Res></see> to the first argument <c>t1</c>,
        /// and returns a unary function <see cref="Func{T2, Res}">Func&lt;T2, Res></see> accepting the second argument <c>t2</c>.</para>
        /// <para><c>(T1 → T2 → Res) → T1 → (T2 → Res)</c></para>
        /// </summary>
        /// <typeparam name="T1">The type of function's first parameter.</typeparam>
        /// <typeparam name="T2">The type of function's second parameter.</typeparam>
        /// <typeparam name="Res">The type of the function's return value.</typeparam>
        /// <param name="func">Function to be applied.</param>
        /// <param name="t1">Value of the first argument.</param>
        /// <returns>Unary function <see cref="Func{T2, Res}">Func&lt;T2, Res></see> accepting <c>t2</c> argument.</returns>
        public static Func<T2, Res> Apply<T1, T2, Res>(this Func<T1, T2, Res> func, T1 t1)
            => t2 => func(t1, t2);

        /// <summary>
        /// <para>Partially applies a ternary function <see cref="Func{T1, T2, T3, Res}">Func&lt;T1, T2, T3, Res></see> to the first argument <c>t1</c>,
        /// and returns a binary function <see cref="Func{T2, T3, Res}">Func&lt;T2, T3, Res></see> accepting the second and third arguments <c>t2</c>, <c>t3</c>.</para>
        /// <para><c>(T1 → T2 → T3 → Res) → T1 → (T2 → T3 → Res)</c></para>
        /// </summary>
        /// <typeparam name="T1">The type of function's first parameter.</typeparam>
        /// <typeparam name="T2">The type of function's second parameter.</typeparam>
        /// <typeparam name="T3">The type of function's third parameter.</typeparam>
        /// <typeparam name="Res">The type of the function's return value.</typeparam>
        /// <param name="func">Function to be applied.</param>
        /// <param name="t1">Value of the first argument.</param>
        /// <returns>Binary function <see cref="Func{T2, T3, Res}">Func&lt;T2, T3, Res></see> accepting <c>t2</c> and <c>t3</c> arguments.</returns>
        public static Func<T2, T3, Res> Apply<T1, T2, T3, Res>(this Func<T1, T2, T3, Res> func, T1 t1)
            => (t2, t3) => func(t1, t2, t3);

        /// <summary>
        /// <para>Partially applies a ternary function <see cref="Func{T1, T2, T3, Res}">Func&lt;T1, T2, T3, Res></see> to the first two arguments <c>t1</c>, <c>t2</c>
        /// and returns an unary function <see cref="Func{T3, Res}">Func&lt;T3, Res></see> accepting the third arguments <c>t3</c>.</para>
        /// <para><c>(T1 → T2 → T3 → Res) → T1 → T2 → (T3 → Res)</c></para>
        /// </summary>
        /// <typeparam name="T1">The type of function's first parameter.</typeparam>
        /// <typeparam name="T2">The type of function's second parameter.</typeparam>
        /// <typeparam name="T3">The type of function's third parameter.</typeparam>
        /// <typeparam name="Res">The type of the function's return value.</typeparam>
        /// <param name="func">Function to be applied.</param>
        /// <param name="t1">Value of the first argument.</param>
        /// <param name="t2">Value of the second argument.</param>
        /// <returns>Unary function <see cref="Func{T3, Res}">Func&lt;T3, Res></see> accepting <c>t3</c> argument.</returns>
        public static Func<T3, Res> Apply<T1, T2, T3, Res>(this Func<T1, T2, T3, Res> func, T1 t1, T2 t2)
            => (t3) => func(t1, t2, t3);

        /// <summary>
        /// <para>Partially applies a quaternary function <see cref="Func{T1, T2, T3, T4, Res}">Func&lt;T1, T2, T3, T4, Res></see> to the first argument <c>t1</c>
        /// and returns a ternary function <see cref="Func{T2, T3, T4, Res}">Func&lt;T2, T3, T4, Res></see> accepting second, third and fourth arguments <c>t2</c>, <c>t3</c>, <c>t4</c>.</para>
        /// <para><c>(T1 → T2 → T3 → T4 → Res) → T1 → (T2 → T3 → T4 → Res)</c></para>
        /// </summary>
        /// <typeparam name="T1">The type of function's first parameter.</typeparam>
        /// <typeparam name="T2">The type of function's second parameter.</typeparam>
        /// <typeparam name="T3">The type of function's third parameter.</typeparam>
        /// <typeparam name="T4">The type of function's fourth parameter.</typeparam>
        /// <typeparam name="Res">The type of the function's return value.</typeparam>
        /// <param name="func">Function to be applied.</param>
        /// <param name="t1">Value of the first argument.</param>
        /// <returns>Ternary function <see cref="Func{T2, T3, T4, Res}">Func&lt;T2, T3, T4, Res></see> accepting <c>t2</c>, <c>t3</c> and <c>t4</c> arguments.</returns>
        public static Func<T2, T3, T4, Res> Apply<T1, T2, T3, T4, Res>(this Func<T1, T2, T3, T4, Res> func, T1 t1)
            => (t2, t3, t4) => func(t1, t2, t3, t4);

        /// <summary>
        /// <para>Partially applies a quaternary function <see cref="Func{T1, T2, T3, T4, Res}">Func&lt;T1, T2, T3, T4, Res></see> to the first two arguments <c>t1</c>, <c>t2</c>
        /// and returns a binary function <see cref="Func{T3, T4, Res}">Func&lt;T3, T4, Res></see> accepting the third and fourth arguments <c>t3</c>, <c>t4</c>.</para>
        /// <para><c>(T1 → T2 → T3 → T4 → Res) → T1 → T2 → (T3 → T4 → Res)</c></para>
        /// </summary>
        /// <typeparam name="T1">The type of function's first parameter.</typeparam>
        /// <typeparam name="T2">The type of function's second parameter.</typeparam>
        /// <typeparam name="T3">The type of function's third parameter.</typeparam>
        /// <typeparam name="T4">The type of function's fourth parameter.</typeparam>
        /// <typeparam name="Res">The type of the function's return value.</typeparam>
        /// <param name="func">Function to be applied.</param>
        /// <param name="t1">Value of the first argument.</param>
        /// <param name="t2">Value of the second argument.</param>
        /// <returns>Binary function <see cref="Func{T3, T4, Res}">Func&lt;T3, T4, Res></see> accepting <c>t3</c> and <c>t4</c> arguments.</returns>
        public static Func<T3, T4, Res> Apply<T1, T2, T3, T4, Res>(this Func<T1, T2, T3, T4, Res> func, T1 t1, T2 t2)
            => (t3, t4) => func(t1, t2, t3, t4);

        /// <summary>
        /// <para>Partially applies a quaternary function <see cref="Func{T1, T2, T3, T4, Res}">Func&lt;T1, T2, T3, T4, Res></see> to the first three arguments <c>t1</c>, <c>t2</c>, <c>t3</c> 
        /// and returns an unary function <see cref="Func{T4, Res}">Func&lt;T4, Res></see> accepting the fourth argument <c>t4</c>.</para>
        ///<para><c>(T1 → T2 → T3 → T4 → Res) → T1 → T2 → T3 → (T4 → Res)</c></para>
        /// </summary>
        /// <typeparam name="T1">The type of function's first parameter.</typeparam>
        /// <typeparam name="T2">The type of function's second parameter.</typeparam>
        /// <typeparam name="T3">The type of function's third parameter.</typeparam>
        /// <typeparam name="T4">The type of function's fourth parameter.</typeparam>
        /// <typeparam name="Res">The type of the function's return value.</typeparam>
        /// <param name="func">Function to be applied.</param>
        /// <param name="t1">Value of the first argument.</param>
        /// <param name="t2">Value of the second argument.</param>
        /// <param name="t3">Value of the third argument.</param>
        /// <returns>Binary function <see cref="Func{T4, Res}">Func&lt;T4, Res></see> accepting <c>t4</c> argument.</returns>
        public static Func<T4, Res> Apply<T1, T2, T3, T4, Res>(this Func<T1, T2, T3, T4, Res> func, T1 t1, T2 t2, T3 t3)
            => (t4) => func(t1, t2, t3, t4);

        #endregion

        #region Compose

        /// <summary>
        /// <para>Compose <see cref="Func{T1,T2}">Func&lt;T1, T2></see> and <see cref="Func{T2,Res}">Func&lt;T2, Res></see> into <see cref="Func{T1,Res}">Func&lt;T1, Res></see>.</para>
        /// <para><c>g ∘ f : T1 → Res</c>, where <c>f : T1 → T2</c> and <c>g : T2 → Res</c></para>
        /// </summary>
        /// <typeparam name="T1">The type of <c>f</c> function's first parameter.</typeparam>
        /// <typeparam name="T2">The type of <c>f</c> function's return and <c>g</c> function's first parameter.</typeparam>
        /// <typeparam name="Res">The type of the function composition return value.</typeparam>
        /// <param name="g">Function to compose, will be g is applied to the result of applying the function f to x.</param>
        /// <param name="f">Function to be composed with, will be applied to x.</param>
        /// <returns>The <see cref="Func{T1,Res}">Func&lt;T1, Res></see> function.</returns>
        /// <remarks>
        /// See <a href="https://en.wikipedia.org/wiki/Function_composition">this link</a> for more information.
        /// </remarks>
        public static Func<T1, Res> Compose<T1, T2, Res>(this Func<T2, Res> g, Func<T1, T2> f)
            => x => g(f(x));

        #endregion
    }
}
