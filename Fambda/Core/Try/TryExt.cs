using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Try functional extensions.
    /// </summary>
    public static class TryExt
    {
        /// <summary>
        /// Safely invokes <see cref="Fambda.Try{T}"/> delegate.
        /// </summary>
        /// <returns><see cref="Exceptional{T}"/> Exception or Success.</returns>
        [Pure]
        public static Exceptional<T> Try<T>(this Try<T> @try)
        {
            try
            {
                return @try();
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        /// <summary>
        /// Maps <see cref="Try{T}"/> into <see cref="Try{Res}"/>
        /// </summary>
        public static Try<Res> Map<T, Res>(this Try<T> @try, Func<T, Res> func)
            => () => @try.Try()
                         .Match<Exceptional<Res>>(
                            Exception: ex => ex,
                            Success: t => func(t)
                         );

        /// <summary>
        /// Binds <see cref="Try{T}"/> into <see cref="Try{Res}"/>
        /// </summary>
        public static Try<Res> Bind<T, Res>(this Try<T> @try, Func<T, Try<Res>> func)
            => () => @try.Try()
                         .Match(
                             Exception: ex => ex,
                             Success: t => func(t).Try()
                         );
    }
}
