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
    }
}
