using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Represents an Exceptional type.
    /// </summary>
    /// <typeparam name="T">The type of the value to be wrapped.</typeparam>
    public readonly struct Exceptional<T> : IEquatable<Exceptional<T>>
    {
        internal Exception? Exception { get; }
        internal T? Value { get; }

        internal Exceptional(Exception exception)
        {
            Exception = exception;
            Value = default;
        }

        internal Exceptional(T value)
        {
            Exception = null;
            Value = value;
        }

        /// <summary>
        /// Implicit conversion operator from <see cref="Exception"/> to <see cref="Exceptional{T}"/>.
        /// </summary>
        /// <param name="exception"><see cref="Exception"/> object.</param>
        public static implicit operator Exceptional<T>(Exception exception)
            => new(exception);

        /// <summary>
        /// Implicit conversion operator from <typeparamref name="T"/> to <see cref="Exceptional{T}"/>.
        /// </summary>
        /// <param name="value">T value.</param>
        public static implicit operator Exceptional<T>(T value)
            => new(value);

        /// <summary>
        /// Match the Exception and Success of the <see cref="Exceptional{T}"/> and return Res.
        /// </summary>
        /// <typeparam name="Res">Return type.</typeparam>
        /// <param name="Exception">Exception match operation.</param>
        /// <param name="Success">Success match operation.</param>
        public Res Match<Res>(Func<Exception, Res> Exception, Func<T, Res> Success)
            => this.Exception is not null ? Exception(this.Exception!) : Success(this.Value!);

        /// <summary>
        /// Match the Exception and Success of the <see cref="Exceptional{T}"/> and return Res.
        /// </summary>
        /// <typeparam name="Res">Return type.</typeparam>
        /// <param name="Exception">Exception match operation.</param>
        /// <param name="Success">Success match operation.</param>
        public async Task<Res> Match<Res>(Func<Exception, Res> Exception, Func<T, Task<Res>> Success)
            => this.Exception is not null ? await Task.FromResult(Exception(this.Exception!)) : await Success(this.Value!).ConfigureAwait(false);

        /// <summary>
        /// Calculates the hash-code based on whether <see cref="Exceptional{T}"/> is in Exception or Success.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Exceptional{T}"/> object.</returns>
        public override int GetHashCode()
            => Match(
                Exception: (x) => default(HashableException).GetHashCode(x),
                Success: (x) => $"Success({x})".GetHashCode()
               );

        /// <summary>
        /// Indicates whether the current <see cref="Exceptional{T}"/> is equal to another <see cref="Exceptional{T}"/>
        /// </summary>
        /// <param name="other">An <see cref="Exceptional{T}"/> to compare with this <see cref="Exceptional{T}"/>.</param>
        /// <returns>true if the current <see cref="Exceptional{T}"/> object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Exceptional<T> other)
        {
            bool result;

            if (object.Equals(Exception, null) && object.Equals(other.Exception, null))
            {
                result = true;
            }
            else if (object.Equals(Exception, null) || object.Equals(other.Exception, null))
            {
                result = false;
            }
            else
            {
                var typeBased = Exception.GetType() == other.Exception.GetType();
                result = typeBased && object.Equals(Value, other.Value);
            }

            return result;
        }

        /// <summary>
        /// Determines whether specified object is equal to the current <see cref="Exceptional{T}"/> object.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="Exceptional{T}"/> object.</param>
        /// <returns>true if the specified object is equal to the current <see cref="Exceptional{T}"/> object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) { return false; }
            else if (obj is Exceptional<T> exceptional) { return Equals(exceptional); }
            else { return false; }
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="Exceptional{T}"/> object.
        /// </summary>
        /// <returns>A string that represents the current <see cref="Exceptional{T}"/> object.</returns>
        public override string ToString()
            => Match(
                Exception: (x) => $"Exception({x.Message})",
                Success: (x) => $"Success({x})"
               );

        /// <summary>
        /// Compares two <see cref="Exceptional{T}"/> objects through equality operator.
        /// </summary>
        /// <param name="lhs"><see cref="Exceptional{T}"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Exceptional{T}"/> right hand side object.</param>
        /// <returns>true if <paramref name="lhs"/> is equal to the <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public static bool operator ==(Exceptional<T> lhs, Exceptional<T> rhs)
            => Equals(lhs, rhs);

        /// <summary>
        /// Compares two <see cref="Exceptional{T}"/> objects through inequality operator.
        /// </summary>
        /// <param name="lhs"><see cref="Exceptional{T}"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Exceptional{T}"/> right hand side object.</param>
        /// <returns>true if the <paramref name="lhs"/> object is not equal to <paramref name="rhs"/>; otherwise, false.</returns>
        [Pure]
        public static bool operator !=(Exceptional<T> lhs, Exceptional<T> rhs)
            => !Equals(lhs, rhs);
    }
}
