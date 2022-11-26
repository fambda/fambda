using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class TryTests
    {
        [Fact]
        [Trait("Category", "Laws")]
        public void LawFunctor_Identity_Holds()
        {
            // Arrange
            var value = "value";
            Exceptional<string> exceptional() => value;
            Try<string> @try = exceptional;

            // Act
            var mapped = @try.Map(F.Identity)();
            var original = @try();
            var result = mapped.Equals(original);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("Category", "Laws")]
        public void LawFunctor_Composition_Holds()
        {
            // Arrange
            const int value = 1;
            Exceptional<int> exceptional() => value;
            Try<int> @try = exceptional;
            Func<int, int> f = x => x + 1;
            Func<int, int> g = x => x * 2;
            var h = g.Compose(f);

            // Act
            var mapMap = @try.Map(f).Map(g)();
            var mapCompose = @try.Map(h)();
            var result = mapMap.Equals(mapCompose);

            // Assert
            result.Should().BeTrue();
        }
    }
}
