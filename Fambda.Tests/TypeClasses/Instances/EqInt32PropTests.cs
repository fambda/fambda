using System;
using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqInt32PropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<Int32, Int32, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<Int32, Int32, bool> eqEquals = (lhs, rhs) => default(EqInt32).Equals(lhs, rhs);

            Prop.ForAll<Int32, Int32>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<Int32, int> expected = t => t.GetHashCode();
            Func<Int32, int> eqGetHashCodeFunc = t => default(EqInt32).GetHashCode(t);

            Prop.ForAll<Int32>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
