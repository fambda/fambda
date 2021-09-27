using System;

namespace Fambda
{
    /// <summary>
    /// Represents an Either 'L', 'R' type.
    /// </summary>
    /// <typeparam name="L">Left</typeparam>
    /// <typeparam name="R">Right</typeparam>
    public struct Either<L, R> : IEquatable<Either<L, R>>
    {
        internal L Left { get; }
        internal R Right { get; }

        private readonly bool _isLeft;

        internal Either(L left)
        {
            Left = left;
            Right = default(R);

            _isLeft = true;
        }

        internal Either(R right)
        {
            Right = right;
            Left = default(L);

            _isLeft = false;
        }

        /// <summary>
        /// Implicit conversion operator from <see cref="EitherLeft{L}"/> to <see cref="Either{L,R}"/>.
        /// </summary>
        /// <param name="left"><see cref="EitherLeft{L}"/> object.</param>
        public static implicit operator Either<L, R>(EitherLeft<L> left)
            => new Either<L, R>(left.Value);

        /// <summary>
        /// Implicit conversion operator from <see cref="EitherRight{R}"/> to <see cref="Either{L,R}"/>.
        /// </summary>
        /// <param name="right"><see cref="EitherRight{R}"/> object.</param>
        public static implicit operator Either<L, R>(EitherRight<R> right)
            => new Either<L, R>(right.Value);

        /// <summary>
        /// Match the Left and Right states of the <see cref="Either{L,R}"/> and return Res.
        /// </summary>
        /// <typeparam name="Res">Return type.</typeparam>
        /// <param name="Left">Left match operation.</param>
        /// <param name="Right">Right match operation.</param>
        public Res Match<Res>(Func<L, Res> Left, Func<R, Res> Right)
           => _isLeft ? Left(this.Left) : Right(this.Right);

        /// <summary>
        /// Match the Left and Right states of the <see cref="Either{L,R}"/> and return <see cref="Unit"/>.
        /// </summary>
        /// <param name="Left">Left match action.</param>
        /// <param name="Right">Right match action.</param>
        public Unit Match(Action<L> Left, Action<R> Right)
           => Match(Left.ToFunc(), Right.ToFunc());

        /// <summary>
        /// Calculates the hash-code based on whether <see cref="Either{L,R}"/> is in Some or None.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Either{L,R}"/> object.</returns>
        public override int GetHashCode()
            => ToString().GetHashCode();

        /// <summary>
        /// Indicates whether the current <see cref="Either{L,R}"/> is equal to another <see cref="Either{L,R}"/>
        /// </summary>
        /// <param name="other">An <see cref="Either{L,R}"/> to compare with this <see cref="Either{L,R}"/>.</param>
        /// <returns>true if the current <see cref="Either{L,R}"/> object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Either<L, R> other)
        {
            bool result;

            if (_isLeft)
            {
                if (object.Equals(Left, null) && object.Equals(other.Left, null))
                {
                    result = true;
                }
                else if (object.Equals(Left, null) || object.Equals(other.Left, null))
                {
                    result = false;
                }
                else
                {
                    result = object.Equals(Left, other.Left);
                }
            }
            else
            {
                if (object.Equals(Right, null) && object.Equals(other.Right, null))
                {
                    result = true;
                }
                else if (object.Equals(Right, null) || object.Equals(other.Right, null))
                {
                    result = false;
                }
                else
                {
                    result = object.Equals(Right, other.Right);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="Either{L,R}"/> object.
        /// </summary>
        /// <returns>A string that represents the current <see cref="Either{L,R}"/> object.</returns>
        public override string ToString() => Match(l => $"Left({l})", r => $"Right({r})");
    }
}
