namespace Fambda
{
    public struct EitherRightHolder<R>
    {
        internal R Value { get; }
        internal EitherRightHolder(R value) { Value = value; }

        public override string ToString() => $"Right({Value})";
    }
}
