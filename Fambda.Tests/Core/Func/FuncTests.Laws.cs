using System;
using FluentAssertions;
using Xunit;

namespace Fambda
{
    public partial class FuncTests
    {
        [Fact]
        [Trait("Category", "Laws")]
        public void LawFunctor_Identity_Holds()
        {
            // Arrange
            Func<int, int> func = x => x + 1;

            // Act
            var mapped = func.Map(F.Identity)(5);
            var original = func(5);
            var result = mapped.Equals(original);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("Category", "Laws")]
        public void LawFunctor_Composition_Holds()
        {
            // Arrange
            Func<int, string> toString = i => i.ToString();
            Func<string, string> f = s => s.Substring(0, 2);
            Func<string, string> g = s => s.Substring(0, 1);
            var expected = toString.Map(x => g(f(x)));

            // Act
            var mapped = toString.Map(f).Map(g);
            var result = mapped(123).Equals(expected(123));

            // Assert
            result.Should().BeTrue();
        }
    }
}
