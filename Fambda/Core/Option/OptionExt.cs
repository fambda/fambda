using System;
using static Fambda.F;

namespace Fambda
{
    /// <summary>
    /// Option functional extensions.
    /// </summary>
    public static class OptionExt
    {
        /// <summary>
        /// Maps <see cref="Option{T}"/> into <see cref="Option{Res}"/>
        /// </summary>
        public static Option<Res> Map<T, Res>(this Option<T> option, Func<T, Res> func)
            => option.Match(
                        Some: (t) => Some(func(t)),
                        None: () => None
                      );

        /// <summary>
        /// Binds <see cref="Option{T}"/> into <see cref="Option{Res}"/>
        /// </summary>
        public static Option<Res> Bind<T, Res>(this Option<T> option, Func<T, Option<Res>> func)
            => option.Match(
                        Some: (t) => func(t),
                        None: () => None
                      );


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
                         Some: (t) => pred(t) ? option : None,
                         None: () => None
                      );

        #endregion
    }
}
