using System;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public class GuidTypeTests
    {
        #region Parse

        [Fact]
        public void Parse_ReturnsOptionGuidNone()
        {
            // Arrange
            var input = "not a Guid";
            Option<Guid> expected = None;

            // Act
            var result = GuidType.Parse(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WhenInputFormat32Digits_ReturnsOptionGuidSome()
        {
            // Arrange
            var originalGuid = Guid.NewGuid();
            var input = originalGuid.ToString("N");
            Option<Guid> expected = Some(originalGuid);

            // Act
            var result = GuidType.Parse(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WhenInputFormat32DigitsSeparatedByHyphens_ReturnsOptionGuidSome()
        {
            // Arrange
            var originalGuid = Guid.NewGuid();
            var input = originalGuid.ToString("D");
            Option<Guid> expected = Some(originalGuid);

            // Act
            var result = GuidType.Parse(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WhenInputFormat32DigitsSeparatedByHyphensEnclosedInBraces_ReturnsOptionGuidSome()
        {
            // Arrange
            var originalGuid = Guid.NewGuid();
            var input = originalGuid.ToString("B");
            Option<Guid> expected = Some(originalGuid);

            // Act
            var result = GuidType.Parse(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WhenInputFormat32DigitsSeparatedByHyphensEnclosedInParentheses_ReturnsOptionGuidSome()
        {
            // Arrange
            var originalGuid = Guid.NewGuid();
            var input = originalGuid.ToString("P");
            Option<Guid> expected = Some(originalGuid);

            // Act
            var result = GuidType.Parse(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Parse_WhenInputFormat4HexadecimalsEnclosedInBracesWithTheFourthSubsetOf8HexadecimalsEnclosedInBraces_ReturnsOptionGuidSome()
        {
            // Arrange
            var originalGuid = Guid.NewGuid();
            var input = originalGuid.ToString("X");
            Option<Guid> expected = Some(originalGuid);

            // Act
            var result = GuidType.Parse(input);

            // Assert
            result.Should().Be(expected);
        }

        #endregion
    }
}
