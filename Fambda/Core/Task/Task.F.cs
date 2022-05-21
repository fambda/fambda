using System;
using System.Threading.Tasks;

namespace Fambda
{
    public static partial class F
    {
        /// <summary>
        /// Lifts a <typeparamref name="T"/> value into <see cref="Task{T}"/> that's completed successfully.
        /// </summary>
        /// <typeparam name="T">The type of bound value.</typeparam>
        /// <param name="t">The <typeparamref name="T"/> value to wrap in <see cref="Task{T}"/></param>
        /// <returns>An <see cref="Task{T}"/> instance.</returns>
        public static Task<T> TaskSucc<T>(T t) => Task.FromResult(t);


        /// <summary>
        /// Lifts a <typeparamref name="T"/> value into <see cref="Task{T}"/> that's completed with a specified exception.
        /// </summary>
        /// <typeparam name="T">The <typeparamref name="T"/> in <see cref="Task{T}"/></typeparam>
        /// <param name="ex">The <see cref="Exception"/> exception.</param>
        /// <returns>An <see cref="Task{T}"/> instance.</returns>
        public static Task<T> TaskFail<T>(Exception ex) => Task.FromException<T>(ex);
    }
}
