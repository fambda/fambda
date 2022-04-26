using System;
using FluentAssertions;
using Xunit;
using static Fambda.F;

namespace Fambda
{
    public partial class OptionTests
    {
        [Fact]
        [Trait("Category", "Laws")]
        public void LawFunctor_Identity_Holds()
        {
            // Arrange
            var value = "value";
            Option<string> option = Some(value);

            // Act
            var mapped = option.Map(F.Identity);
            var original = option;
            var result = mapped.Equals(original);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("Category", "Laws")]
        public void LawFunctor_Composition_Holds()
        {
            // Arrange
            Option<int> option = Some(1);
            Func<int, int> f = x => x + 1;
            Func<int, int> g = x => x * 2;
            var h = g.Compose(f);

            // Act
            var mapMap = option.Map(f).Map(g);
            var mapCompose = option.Map(h);
            var result = mapMap.Equals(mapCompose);

            // Assert
            result.Should().BeTrue();
        }
    }
}
