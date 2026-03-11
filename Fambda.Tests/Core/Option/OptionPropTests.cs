using FsCheck;
using FsCheck.Fluent;
using Xunit;
using static Fambda.EqDateOnlyPropTests;

namespace Fambda;

public class OptionPropTests
{
    [Fact]
    public void ToString_ReturnsExpectedRepresentation()
    {
        Prop.ForAll<Option<int>>(option => (option.ToString().StartsWith("Some(") && option.ToString().EndsWith(")")) || option.ToString() == "None")
            .Check(Config.VerboseThrowOnFailure.WithArbitrary(new[] { typeof(OptionArbitraries) }));
    }

    [Fact]
    public void Map_BehavesAsLinq()
    {
        Func<string, string> append = s => s + "_";

        Prop.ForAll<Option<string>>(option => option.Map(append) == (from x in option select append(x)))
            .Check(Config.VerboseThrowOnFailure.WithArbitrary(new[] { typeof(OptionArbitraries) }));
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
                from value in ArbMap.Default.GeneratorFor<T>()
                select value != null ? F.Some(value) : F.None
            });
        }
    }
}
