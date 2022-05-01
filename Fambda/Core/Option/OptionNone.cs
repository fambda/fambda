using System;
using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Represents an OptionNone type.
    /// </summary>
    public struct OptionNone : IEquatable<OptionNone>
    {
        private static readonly int _zero = 0;

        /// <summary>
        /// Returns <see cref="OptionNone"/>.
        /// </summary>
        internal static readonly OptionNone Default = new OptionNone();

        /// <summary>
        /// Returns zero.
        /// </summary>
        [Pure]
        public override int GetHashCode()
            => _zero;

        /// <summary>
        /// Indicates whether the current <see cref="OptionNone"/> is equal to another <see cref="OptionNone"/>
        /// </summary>
        /// <returns>Always true.</returns>
        [Pure]
        public bool Equals(OptionNone other)
            => true;

        /// <summary>
        /// Determines whether specified object is equal to the current <see cref="OptionNone"/> object.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="OptionNone"/> object.</param>
        /// <returns>true if the specified object is equal to the current <see cref="OptionNone"/> object; otherwise, false.</returns>
        [Pure]
        public override bool Equals(object? obj)
            => obj is OptionNone;

        /// <summary>
        /// Returns a string that represents the current <see cref="OptionNone"/> object.
        /// </summary>
        /// <returns>A string that represents the current <see cref="OptionNone"/> object.</returns>
        public override string ToString() => "None";
    }
}
