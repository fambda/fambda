namespace Fambda.Contracts
{
    internal static class Error
    {
        internal static GuardExceptionMustNotBeNullException GuardExceptionMustNotBeNull()
        {
            return new GuardExceptionMustNotBeNullException();
        }

        internal static EachParamMustNotBeNullException EachParamMustNotBeNull()
        {
            return new EachParamMustNotBeNullException();
        }

        internal static OptionSomeValueMustNotBeNullException OptionSomeValueMustNotBeNull()
        {
            return new OptionSomeValueMustNotBeNullException();
        }

        internal static OptionValueMustNotBeNullException OptionValueMustNotBeNull()
        {
            return new OptionValueMustNotBeNullException();
        }

        internal static OptionMatchReturnMustNotBeNullException OptionMatchReturnMustNotBeNull()
        {
            return new OptionMatchReturnMustNotBeNullException();
        }

        internal static ExceptionalExceptionMustNotBeNullException ExceptionalExceptionMustNotBeNull()
        {
            return new ExceptionalExceptionMustNotBeNullException();
        }

        internal static ExceptionalValueMustNotBeNullException ExceptionalValueMustNotBeNull()
        {
            return new ExceptionalValueMustNotBeNullException();
        }
    }
}
