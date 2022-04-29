using System;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class EitherTests
    {
        [Fact]
        [Trait("Category", "Laws")]
        public void LawFunctor_Identity_Holds()
        {
            // Arrange
            var value = 1;
            Either<string, int> either = new EitherRight<int>(value);

            // Act
            var mapped = either.Map(F.Identity);
            var original = either;
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
            Either<string, int> either = new EitherRight<int>(value);
            Func<int, int> f = x => x + 1;
            Func<int, int> g = x => x * 2;
            var h = g.Compose(f);

            // Act
            var mapMap = either.Map(f).Map(g);
            var mapCompose = either.Map(h);
            var result = mapMap.Equals(mapCompose);

            // Assert
            result.Should().BeTrue();
        }
    }
}
