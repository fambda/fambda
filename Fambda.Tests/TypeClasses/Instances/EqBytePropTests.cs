using System;
using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqBytePropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<Byte, Byte, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<Byte, Byte, bool> eqEquals = (lhs, rhs) => default(EqDouble).Equals(lhs, rhs);

            Prop.ForAll<Byte, Byte>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<Byte, int> expected = t => t.GetHashCode();
            Func<Byte, int> eqGetHashCodeFunc = t => default(EqByte).GetHashCode(t);

            Prop.ForAll<Byte>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
