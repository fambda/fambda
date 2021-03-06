using System;
using System.Globalization;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Fambda.F;

namespace Fambda.Tests
{
    [TestClass]
    public class DecimalTypeTests
    {
        #region Parse

        [TestMethod]
        public void ParseShouldReturnOptionDecimalSome()
        {
            // Arrange
            var s = "1";
            Option<decimal> expected = Some(1M);

            // Act
            var result = DecimalType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        public void ParseShouldReturnOptionDecimalNone()
        {
            // Arrange
            var s = "not a decimal";
            Option<decimal> expected = None;

            // Act
            var result = DecimalType.Parse(s);

            // Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        public void ParseWithNumberStylesShouldReturnOptionDecimalSome()
        {
            // Arrange
            var s = "1.1";
            Option<decimal> expected = Some(1.1M);

            // Act
            var result = DecimalType.Parse(s, NumberStyles.AllowDecimalPoint);

            // Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        public void ParseWithNumberStylesShouldReturnOptionDecimalNone()
        {
            // Arrange
            var s = "not a decimal";
            Option<decimal> expected = None;

            // Act
            var result = DecimalType.Parse(s, NumberStyles.AllowDecimalPoint);

            // Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        public void ParseWithNumberStylesShouldReturnOptionDecimalNoneWhenStringIsNotExpectedHexNumber()
        {
            // Arrange
            var s = "1.1";
            Option<decimal> expected = None;

            // Act
            var result = DecimalType.Parse(s, NumberStyles.HexNumber);

            // Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        public void ParseWithFormatProviderShouldReturnOptionDecimalSome()
        {
            // Arrange
            var s = "p1234";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<decimal> expected = Some(1234M);

            // Act
            var result = DecimalType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        public void ParseWithFormatProviderShouldReturnOptionDecimalNone()
        {
            // Arrange
            var s = "positive1234.1";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };

            Option<decimal> expected = None;

            // Act
            var result = DecimalType.Parse(s, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        public void ParseWithNumberStylesAndFormatProviderShouldReturnOptionDecimalSome()
        {
            // Arrange
            var s = "p1.1";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p", NumberDecimalSeparator= "." };
            Option<decimal> expected = Some(1.1M);

            // Act
            var result = DecimalType.Parse(s, NumberStyles.Number, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        public void ParseWithNumberStylesAndFormatProviderShouldReturnOptionDecimalNone()
        {
            // Arrange
            var s = "p1$234.4";
            IFormatProvider formatProvider = new NumberFormatInfo() { PositiveSign = "p" };
            Option<decimal> expected = None;

            // Act
            var result = DecimalType.Parse(s, NumberStyles.AllowDecimalPoint, formatProvider);

            // Assert
            result.Should().Be(expected);
        }

        #endregion
    }
}
