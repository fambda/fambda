namespace Fambda
{
    public struct EitherLeftHolder<L>
    {
        internal L Value { get; }

        internal EitherLeftHolder(L value) { Value = value; }

        public override string ToString() => $"Left({Value})";
    }
}
