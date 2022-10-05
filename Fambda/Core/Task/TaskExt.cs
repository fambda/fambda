using System;
using System.Threading.Tasks;

namespace Fambda
{
    /// <summary>
    /// Task functional extensions.
    /// </summary>
    public static class TaskExt
    {
        #region Map

        /// <summary>
        /// <para>Maps <see cref="Task{T}">Task&lt;T></see> into <see cref="Task{T}">Task&lt;Res></see>.</para>
        /// <para><c>Task&lt;T> → (T → Res) → Task&lt;Res></c></para>
        /// </summary>
        public static async Task<Res> Map<T, Res>(this Task<T> self, Func<T, Res> func)
            => func(await self.ConfigureAwait(false));

        #endregion

        #region Linq

        /// <summary>
        /// Linq Select for <see cref="Task{T}">Task&lt;T></see>.
        /// </summary>
        public static async Task<Res> Select<T, Res>(this Task<T> self, Func<T, Res> func)
            => func(await self.ConfigureAwait(false));

        /// <summary>
        /// Linq SelectMany for <see cref="Task{T}">Task&lt;T></see>.
        /// </summary>
        public static async Task<Res> SelectMany<T, Res>(this Task<T> self, Func<T, Task<Res>> func)
            => await func(await self.ConfigureAwait(false)).ConfigureAwait(false);

        /// <summary>
        /// Linq SelectMany for <see cref="Task{T}">Task&lt;T></see>.
        /// </summary>
        public static async Task<Res> SelectMany<T, R, Res>(this Task<T> self, Func<T, Task<R>> func, Func<T, R, Res> project)
        {
            var t = await self.ConfigureAwait(false);
            var r = await func(t).ConfigureAwait(false);
            return project(t, r);
        }

        #endregion
    }
}
