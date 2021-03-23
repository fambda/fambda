using Fambda.Contracts;

namespace Fambda
{
    public struct Option<T>
    {
        private readonly T _value;
        private readonly bool _isSome;

        private Option(T value)
        {
            Guard.On(value, Error.OptionValueMustNotBeNull()).AgainstNull();

            _value = value;
            _isSome = true;
        }

        public static implicit operator Option<T>(OptionSome<T> some)
            => new Option<T>(some.Value);

        public static implicit operator Option<T>(OptionNone _)
            => new Option<T>();

        public static implicit operator Option<T>(T value)
        {
            if (value != null)
            {
                return new OptionSome<T>(value);
            }
            else
            {
                return OptionNone.Default;
            }
        }

        public override string ToString()
            => _isSome ? $"Some({_value})" : "None";

        public override int GetHashCode()
            => ToString().GetHashCode();
    }
}
