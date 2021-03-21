using Fambda.Contracts;

namespace Fambda
{
    public struct OptionSome<T>
    {
        internal T Value { get; }

        internal OptionSome(T value)
        {
            Guard.On(value, Error.OptionSomeValueMustNotBeNull()).AgainstNull();

            Value = value;
        }
    }
}
