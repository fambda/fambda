namespace Fambda.Contracts
{
    internal static class Error
    {
        internal static EachParamMustNotBeNullException EachParamMustNotBeNull()
        {
            return new EachParamMustNotBeNullException();
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
