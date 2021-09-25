namespace Fambda.Tests.Helpers
{
    internal static class EqResultsExtensions
    {
        internal static EqResultsAssertions Should(this EqResults instance)
        {
            return new EqResultsAssertions(instance);
        }
    }
}
