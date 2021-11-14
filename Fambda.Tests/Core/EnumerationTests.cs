using System.Collections.Generic;
using Fambda.Tests.DataTypes;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests
{
    public class EnumerationTests
    {
        #region List

        [Fact]
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

        [Fact]
        public void GetShouldSucceedWithSome()
        {
            // Arrange
            Option<Month> expected = Month.January;

            // Act
            var result = Enumeration.Get<Month>(Month.January.Key);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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
