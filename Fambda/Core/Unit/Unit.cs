using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Represents an Unit type. 
    /// </summary>
    /// <remarks>
    /// This type that allows only one value (and thus can hold no information).
    /// See <a href="https://en.wikipedia.org/wiki/Unit_type">this link</a> for more information.
    /// </remarks>
    public struct Unit : IEquatable<Unit>, IComparable<Unit>
    {
        private static readonly int _zero = 0;

        /// <summary>
        /// Returns <see cref="Unit"/>.
        /// </summary>
        public static readonly Unit Default = new Unit();

        /// <summary>
        /// Returns the hash-code based on <see cref="Unit"/> that is always zero.
        /// </summary>
        [Pure]
        public override int GetHashCode()
            => _zero;

        /// <summary>
        /// Determines whether specified object is equal to the current <see cref="Unit"/> object.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="Unit"/> object.</param>
        /// <returns>true if the specified object is equal to the current <see cref="Unit"/> object; otherwise, false.</returns>
        [Pure]
        public override bool Equals(object? obj)
            => obj is Unit;

        /// <summary>
        /// Indicates whether the current <see cref="Unit"/> is equal to another <see cref="Unit"/>
        /// </summary>
        /// <returns>Always true.</returns>
        [Pure]
        public bool Equals(Unit other)
            => true;

        /// <summary>
        /// Returns () reflecting the 0-tuple interpretation.
        /// </summary>
        [Pure]
        public override string ToString()
            => "()";

        /// <summary>
        /// Compares two <see cref="Unit"/> objects through equality operator.
        /// </summary>
        /// <param name="lhs"><see cref="Unit"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Unit"/> right hand side object.</param>
        /// <returns>Always true.</returns>
        /// <remarks><see cref="Unit"/> objects are always equal.</remarks>
        [Pure]
        public static bool operator ==(Unit lhs, Unit rhs)
            => true;

        /// <summary>
        /// Compares two <see cref="Unit"/> objects through inequality operator.
        /// </summary>
        /// <param name="lhs"><see cref="Unit"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Unit"/> right hand side object.</param>
        /// <returns>Always false.</returns>
        /// <remarks><see cref="Unit"/> objects are always equal.</remarks>
        [Pure]
        public static bool operator !=(Unit lhs, Unit rhs)
            => false;

        /// <summary>
        /// Compares two <see cref="Unit"/> objects.
        /// </summary>
        /// <param name="lhs"><see cref="Unit"/> object.</param>
        /// <param name="rhs"><see cref="Unit"/> object.</param>
        /// <returns>Always false.</returns>
        /// <remarks><see cref="Unit"/> objects are always equal.</remarks>
        [Pure]
        public static bool operator >(Unit lhs, Unit rhs)
            => false;

        /// <summary>
        /// Compares two <see cref="Unit"/> objects.
        /// </summary>
        /// <param name="lhs"><see cref="Unit"/> object.</param>
        /// <param name="rhs"><see cref="Unit"/> object.</param>
        /// <returns>Always true.</returns>
        /// <remarks><see cref="Unit"/> objects are always equal.</remarks>
        [Pure]
        public static bool operator >=(Unit lhs, Unit rhs)
            => true;

        /// <summary>
        /// Compares two <see cref="Unit"/> objects.
        /// </summary>
        /// <param name="lhs"><see cref="Unit"/> object.</param>
        /// <param name="rhs"><see cref="Unit"/> object.</param>
        /// <returns>Always false.</returns>
        /// <remarks><see cref="Unit"/> objects are always equal.</remarks>
        [Pure]
        public static bool operator <(Unit lhs, Unit rhs)
            => false;

        /// <summary>
        /// Compares two <see cref="Unit"/> objects.
        /// </summary>
        /// <param name="lhs"><see cref="Unit"/> object.</param>
        /// <param name="rhs"><see cref="Unit"/> object.</param>
        /// <returns>Always true.</returns>
        /// <remarks><see cref="Unit"/> objects are always equal.</remarks>
        [Pure]
        public static bool operator <=(Unit lhs, Unit rhs)
            => true;

        /// <summary>
        /// Compares two <see cref="Unit"/> objects.
        /// </summary>
        /// <param name="other"><see cref="Unit"/> object.</param>
        /// <returns>Always true.</returns>
        /// <remarks><see cref="Unit"/> objects are always equal.</remarks>
        [Pure]
        public int CompareTo(Unit other)
            => _zero;

        /// <summary>
        /// Addition of two <see cref="Unit"/> objects.
        /// </summary>
        /// <param name="lhs"><see cref="Unit"/> object.</param>
        /// <param name="rhs"><see cref="Unit"/> object.</param>
        /// <returns><see cref="Unit"/> object.</returns>
        [Pure]
        public static Unit operator +(Unit lhs, Unit rhs)
            => Default;

        /// <summary>
        /// Subtraction of two <see cref="Unit"/> objects.
        /// </summary>
        /// <param name="lhs"><see cref="Unit"/> object.</param>
        /// <param name="rhs"><see cref="Unit"/> object.</param>
        /// <returns><see cref="Unit"/> object.</returns>
        [Pure]
        public static Unit operator -(Unit lhs, Unit rhs)
            => Default;

        /// <summary>
        /// Implicit conversion <see cref="Unit"/> to <see cref="ValueTuple"/>.
        /// </summary>
        /// <param name="_"><see cref="Unit"/> object.</param>
        /// <returns>Default <see cref="ValueTuple"/> object.</returns>
        [Pure]
        public static implicit operator ValueTuple(Unit _)
            => default;


        /// <summary>
        /// Implicit conversion <see cref="ValueTuple"/> to <see cref="Unit"/>.
        /// </summary>
        /// <param name="_"><see cref="ValueTuple"/> object.</param>
        /// <returns><see cref="Unit"/> object.</returns>
        [Pure]
        public static implicit operator Unit(ValueTuple _)
            => default;
    }
}
