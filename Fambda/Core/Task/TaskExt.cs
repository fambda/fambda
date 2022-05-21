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
    }
}
