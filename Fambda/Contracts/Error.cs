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

        internal static OptionMatchReturnMustNotBeNullException OptionMatchReturnMustNotBeNull()
        {
            return new OptionMatchReturnMustNotBeNullException();
        }

        internal static ExceptionalExceptionMustNotBeNullException ExceptionalExceptionMustNotBeNull()
        {
            return new ExceptionalExceptionMustNotBeNullException();
        }

        internal static EnumerationKeyMustNotBeNullException EnumerationKeyMustNotBeNull()
        {
            return new EnumerationKeyMustNotBeNullException();
        }

        internal static EnumerationKeyMustNotBeEmptyException EnumerationKeyMustNotBeEmpty()
        {
            return new EnumerationKeyMustNotBeEmptyException();
        }

        internal static EnumerationKeyMustNotBeWhiteSpaceException EnumerationKeyMustNotBeWhiteSpace()
        {
            return new EnumerationKeyMustNotBeWhiteSpaceException();
        }

        internal static EnumerationKeyMustNotContainLeadingSpaceException EnumerationKeyMustNotContainLeadingSpace()
        {
            return new EnumerationKeyMustNotContainLeadingSpaceException();
        }

        internal static EnumerationKeyMustNotContainTrailingSpaceException EnumerationKeyMustNotContainTrailingSpace()
        {
            return new EnumerationKeyMustNotContainTrailingSpaceException();
        }
    }
}
