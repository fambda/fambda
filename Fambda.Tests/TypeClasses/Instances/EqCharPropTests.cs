using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqCharPropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<Char, Char, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<Char, Char, bool> eqEquals = (lhs, rhs) => default(EqChar).Equals(lhs, rhs);

            Prop.ForAll<Char, Char>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<Char, int> expected = t => t.GetHashCode();
            Func<Char, int> eqGetHashCodeFunc = t => default(EqChar).GetHashCode(t);

            Prop.ForAll<Char>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
