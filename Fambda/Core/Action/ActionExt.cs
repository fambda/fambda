using System;

namespace Fambda
{
    using static F;

    /// <summary>
    /// Action conversion extensions.
    /// </summary>
    public static class ActionExt
    {
        /// <summary>
        /// Converts <see cref="Action"/> to <see cref="Func{Unit}"/>.
        /// </summary>
        /// <returns><see cref="Func{Unit}"/></returns>
        public static Func<Unit> ToFunc(this Action action)
            => () => { action(); return Unit(); };

        /// <summary>
        /// Converts <see cref="Action{T}"/> to <see cref="Func{Unit}"/>.
        /// </summary>
        /// <returns><see cref="Func{T, Unit}"/></returns>
        public static Func<T, Unit> ToFunc<T>(this Action<T> action)
            => t => { action(t); return Unit(); };

        /// <summary>
        /// Converts <see cref="Action{T1, T2}"/> to <see cref="Func{T1, T2, Unit}"/>.
        /// </summary>
        /// <returns><see cref="Func{T1, T2, Unit}"/></returns>
        public static Func<T1, T2, Unit> ToFunc<T1, T2>(this Action<T1, T2> action)
            => (T1 t1, T2 t2) => { action(t1, t2); return Unit(); };

        /// <summary>
        /// Converts <see cref="Action{T1, T2, T3}"/> to <see cref="Func{T1, T2, T3, Unit}"/>.
        /// </summary>
        /// <returns><see cref="Func{T1, T2, T3, Unit}"/></returns>
        public static Func<T1, T2, T3, Unit> ToFunc<T1, T2, T3>(this Action<T1, T2, T3> action)
            => (T1 t1, T2 t2, T3 t3) => { action(t1, t2, t3); return Unit(); };

        /// <summary>
        /// Converts <see cref="Action{T1, T2, T3, T4}"/> to <see cref="Func{T1, T2, T3, T4, Unit}"/>.
        /// </summary>
        /// <returns><see cref="Func{T1, T2, T3, T4, Unit}"/></returns>
        public static Func<T1, T2, T3, T4, Unit> ToFunc<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
            => (T1 t1, T2 t2, T3 t3, T4 t4) => { action(t1, t2, t3, t4); return Unit(); };
    }
}
