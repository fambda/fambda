using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace Fambda
{
    public class EqTimeOnlyPropTests
    {
        public EqTimeOnlyPropTests()
        {
            Arb.Register<TimeOnlyArbitraries>();
        }

        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<TimeOnly, TimeOnly, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<TimeOnly, TimeOnly, bool> eqEquals = (lhs, rhs) => default(EqTimeOnly).Equals(lhs, rhs);

            Prop.ForAll<TimeOnly, TimeOnly>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs)).VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<TimeOnly, int> expected = t => t.GetHashCode();
            Func<TimeOnly, int> eqGetHashCodeFunc = t => default(EqTimeOnly).GetHashCode(t);

            Prop.ForAll<TimeOnly>(t => eqGetHashCodeFunc(t) == expected(t)).VerboseCheckThrowOnFailure();
        }

        public class TimeOnlyArbitraries
        {
            public static Arbitrary<TimeOnly> DateOnly()
                => new ArbitraryTimeOnly();

            public class ArbitraryTimeOnly : Arbitrary<TimeOnly>
            {
                public override Gen<TimeOnly> Generator
                    => from hour in Gen.Choose(0, 23)
                       from minute in Gen.Choose(0, 59)
                       from second in Gen.Choose(0, 59)

                       select new TimeOnly(hour, minute, second);
            }
        }
    }
}
