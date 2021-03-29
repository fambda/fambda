namespace Fambda
{
    public static partial class F
    {
        public static EitherLeft<L> Left<L>(L left) => new EitherLeft<L>(left);

        public static EitherRight<R> Right<R>(R right) => new EitherRight<R>(right);
    }
}
