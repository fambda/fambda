using System;
using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqStringPropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<String, String, bool> expected = (lhs, rhs) => String.Equals(lhs, rhs);
            Func<String, String, bool> eqEquals = (lhs, rhs) => default(EqString).Equals(lhs, rhs);

            Prop.ForAll<String, String>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<String, int> expected = t => t is null ? 0 : t.GetHashCode();
            Func<String, int> eqGetHashCodeFunc = t => default(EqString).GetHashCode(t);

            Prop.ForAll<String>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
