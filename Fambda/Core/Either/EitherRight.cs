namespace Fambda
{
    public struct EitherRight<R>
    {
        internal R Value { get; }

        internal EitherRight(R value) { Value = value; }

        public override string ToString() => $"Right({Value})";
    }
}
