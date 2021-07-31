using System;

namespace Fambda
{
    /// <summary>
    /// Exceptional functional extensions.
    /// </summary>
    public static class ExceptionalExt
    {
        /// <summary>
        /// Maps <see cref="Exceptional{T}"/> into <see cref="Exceptional{Res}"/>
        /// </summary>
        public static Exceptional<Res> Map<R, Res>(this Exceptional<R> exceptional, Func<R, Res> func)
            => exceptional.Exception == null ? func(exceptional.Value) : new Exceptional<Res>(exceptional.Exception);

        /// <summary>
        /// Binds <see cref="Exceptional{T}"/> into <see cref="Exceptional{Res}"/>
        /// </summary>
        public static Exceptional<Res> Bind<R, Res>(this Exceptional<R> exceptional, Func<R, Exceptional<Res>> func)
            => exceptional.Exception == null ? func(exceptional.Value) : new Exceptional<Res>(exceptional.Exception);

    }
}
