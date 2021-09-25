namespace Fambda.Tests.Helpers
{
    internal static class EqResultExtensions
    {
        internal static EqResultAssertions Should(this EqResult instance)
        {
            return new EqResultAssertions(instance);
        }
    }
}
