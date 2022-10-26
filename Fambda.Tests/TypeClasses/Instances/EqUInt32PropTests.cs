using System;
using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqUInt32PropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<UInt32, UInt32, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<UInt32, UInt32, bool> eqEquals = (lhs, rhs) => default(EqUInt32).Equals(lhs, rhs);

            Prop.ForAll<UInt32, UInt32>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<UInt32, int> expected = t => t.GetHashCode();
            Func<UInt32, int> eqGetHashCodeFunc = t => default(EqUInt32).GetHashCode(t);

            Prop.ForAll<UInt32>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
