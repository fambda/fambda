using System;
using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqUInt64PropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<UInt64, UInt64, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<UInt64, UInt64, bool> eqEquals = (lhs, rhs) => default(EqUInt64).Equals(lhs, rhs);

            Prop.ForAll<UInt64, UInt64>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<UInt64, int> expected = t => t.GetHashCode();
            Func<UInt64, int> eqGetHashCodeFunc = t => default(EqUInt64).GetHashCode(t);

            Prop.ForAll<UInt64>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
