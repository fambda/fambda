using System;
using System.Collections.Generic;
using System.Linq;

namespace Fambda
{
    /// <summary>
    /// Represents base Record type.
    ///
    /// Provides:
    ///  - structural equality
    ///  - structural hashing (`GetHashCode`)
    ///  - operators `==`, `!=` 
    /// </summary>
    /// <typeparam name="T">Record type.</typeparam>
    public abstract class Record<T> : IEquatable<T> where T : Record<T>
    {
        /// <summary>
        /// Equality components.
        /// </summary>
        protected abstract IEnumerable<object> GetEqualityComponents();

        #region Structural hashing

        /// <summary>
        /// Returns the hash-code based on equality components.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Record{T}"/> object.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return GetEqualityComponents().Aggregate(17, (current, obj) => current * 23 + (obj?.GetHashCode() ?? 0));
            }
        }

        #endregion

        #region Structural equality

        /// <summary>
        /// Determines whether specified object is equal to the current <see cref="Record{T}"/> object.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="Record{T}"/> object.</param>
        /// <returns>true if the specified object is equal to the current <see cref="Record{T}"/> object; otherwise, false.</returns>
        public override bool Equals(object obj)
            => Equals(obj as T);

        /// <summary>
        /// Indicates whether the current <see cref="Record{T}"/> is equal to another <see cref="Record{T}"/>
        /// </summary>
        /// <param name="other">An <see cref="Record{T}"/> to compare with this <see cref="Record{T}"/>.</param>
        /// <returns>true if the current <see cref="Record{T}"/> object is equal to the other parameter; otherwise, false.</returns>
        public virtual bool Equals(T other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return EqualsComponents(other);
        }

        private bool EqualsComponents(Record<T> other)
            => GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());


        #endregion

        #region Overload operators

        /// <summary>
        /// Compares two <see cref="Record{T}"/> objects through equality operator.
        /// </summary>
        /// <param name="lhs"><see cref="Record{T}"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Record{T}"/> right hand side object.</param>
        /// <returns>true if lhs is equal to the rhs; otherwise, false.</returns>
        public static bool operator ==(Record<T> lhs, Record<T> rhs)
        {
            if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null))
            {
                return true;
            }

            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
            {
                return false;
            }

            var result = lhs.Equals(rhs);

            return result;
        }



        /// <summary>
        /// Compares two <see cref="Record{T}"/> objects through inequality operator.
        /// </summary>
        /// <param name="lhs"><see cref="Record{T}"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Record{T}"/> right hand side object.</param>
        /// <returns>true if the lhs object is not equal to rhs; otherwise, false.</returns>
        public static bool operator !=(Record<T> lhs, Record<T> rhs)
            => !(lhs == rhs);


        #endregion
    }
}
