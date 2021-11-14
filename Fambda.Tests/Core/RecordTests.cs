using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests
{
    public class RecordTests
    {
        #region Equals

        [Fact]
        public void EqualsShouldReturnTrue()
        {
            // Arrange
            var first = new Record1("value");
            var second = new Record1("value");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void EqualsShouldReturnFalse()
        {
            // Arrange
            var first = new Record1("value 1");
            var second = new Record1("value 2");

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void OperatorEqualToOverloadingShouldReturnTrue()
        {
            // Arrange
            var first = new Record1("value");
            var second = new Record1("value");

            // Act
            var result = first == second;

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void OperatorNotEqualToOverloadingShouldReturnFalse()
        {
            // Arrange
            var first = new Record1("value");
            var second = new Record1("value");

            // Act
            var result = first != second;

            // Assert
            result.Should().BeFalse();
        }

        #endregion

        class Record1 : Record<Record1>
        {
            private readonly string _value;

            public Record1(string value)
            {
                _value = value;
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return _value;
            }
        }
    }
}
