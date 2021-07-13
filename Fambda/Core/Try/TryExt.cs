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
    }
}
