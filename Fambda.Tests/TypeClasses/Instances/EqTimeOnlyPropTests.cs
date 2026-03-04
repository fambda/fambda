using FsCheck;
using FsCheck.Fluent;
using FsCheck.Xunit;
using Xunit;
using static Fambda.EqDateOnlyPropTests;

namespace Fambda
{
    public class EqTimeOnlyPropTests
    {
        [Fact]
        public void Equals_ReturnsExpectedResult()
        {
            Func<TimeOnly, TimeOnly, bool> expected = (lhs, rhs) => lhs.Equals(rhs);
            Func<TimeOnly, TimeOnly, bool> eqEquals = (lhs, rhs) => default(EqTimeOnly).Equals(lhs, rhs);

            Prop.ForAll<TimeOnly, TimeOnly>((lhs, rhs) => eqEquals(lhs, rhs) == expected(lhs, rhs))
                .Check(Config.VerboseThrowOnFailure.WithArbitrary(new[] { typeof(TimeOnlyArbitraries) }));
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<TimeOnly, int> expected = t => t.GetHashCode();
            Func<TimeOnly, int> eqGetHashCodeFunc = t => default(EqTimeOnly).GetHashCode(t);

            Prop.ForAll<TimeOnly>(t => eqGetHashCodeFunc(t) == expected(t))
                .Check(Config.VerboseThrowOnFailure.WithArbitrary(new[] { typeof(TimeOnlyArbitraries) }));
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
