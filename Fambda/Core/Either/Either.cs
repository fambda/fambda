using System;

namespace Fambda
{
    public struct Either<L, R>
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

        public static implicit operator Either<L, R>(EitherLeft<L> left)
            => new Either<L, R>(left.Value);

        public static implicit operator Either<L, R>(EitherRight<R> right)
            => new Either<L, R>(right.Value);

        public Res Match<Res>(Func<L, Res> Left, Func<R, Res> Right)
           => _isLeft ? Left(this.Left) : Right(this.Right);

        public Unit Match(Action<L> Left, Action<R> Right)
           => Match(Left.ToFunc(), Right.ToFunc());


        public override string ToString() => Match(l => $"Left({l})", r => $"Right({r})");
    }
}
