using System.Diagnostics.Contracts;

namespace Fambda
{
    /// <summary>
    /// Either type equality.
    /// </summary>
    public struct EqEither<L, R> : Eq<Either<L, R>>
    {
        /// <summary>
        /// Determines whether two <see cref="Either{L,R}"/> objects are equal.
        /// </summary>
        /// <param name="lhs"><see cref="Either{L,R}"/> left hand side object.</param>
        /// <param name="rhs"><see cref="Either{L,R}"/> right hand side object.</param>
        /// <returns>true if lhs is equal to the rhs; otherwise, false.</returns>
        [Pure]
        public bool Equals(Either<L, R> lhs, Either<L, R> rhs)
        {
            bool result;
            if (lhs.IsLeft)
            {
                if (object.Equals(lhs.Left, null) && object.Equals(rhs.Left, null))
                {
                    result = true;
                }
                else if (object.Equals(lhs.Left, null) || object.Equals(rhs.Left, null))
                {
                    result = false;
                }
                else
                {
                    result = object.Equals(lhs.Left, rhs.Left);
                }
            }
            else
            {
                if (object.Equals(lhs.Right, null) && object.Equals(rhs.Right, null))
                {
                    result = true;
                }
                else if (object.Equals(lhs.Right, null) || object.Equals(rhs.Right, null))
                {
                    result = false;
                }
                else
                {
                    result = object.Equals(lhs.Right, rhs.Right);
                }
            }

            return result;
        }

        /// <summary>
        /// Calculates the hash-code based on <see cref="HashableEither{L,R}"/>.
        /// </summary>
        /// <returns>A hash code for the current <see cref="HashableEither{L,R}"/> object.</returns>
        [Pure]
        public int GetHashCode(Either<L, R> either)
            => default(HashableEither<L, R>).GetHashCode(either);
    }
}
