using FsCheck;
using Xunit;

namespace Fambda
{
    public class OptionPropTests
    {
        public OptionPropTests()
        {
            Arb.Register<OptionArbitraries>();
        }

        [Fact]
        public void ToString_ReturnsExpectedRepresentation()
        {
            Prop.ForAll<Option<int>>(option => (option.ToString().StartsWith("Some(") && option.ToString().EndsWith(")")) || option.ToString() == "None")
                .VerboseCheckThrowOnFailure();
        }

        [Fact]
        public void Map_BehavesAsLinq()
        {
            Func<string, string> append = s => s + "_";

            Prop.ForAll<Option<string>>(option => option.Map(append) == (from x in option select append(x)))
                .VerboseCheckThrowOnFailure();
        }

        internal class OptionArbitraries
        {
            public static Arbitrary<Option<T>> Option<T>()
            {
                return Gen.Sized(OptionGenerator.Generator<T>).ToArbitrary();
            }
        }

        internal static class OptionGenerator
        {
            public static Gen<Option<T>> Generator<T>(int depth)
            {
                return Gen.OneOf(new Gen<Option<T>>[] {
                    from value in Arb.Generate<T>()
                    select value != null ? F.Some(value) : F.None
                });
            }
        }
    }
}
