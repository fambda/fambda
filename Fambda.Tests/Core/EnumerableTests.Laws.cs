using System;
using System.Collections.Generic;
using FluentAssertions;
using FsCheck.Xunit;
using Xunit;

namespace Fambda
{
    public partial class EnumerableTests
    {
        [Fact]
        [Trait("Category", "Laws")]
        public void LawFunctor_Identity_Holds()
        {
            // Arrange
            var value = "value";
            IEnumerable<string> enumerable = new List<string> { value };

            // Act
            var mapped = enumerable.Map(F.Identity);
            var original = enumerable;

            // Assert
            mapped.Should().BeEquivalentTo(original);
        }

        [Property]
        [Trait("Category", "Laws")]
        public void LawFunctor_Composition_Holds(int value)
        {
            // Arrange
            IEnumerable<int> enumerable = new List<int> { value };
            Func<int, int> f = x => x + 1;
            Func<int, int> g = x => x * 2;
            var h = g.Compose(f);

            // Act
            var mapMap = enumerable.Map(f).Map(g);
            var mapCompose = enumerable.Map(h);

            // Assert
            mapMap.Should().BeEquivalentTo(mapCompose);
        }
    }
}
