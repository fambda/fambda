using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace Fambda
{
    public class EqDateOnlyPropTests
    {
        public EqDateOnlyPropTests()
        {
            Arb.Register<DateOnlyArbitraries>();
        }

        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<DateOnly, DateOnly, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<DateOnly, DateOnly, bool> eqEquals = (lhs, rhs) => default(EqDateOnly).Equals(lhs, rhs);

            Prop.ForAll<DateOnly, DateOnly>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<DateOnly, int> expected = t => t.GetHashCode();
            Func<DateOnly, int> eqGetHashCodeFunc = t => default(EqDateOnly).GetHashCode(t);

            Prop.ForAll<DateOnly>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }

        public class DateOnlyArbitraries
        {
            public static Arbitrary<DateOnly> DateOnly()
                => new ArbitraryDateOnly();

            public class ArbitraryDateOnly : Arbitrary<DateOnly>
            {
                public override Gen<DateOnly> Generator
                    => from year in Gen.Choose(1950, 2022)
                       from month in Gen.Choose(1, 12)
                       from day in Gen.Choose(1, 20)

                       select new DateOnly(year, month, day);
            }
        }
    }
}
