namespace Fambda.Contracts
{
    internal static class Error
    {
        internal static EachParamMustNotBeNullException EachParamMustNotBeNull()
        {
            return new EachParamMustNotBeNullException();
        }
    }
}
