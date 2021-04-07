using System;
using System.Globalization;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Fambda.F;

namespace Fambda.Tests
{
    [TestClass]
    public class IntTypeTests
    {
        #region Parse

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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
