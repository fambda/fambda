using Fambda.Tests.DataTypes;
using Fambda.Tests.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    public partial class ExceptionalTests
    {
        [TestMethod]
        [TestCategory("Equable")]
        public void EquableNullMustPass()
        {
            // Arrange
            var exception = new SomeException();
            Exceptional<string> exceptional = exception;

            // Act
            var result = new Equable().Null(exceptional);

            // Assert
            result.Should().Pass();
        }

        [TestMethod]
        [TestCategory("Equable")]
        public void EquableEqualMustPass()
        {
            // Arrange
            var firstException = new SomeException();
            Exceptional<string> first = firstException;

            var secondException = new SomeException();
            Exceptional<string> second = secondException;

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [TestMethod]
        [TestCategory("Equable")]
        public void EquableUnequalMustPass()
        {
            // Arrange
            var firstException = new SomeException();
            Exceptional<string> first = firstException;

            var value = "any value of any type besides Exception";
            Exceptional<string> second = value;

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }

    }
}
