using System;
using Fambda.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests.Extensions
{
    [TestClass]
    public class StringExtensionsTests
    {
        [DataTestMethod]
        [DataRow(null, false)]
        [DataRow("not empty", false)]
        [DataRow("", true)]
        public void IsEmptyShouldReturnExpectedResult(string str, bool boolean)
        {
            // Arrange
            var expected = boolean;

            // Act
            var result = str.IsEmpty();

            // Assert
            result.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(null, false)]
        [DataRow("not white space", false)]
        [DataRow("", true)]
        [DataRow(" ", true)]
        [DataRow("  ", true)]
        public void IsWhiteSpaceShouldReturnExpectedResult(string str, bool boolean)
        {
            // Arrange
            var expected = boolean;

            // Act
            var result = str.IsWhiteSpace();

            // Assert
            result.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow(" str", true)]
        [DataRow("  str", true)]
        [DataRow("   str", true)]
        public void HasLeadingSpaceShouldReturnExpectedResult(string str, bool boolean)
        {
            // Arrange
            var expected = boolean;

            // Act
            var result = str.HasLeadingSpace();

            // Assert
            result.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow("str ", true)]
        [DataRow("str  ", true)]
        [DataRow("str   ", true)]
        public void HasTrailingSpaceShouldReturnExpectedResult(string str, bool boolean)
        {
            // Arrange
            var expected = boolean;

            // Act
            var result = str.HasTrailingSpace();

            // Assert
            result.Should().Be(expected);
        }
    }
}
