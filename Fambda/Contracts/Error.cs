namespace Fambda.Contracts
{
    internal static class Error
    {
        internal static GuardExceptionMustNotBeNullException GuardExceptionMustNotBeNull()
        {
            return new GuardExceptionMustNotBeNullException();
        }

        internal static OptionSomeValueMustNotBeNullException OptionSomeValueMustNotBeNull()
        {
            return new OptionSomeValueMustNotBeNullException();
        }

        internal static OptionValueMustNotBeNullException OptionValueMustNotBeNull()
        {
            return new OptionValueMustNotBeNullException();
        }

        internal static ExceptionalExceptionMustNotBeNullException ExceptionalExceptionMustNotBeNull()
        {
            return new ExceptionalExceptionMustNotBeNullException();
        }
    }
}
