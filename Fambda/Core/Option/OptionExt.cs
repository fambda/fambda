using System;
using System.Collections.Generic;
using System.Linq;
using static Fambda.F;

namespace Fambda
{
    /// <summary>
    /// Option functional extensions.
    /// </summary>
    public static class OptionExt
    {
        #region Map
        /// <summary>
        /// Maps <see cref="Option{T}"/> into <see cref="Option{Res}"/>
        /// </summary>
        public static Option<Res> Map<T, Res>(this Option<T> option, Func<T, Res> func)
            => option.Match(
                        None: () => None,
                        Some: (t) => Some(func(t))
                      );

        /// <summary>
        /// Maps <see cref="Option{T1}"/> into <see cref="Option{Func{T2, Res}}"/>
        /// </summary>
        public static Option<Func<T2, Res>> Map<T1, T2, Res>(this Option<T1> option, Func<T1, T2, Res> func)
            => option.Map(F.Curry(func));

        #endregion

        #region Bind

        /// <summary>
        /// Binds <see cref="Option{T}"/> into <see cref="Option{Res}"/>
        /// </summary>
        public static Option<Res> Bind<T, Res>(this Option<T> option, Func<T, Option<Res>> func)
            => option.Match(
                        None: () => None,
                        Some: (t) => func(t)
                      );

        #endregion

        #region Apply

        /// <summary>
        /// <para>Apply function <see cref="Func{T, Res}">Func&lt;T, Res&gt;</see> to unwrapped value of type <c>T</c>, and wrap the result back in an <c>Option</c> (<see cref="Option{T}">Option&lt;Res&gt;</see>).</para>
        /// <para><c>Option&lt;T → Res> → Option&lt;T> → Option&lt;Res></c></para>
        /// </summary>
        /// <typeparam name="T">The type of wrapped function's parameter.</typeparam>
        /// <typeparam name="Res">The type of the wrapped function's return value.</typeparam>
        /// <param name="optionF">The option containing the function <see cref="Func{T, Res}"/> to be applied on the applicative.</param>
        /// <param name="optionT">The option containing the value of type <c>T</c>, on which the function <see cref="Func{T, Res}"/> will be applied.</param>
        /// <returns>The result of type <c>Res</c> wrapped in an <c>Option</c> applicative (<see cref="Option{T}">Option&lt;Res&gt;</see>).</returns>
        public static Option<Res> Apply<T, Res>(this Option<Func<T, Res>> optionF, Option<T> optionT)
           => optionF.Match(
                          None: () => None,
                          Some: func => optionT.Match(
                                                  None: () => None,
                                                  Some: t => Some(func(t))
                                               )
                      );

        /// <summary>
        /// <para>Apply function <see cref="Func{T1, T2, Res}">Func&lt;T1, T2, Res&gt;</see> to <see cref="Option{T}">Option&lt;T1&gt;</see>'s unwrapped value of type <c>T1</c>, and wrap the result <see cref="Func{T2, Res}">Func&lt;T2, Res&gt;</see> back in an <c>Option</c> (<see cref="Option{T}">Option&lt;Func&lt;T2, Res&gt;&gt;</see>).</para>
        /// <para><c>Option&lt;T1 → T2 → Res> → Option&lt;T1> → Option&lt;T2 → Res></c></para>
        /// </summary>
        /// <typeparam name="T1">The type of wrapped function's first parameter.</typeparam>
        /// <typeparam name="T2">The type of wrapped function's second parameter.</typeparam>
        /// <typeparam name="Res">The type of the wrapped function's return value.</typeparam>
        /// <param name="optionF">The option containing the function <see cref="Func{T1, T2, Res}"/> to be applied on the applicative.</param>
        /// <param name="optionT1">The option containing the value of type <c>T1</c>, on which the function <see cref="Func{T1, T2, Res}"/> will be applied.</param>
        /// <returns>An unary function <see cref="Func{T2, Res}">Func&lt;T2, Res&gt;</see> wrapped in an <c>Option</c> applicative (<see cref="Option{T}">Option&lt;Func&lt;T2, Res&gt;&gt;</see>).</returns>
        public static Option<Func<T2, Res>> Apply<T1, T2, Res>(this Option<Func<T1, T2, Res>> optionF, Option<T1> optionT1)
           => Apply(optionF.Map(F.Curry), optionT1);

        #endregion

        #region Linq

        /// <summary>
        /// Projects map <see cref="Option{T}"/> into <see cref="Option{Res}"/>.
        /// </summary>
        public static Option<Res> Select<T, Res>(this Option<T> option, Func<T, Res> func)
            => option.Map(func);

        /// <summary>
        /// Projects bind <see cref="Option{T}"/> into <see cref="Option{Res}"/>.
        /// </summary>
        public static Option<Res> SelectMany<T, Res>(this Option<T> option, Func<T, Option<Res>> func)
            => option.Bind(func);

        /// <summary>
        /// Projects <see cref="Option{T}"/> into <see cref="Option{Res}"/>.
        /// </summary>
        public static Option<Res> SelectMany<T, R, Res>(this Option<T> option, Func<T, Option<R>> func, Func<T, R, Res> project)
            => option.Bind(t => func(t).Map(c => project(t, c)));

        /// <summary>
        /// Applies a predicate to the bound value.
        /// </summary>
        /// <returns><see cref="OptionSome{T}"/> if the option is in a Some state and <paramref name="pred"/> predicate returns true; otherwise, <see cref="OptionNone"/>.</returns>
        public static Option<T> Where<T>(this Option<T> option, Func<T, bool> pred)
            => option.Match(
                        None: () => None,
                        Some: (t) => pred(t) ? option : None
                      );

        #endregion

        #region AsEnumerable

        /// <summary>
        /// Converts <see cref="Option{T}"/> into <see cref="IEnumerable{T}"/> with one or no items.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> with one or no items.</returns>
        public static IEnumerable<T> AsEnumerable<T>(this Option<T> option)
            => option.Match(
                        None: () => Enumerable.Empty<T>(),
                        Some: (t) => { return new List<T>() { t }; }
                      );

        #endregion
    }
}
