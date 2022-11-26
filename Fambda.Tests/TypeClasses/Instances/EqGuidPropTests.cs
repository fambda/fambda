using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqGuidPropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<Guid, Guid, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<Guid, Guid, bool> eqEquals = (lhs, rhs) => default(EqGuid).Equals(lhs, rhs);

            Prop.ForAll<Guid, Guid>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<Guid, int> expected = t => t.GetHashCode();
            Func<Guid, int> eqGetHashCodeFunc = t => default(EqGuid).GetHashCode(t);

            Prop.ForAll<Guid>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
