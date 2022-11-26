using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqDecimalPropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<Decimal, Decimal, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<Decimal, Decimal, bool> eqEquals = (lhs, rhs) => default(EqDecimal).Equals(lhs, rhs);

            Prop.ForAll<Decimal, Decimal>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<Decimal, int> expected = t => t.GetHashCode();
            Func<Decimal, int> eqGetHashCodeFunc = t => default(EqDecimal).GetHashCode(t);

            Prop.ForAll<Decimal>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
