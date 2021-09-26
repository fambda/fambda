using System;
using Fambda.Tests.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    public partial class UnitTests
    {
        [TestMethod]
        [TestCategory("Equable")]
        public void EquableNullMustPass()
        {
            // Arrange
            Unit unit = new Unit();

            // Act
            var result = new Equable().Null(unit);

            // Assert
            result.Should().Pass();
        }

        [TestMethod]
        [TestCategory("Equable")]
        public void EquableEqualMustPass()
        {
            // Arrange
            Unit first = new Unit();
            Unit second = new Unit();

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [TestMethod]
        [TestCategory("Equable")]
        public void EquableUnequalMustNotPass()
        {
            // Arrange
            Unit first = new Unit();
            Unit second = new Unit();

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().NotPass("Equals returned 'true' on expected non-equal objects.",
                                    "Typed Equals returned 'true' on expected non-equal objects.",
                                    "Equality operator returned 'true' on expected non-equal objects.",
                                    "Inequality operator returned 'false' on expected non-equal objects.");
        }

    }
}
