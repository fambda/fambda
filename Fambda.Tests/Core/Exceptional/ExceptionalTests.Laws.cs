using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class ExceptionalTests
    {
        [Fact]
        [Trait("Category", "Laws")]
        public void LawFunctor_Identity_Holds()
        {
            // Arrange
            var value = "value";
            Exceptional<string> exceptional = value;

            // Act
            var mapped = exceptional.Map(F.Identity);
            var original = exceptional;
            var result = mapped.Equals(original);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("Category", "Laws")]
        public void LawFunctor_Composition_Holds()
        {
            // Arrange
            var value = 1;
            Exceptional<int> exceptional = value;
            Func<int, int> f = x => x + 1;
            Func<int, int> g = x => x * 2;
            var h = g.Compose(f);

            // Act
            var mapMap = exceptional.Map(f).Map(g);
            var mapCompose = exceptional.Map(h);
            var result = mapMap.Equals(mapCompose);

            // Assert
            result.Should().BeTrue();
        }
    }
}
