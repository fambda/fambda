using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public class DoubleTypeTests
    {
        #region Parse

        [Fact]
        public void ParseShouldReturnOptionDoubleNone()
        {
            // Arrange
            var s = "not a double";
            Option<double> expected = None;

            // Act
            var result = DoubleType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseShouldReturnOptionDoubleSome()
        {
            // Arrange
            var s = "1.1";
            Option<double> expected = Some(1.1);

            // Act
            var result = DoubleType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesShouldReturnOptionDoubleNone()
        {
            // Arrange
            var s = "not a double";
            Option<double> expected = None;

            // Act
            var result = DoubleType.Parse(s, NumberStyles.Number);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesShouldReturnOptionDoubleSome()
        {
            // Arrange
            var s = "1.1";
            Option<double> expected = Some(1.1);

            // Act
            var result = DoubleType.Parse(s, NumberStyles.Number);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesShouldReturnOptionDoubleNoneWhenStringIsNotExpectedHexNumber()
        {
            // Arrange
            var s = "1.0";
            Option<double> expected = None;

            // Act
            var result = DoubleType.Parse(s, NumberStyles.HexNumber);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithFormatProviderShouldReturnOptionDoubleNone()
        {
            // Arrange
            var s = "positive1234.5";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<double> expected = None;

            // Act
            var result = DoubleType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithFormatProviderShouldReturnOptionDoubleSome()
        {
            // Arrange
            var s = "p1234.5";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<double> expected = Some(1234.5);

            // Act
            var result = DoubleType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesAndFormatProviderShouldReturnOptionDoubleNone()
        {
            // Arrange
            var s = "p1$234.5";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<double> expected = None;

            // Act
            var result = DoubleType.Parse(s, NumberStyles.Number, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ParseWithNumberStylesAndFormatProviderShouldReturnOptionDoubleSome()
        {
            // Arrange
            var s = "p1.2";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<double> expected = Some(1.2);

            // Act
            var result = DoubleType.Parse(s, NumberStyles.Number, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        #endregion
    }
}
