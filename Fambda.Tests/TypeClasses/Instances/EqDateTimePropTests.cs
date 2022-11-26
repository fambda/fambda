using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqDateTimePropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<DateTime, DateTime, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<DateTime, DateTime, bool> eqEquals = (lhs, rhs) => default(EqDateTime).Equals(lhs, rhs);

            Prop.ForAll<DateTime, DateTime>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<DateTime, int> expected = t => t.GetHashCode();
            Func<DateTime, int> eqGetHashCodeFunc = t => default(EqDateTime).GetHashCode(t);

            Prop.ForAll<DateTime>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
