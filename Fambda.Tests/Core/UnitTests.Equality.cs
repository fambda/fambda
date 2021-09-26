using System;
using Fambda.Tests.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    public partial class UnitTests
    {
        [TestMethod]
        public void EqualsShouldReturnTrue()
        {
            // Arrange
            var first = new Unit();
            var second = new Unit();

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void UnitViaCtorAndViaFShouldEqual()
        {
            // Arrange
            var unit = new Unit();
            var expected = F.Unit();

            // Act
            var result = Equals(unit, expected);

            // Assert
            result.Should().BeTrue();
        }
    }
}
