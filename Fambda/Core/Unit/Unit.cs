using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    public struct Unit : IEquatable<Unit>, IComparable<Unit> 
    {
        public static readonly Unit Default = new Unit();
        private static readonly int _zero = 0;

        [Pure]
        public override int GetHashCode()
            => _zero;

        [Pure]
        public override bool Equals(object obj)
            => obj is Unit;

        [Pure]
        public bool Equals(Unit other)
            => true;

        [Pure]
        public override string ToString()
            => "()";

        [Pure]
        public static bool operator ==(Unit lhs, Unit rhs)
            => true;

        [Pure]
        public static bool operator !=(Unit lhs, Unit rhs)
            => false;

        [Pure]
        public static bool operator >(Unit lhs, Unit rhs)
            => false;

        [Pure]
        public static bool operator >=(Unit lhs, Unit rhs)
            => true;

        [Pure]
        public static bool operator <(Unit lhs, Unit rhs)
            => false;

        [Pure]
        public static bool operator <=(Unit lhs, Unit rhs)
            => true;

        [Pure]
        public int CompareTo(Unit other)
            => _zero;

        [Pure]
        public static Unit operator +(Unit lhs, Unit rhs)
            => Default;

        [Pure]
        public static Unit operator -(Unit lhs, Unit rhs)
            => Default;

        [Pure]
        public static implicit operator ValueTuple(Unit _)
            => default;

        [Pure]
        public static implicit operator Unit(ValueTuple _)
            => default;
    }
}
