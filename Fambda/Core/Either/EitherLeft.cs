namespace Fambda
{
    public struct EitherLeft<L>
    {
        internal L Value { get; }

        internal EitherLeft(L value) { Value = value; }

        public override string ToString() => $"Left({Value})";
    }
}
