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
    }
}
