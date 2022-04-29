using System;

namespace Fambda
{
    /// <summary>
    /// Exceptional functional extensions.
    /// </summary>
    public static class ExceptionalExt
    {
        #region Map

        /// <summary>
        /// Maps <see cref="Exceptional{T}"/> into <see cref="Exceptional{Res}"/>
        /// </summary>
        public static Exceptional<Res> Map<R, Res>(this Exceptional<R> self, Func<R, Res> func)
            => self.Exception == null ? func(self.Value) : new Exceptional<Res>(self.Exception);

        #endregion

        #region Bind

        /// <summary>
        /// Binds <see cref="Exceptional{T}"/> into <see cref="Exceptional{Res}"/>
        /// </summary>
        public static Exceptional<Res> Bind<R, Res>(this Exceptional<R> self, Func<R, Exceptional<Res>> func)
            => self.Exception == null ? func(self.Value) : new Exceptional<Res>(self.Exception);

        #endregion

        #region Apply

        /// <summary>
        /// <para>Apply function <see cref="Func{T, Res}">Func&lt;T, Res&gt;</see> to unwrapped value of type <c>T</c>, and wrap the result back in an <c>Exceptional</c> (<see cref="Exceptional{T}">Exceptional&lt;Res&gt;</see>).</para>
        /// <para><c>Exceptional&lt;T → Res> → Exceptional&lt;T> → Exceptional&lt;Res></c></para>
        /// </summary>
        /// <typeparam name="T">The type of wrapped function's parameter.</typeparam>
        /// <typeparam name="Res">The type of the wrapped function's return value.</typeparam>
        /// <param name="self">The exceptional containing the function <see cref="Func{T, Res}"/> to be applied on the applicative.</param>
        /// <param name="exceptional">The exceptional containing the value of type <c>T</c>, on which the function <see cref="Func{T, Res}"/> will be applied.</param>
        /// <returns>The result of type <c>Res</c> wrapped in an <c>Exceptional</c> applicative (<see cref="Exceptional{T}">Exceptional&lt;Res&gt;</see>).</returns>
        public static Exceptional<Res> Apply<T, Res>(this Exceptional<Func<T, Res>> self, Exceptional<T> exceptional)
           => self.Match(
                     Exception: ex => ex,
                     Success: func => exceptional.Match(
                                                    Exception: ex => ex,
                                                    Success: t => new Exceptional<Res>(func(t))
                                                  )
                   );

        /// <summary>
        /// <para>Apply function <see cref="Func{T1, T2, Res}">Func&lt;T1, T2, Res&gt;</see> to <see cref="Exceptional{T}">Exceptional&lt;T1&gt;</see>'s unwrapped value of type <c>T1</c>, and wrap the result <see cref="Func{T2, Res}">Func&lt;T2, Res&gt;</see> back in an <c>Exceptional</c> (<see cref="Exceptional{T}">Exceptional&lt;Func&lt;T2, Res&gt;&gt;</see>).</para>
        /// <para><c>Exceptional&lt;T1 → T2 → Res> → Exceptional&lt;T1> → Exceptional&lt;T2 → Res></c></para>
        /// </summary>
        /// <typeparam name="T1">The type of wrapped function's first parameter.</typeparam>
        /// <typeparam name="T2">The type of wrapped function's second parameter.</typeparam>
        /// <typeparam name="Res">The type of the wrapped function's return value.</typeparam>
        /// <param name="self">The exceptional containing the function <see cref="Func{T1, T2, Res}"/> to be applied on the applicative.</param>
        /// <param name="exceptional">The exceptional containing the value of type <c>T1</c>, on which the function <see cref="Func{T1, T2, Res}"/> will be applied.</param>
        /// <returns>An unary function <see cref="Func{T2, Res}">Func&lt;T2, Res&gt;</see> wrapped in an <c>Exceptional</c> applicative (<see cref="Exceptional{T}">Exceptional&lt;Func&lt;T2, Res&gt;&gt;</see>).</returns>
        public static Exceptional<Func<T2, Res>> Apply<T1, T2, Res>(this Exceptional<Func<T1, T2, Res>> self, Exceptional<T1> exceptional)
           => Apply(self.Map(F.Curry), exceptional);

        #endregion

    }
}
