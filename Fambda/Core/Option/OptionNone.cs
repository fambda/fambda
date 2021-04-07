using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    public struct OptionNone : IEquatable<OptionNone>
    {
        internal static readonly OptionNone Default = new OptionNone();

        private static readonly int _zero = 0;

        [Pure]
        public override bool Equals(object obj)
            => obj is OptionNone;

        [Pure]
        public bool Equals(OptionNone other)
            => true;

        [Pure]
        public override int GetHashCode()
            => _zero;
    }
}
