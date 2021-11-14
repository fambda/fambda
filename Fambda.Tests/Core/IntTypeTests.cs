using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda.Tests
{
    public class IntTypeTests
    {
        #region Parse

        [Fact]
        public void ParseShouldReturnOptionIntSome()
        {
            // Arrange
            var s = "1";
            Option<int> expected = Some(1);

            // Act
            var result = IntType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseShouldReturnOptionIntNone()
        {
            // Arrange
            var s = "not an int";
            Option<int> expected = None;

            // Act
            var result = IntType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesShouldReturnOptionIntSome()
        {
            // Arrange
            var s = "1";
            Option<int> expected = Some(1);

            // Act
            var result = IntType.Parse(s, NumberStyles.Integer);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesShouldReturnOptionIntNone()
        {
            // Arrange
            var s = "not an int";
            Option<int> expected = None;

            // Act
            var result = IntType.Parse(s, NumberStyles.Integer);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesShouldReturnOptionIntNoneWhenStringIsNotExpectedHexNumber()
        {
            // Arrange
            var s = "1.0";
            Option<int> expected = None;

            // Act
            var result = IntType.Parse(s, NumberStyles.HexNumber);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithFormatProviderShouldReturnOptionIntSome()
        {
            // Arrange
            var s = "p1234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<int> expected = Some(1234);

            // Act
            var result = IntType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithFormatProviderShouldReturnOptionIntNone()
        {
            // Arrange
            var s = "positive1234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<int> expected = None;

            // Act
            var result = IntType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesAndFormatProviderShouldReturnOptionIntSome()
        {
            // Arrange
            var s = "p1";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<int> expected = Some(1);

            // Act
            var result = IntType.Parse(s, NumberStyles.Integer, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesAndFormatProviderShouldReturnOptionIntNone()
        {
            // Arrange
            var s = "p1$234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<int> expected = None;

            // Act
            var result = IntType.Parse(s, NumberStyles.Integer, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        #endregion
    }
}
