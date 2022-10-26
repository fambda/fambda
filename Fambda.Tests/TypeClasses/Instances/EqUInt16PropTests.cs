using System;
using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqUInt16PropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<UInt16, UInt16, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<UInt16, UInt16, bool> eqEquals = (lhs, rhs) => default(EqUInt16).Equals(lhs, rhs);

            Prop.ForAll<UInt16, UInt16>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<UInt16, int> expected = t => t.GetHashCode();
            Func<UInt16, int> eqGetHashCodeFunc = t => default(EqUInt16).GetHashCode(t);

            Prop.ForAll<UInt16>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
