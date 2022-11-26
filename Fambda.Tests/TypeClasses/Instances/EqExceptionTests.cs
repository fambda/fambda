using System;
using System.Collections.Generic;
using System.Linq;
using Fambda.DataTypes;
using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace Fambda
{
    public class EqExceptionTests
    {
        public EqExceptionTests()
        {
            Arb.Register<ExceptionArbitraries>();
        }

        [Theory]
        [MemberData(nameof(GetParams))]
        public void Equals_ReturnsExpectedResult(Exception lhs, Exception rhs, bool expected)
        {
            var result = default(EqException).Equals(lhs, rhs);

            result.Should().Be(expected);
        }

        [Fact]
        public void GetHashCode_ReturnsExpectedResult()
        {
            Func<Exception, int> expected = t => (t.GetType().Name, t.HResult, t.Message).GetHashCode();
            Func<Exception, int> eqGetHashCodeFunc = t => default(EqException).GetHashCode(t);

            Prop.ForAll<NonNull<Exception>>(t => eqGetHashCodeFunc(t.Item) == expected(t.Item)).VerboseCheckThrowOnFailure();
        }

        public static IEnumerable<object[]> GetParams()
        {
            yield return new object[] { new Exception(), new Exception(), true };
            yield return new object[] { new Exception(), new Exception("exc"), false };
            yield return new object[] { new SomeException(), new AnotherException(), false };
            yield return new object[] { new Exception(), new AnotherException(), false };
        }


        public class ExceptionArbitraries
        {
            public static Arbitrary<Exception> Exception()
                => new ArbitraryException();

            public static Exception? ExceptionChooser(int index)
                => new List<Exception?>() { new Exception(), new Exception(), new Exception("exc"), new SomeException(), new AnotherException() }.ElementAt(index);

            public class ArbitraryException : Arbitrary<Exception>
            {
                public override Gen<Exception> Generator
                    => from index in Gen.Choose(0, 4)

                       select ExceptionChooser(index);
            }
        }
    }
}
