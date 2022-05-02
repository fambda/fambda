using FluentAssertions;
using Xunit;
using static Fambda.F;

namespace Fambda
{
    public class OptionFTests
    {
        [Fact]
        public void None_Succeeds()
        {
            // Arrange
            var none = None;

            // Act
            Option<string> option = none;

            // Assert
            option.ToString().Should().Be("None");
        }

        [Fact]
        public void Some_NotNull_Succeeds()
        {
            // Arrange
            var value = "value";

            // Act
            Option<string> option = Some(value);

            // Assert
            option.ToString().Should().Be("Some(value)");
        }
    }
}
