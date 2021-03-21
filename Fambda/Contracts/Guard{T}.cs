namespace Fambda.Contracts
{
    public sealed class Guard<T>
    {
        public T Value { get; }

        public GuardException GuardException { get; }

        public Guard(T value, GuardException guardException)
        {
            if (guardException == null)
            {
                throw Error.GuardExceptionMustNotBeNull();
            }

            Value = value;
            GuardException = guardException;
        }
    }
}
