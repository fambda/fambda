using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public class CharTypeTests
    {
        #region Parse

        [Fact]
        public void Parse_ReturnsOptionCharNone()
        {
            // Arrange
            const string s = "not a char";
            Option<char> expected = None;

            // Act
            var result = CharType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_ReturnsOptionCharSome()
        {
            // Arrange
            const string s = "A";
            Option<char> expected = Some('A');

            // Act
            var result = CharType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        #endregion
    }
}
