using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqBooleanPropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<Boolean, Boolean, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<Boolean, Boolean, bool> eqEquals = (lhs, rhs) => default(EqBoolean).Equals(lhs, rhs);

            Prop.ForAll<Boolean, Boolean>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<Boolean, int> expected = t => t.GetHashCode();
            Func<Boolean, int> eqGetHashCodeFunc = t => default(EqBoolean).GetHashCode(t);

            Prop.ForAll<Boolean>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
