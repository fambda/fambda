using System;
using FsCheck;
using Xunit;

namespace Fambda
{
    public class EqDoublePropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<Double, Double, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<Double, Double, bool> eqEquals = (lhs, rhs) => default(EqDouble).Equals(lhs, rhs);

            Prop.ForAll<Double, Double>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<Double, int> expected = t => t.GetHashCode();
            Func<Double, int> eqGetHashCodeFunc = t => default(EqDouble).GetHashCode(t);

            Prop.ForAll<Double>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }
    }
}
