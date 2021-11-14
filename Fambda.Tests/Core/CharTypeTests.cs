using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda.Tests
{
    public class CharTypeTests
    {
        #region Parse

        [Fact]
        public void ParseShouldReturnOptionCharSome()
        {
            // Arrange
            var s = "A";
            Option<char> expected = Some('A');

            // Act
            var result = CharType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseShouldReturnOptionCharNone()
        {
            // Arrange
            var s = "not a char";
            Option<char> expected = None;

            // Act
            var result = CharType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        #endregion
    }
}
