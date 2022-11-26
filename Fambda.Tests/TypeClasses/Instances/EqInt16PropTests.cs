using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqInt16PropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<Int16, Int16, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<Int16, Int16, bool> eqEquals = (lhs, rhs) => default(EqInt16).Equals(lhs, rhs);

            Prop.ForAll<Int16, Int16>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<Int16, int> expected = t => t.GetHashCode();
            Func<Int16, int> eqGetHashCodeFunc = t => default(EqInt16).GetHashCode(t);

            Prop.ForAll<Int16>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
