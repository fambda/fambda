namespace Fambda.Helpers
{
    internal static class EqResultsExtensions
    {
        internal static EqResultsAssertions Should(this EqResults instance)
        {
            return new EqResultsAssertions(instance);
        }
    }
}
