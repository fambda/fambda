using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqInt64PropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<Int64, Int64, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<Int64, Int64, bool> eqEquals = (lhs, rhs) => default(EqInt64).Equals(lhs, rhs);

            Prop.ForAll<Int64, Int64>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<Int64, int> expected = t => t.GetHashCode();
            Func<Int64, int> eqGetHashCodeFunc = t => default(EqInt64).GetHashCode(t);

            Prop.ForAll<Int64>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
