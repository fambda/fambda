using System;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda.Tests
{
    public class GuidTypeTests
    {
        #region Parse

        [Fact]
        public void ParseShouldReturnOptionGuidSomeWhenInputFormat32Digits()
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
        public void ParseShouldReturnOptionGuidSomeWhenInputFormat32DigitsSeparatedByHyphens()
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
        public void ParseShouldReturnOptionGuidSomeWhenInputFormat32DigitsSeparatedByHyphensEnclosedInBraces()
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
        public void ParseShouldReturnOptionGuidSomeWhenInputFormat32DigitsSeparatedByHyphensEnclosedInParentheses()
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
        public void ParseShouldReturnOptionGuidSomeWhenInputFormat4HexadecimalsEnclosedInBracesWithTheFourthSubsetOf8HexadecimalsEnclosedInBraces()
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

        [Fact]
        public void ParseShouldReturnOptionGuidNone()
        {
            // Arrange
            var input = "not a Guid";
            Option<Guid> expected = None;

            // Act
            var result = GuidType.Parse(input);

            // Assert
            result.Should().Be(expected);
        }

        #endregion
    }
}
