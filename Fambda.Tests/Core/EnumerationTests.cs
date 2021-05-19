using System.Collections.Generic;
using Fambda.Tests.DataTypes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    [TestClass]
    public class EnumerationTests
    {
        #region List

        [TestMethod]
        public void ListShouldSucceed()
        {
            // Arrange
            var expected = new List<Month> {
                                    Month.January,
                                    Month.February,
                                    Month.March,
                                    Month.April,
                                    Month.May,
                                    Month.June,
                                    Month.July,
                                    Month.August,
                                    Month.September,
                                    Month.October,
                                    Month.November,
                                    Month.December
                                };

            // Act
            var result = Enumeration.List<Month>();

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region Get

        [TestMethod]
        public void GetShouldSucceedWithSome()
        {
            // Arrange
            Option<Month> expected = Month.January;

            // Act
            var result = Enumeration.Get<Month>(Month.January.Key);

            // Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        public void GetShouldSucceedWithNone()
        {
            // Arrange
            Option<Month> expected = F.None;

            // Act
            var result = Enumeration.Get<Month>("some unexisting key in Month enumeration");

            // Assert
            result.Should().Be(expected);
        }

        #endregion

        #region Equals

        [TestMethod]
        public void EqualsShouldReturnTrue()
        {
            // Arrange
            var first = Month.January;
            var second = Month.January;

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void EqualsShouldReturnFalse()
        {
            // Arrange
            var first = Month.January;
            var second = Month.December;

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void OperatorEqualToOverloadingShouldReturnTrue()
        {
            // Arrange
            var first = Month.January;
            var second = Month.January;

            // Act
            var result = first == second;

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void OperatorNotEqualToOverloadingShouldReturnFalse()
        {
            // Arrange
            var first = Month.January;
            var second = Month.January;

            // Act
            var result = first != second;

            // Assert
            result.Should().BeFalse();
        }

        #endregion

        [TestMethod]
        public void ToStringShouldReturnKey()
        {
            // Arrange
            var enumeration = Month.January;

            // Act
            var result = enumeration.ToString();

            // Assert
            result.Should().Be(Month.January.Key);
        }

    }
}
