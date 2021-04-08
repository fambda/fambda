using System;
using static Fambda.F;

namespace Fambda
{
    public static class OptionExt
    {
        public static Option<Res> Map<T, Res>(this Option<T> option, Func<T, Res> func)
            => option.Match(
                        Some: (t) => Some(func(t)),
                        None: () => None
                      );

        public static Option<Res> Bind<T, Res>(this Option<T> option, Func<T, Option<Res>> func)
            => option.Match(
                        Some: (t) => func(t),
                        None: () => None
                      );
    }
}
