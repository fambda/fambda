using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda.Tests
{
    public class BoolTypeTests
    {
        #region Parse

        [Fact]
        public void ParseShouldReturnOptionBoolNone()
        {
            // Arrange
            var value = "not an logical boolean";
            Option<bool> expected = None;

            // Act
            var result = BoolType.Parse(value);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("True", true)]
        [InlineData("true", true)]
        [InlineData("tRue", true)]
        [InlineData("False", false)]
        [InlineData("false", false)]
        [InlineData("fAlse", false)]
        public void ParseShouldReturnOptionBoolSome(string stringBool, bool expectedBool)
        {
            // Arrange
            var value = stringBool;
            Option<bool> expected = Some(expectedBool);

            // Act
            var result = BoolType.Parse(value);

            // Assert
            result.Should().Be(expected);
        }

        #endregion
    }
}
