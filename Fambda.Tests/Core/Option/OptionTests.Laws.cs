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
    }
}
