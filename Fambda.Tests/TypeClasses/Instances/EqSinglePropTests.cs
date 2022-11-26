using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqSinglePropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<Single, Single, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<Single, Single, bool> eqEquals = (lhs, rhs) => default(EqSingle).Equals(lhs, rhs);

            Prop.ForAll<Single, Single>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<Single, int> expected = t => t.GetHashCode();
            Func<Single, int> eqGetHashCodeFunc = t => default(EqSingle).GetHashCode(t);

            Prop.ForAll<Single>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
