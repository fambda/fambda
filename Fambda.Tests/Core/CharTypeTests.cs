using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Fambda.F;

namespace Fambda.Tests
{
    [TestClass]
    public class CharTypeTests
    {
        #region Parse

        [TestMethod]
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

        [TestMethod]
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
