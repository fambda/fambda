using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Option type equality.
    /// </summary>
    public struct EqOption<T> : Eq<Option<T>>
    {
        /// <summary>
        /// Determines whether two <see cref="Option{T}"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="Option{T}"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Option{T}"/> right hand side object.</param>
        /// <returns>true if lhs is equal to the rhs; otherwise, false.</returns>
        [Pure]
        public bool Equals(Option<T> lhs, Option<T> rhs)
        {
            if (lhs.IsNull()) { return rhs.IsNull(); }
            if (rhs.IsNull()) { return false; }

            var result = lhs.IsNone && rhs.IsNone
                            ? true
                            : lhs.IsNone || rhs.IsNone
                                ? false
                                : lhs.Match(
                                        Some: lshValue =>
                                            rhs.Match(
                                                Some: rhsValue => object.Equals(lshValue, rhsValue),
                                                None: () => false),
                                        None: () => false
                                     );
            return result;
        }

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableOption{T}"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Option{T}"/> object.</returns>
        [Pure]
        public int GetHashCode(Option<T> option)
            => default(HashableOption<T>).GetHashCode(option);
    }
}
