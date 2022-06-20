namespace Fambda.Contracts
{
    /// <summary>
    /// Construction class for errors.
    /// </summary>
    public static class Error
    {
        /// <summary>
        /// Returns an instance of <see cref="EachParamMustNotBeNullException"/>.
        /// </summary>
        public static EachParamMustNotBeNullException EachParamMustNotBeNull()
        {
            return new EachParamMustNotBeNullException();
        }
    }
}
