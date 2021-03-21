using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    [TestClass]
    public class EitherTests
    {
        #region EitherLeftHolder<L>

        [TestMethod]
        public void EitherLeftHolderCtorShouldSucceed()
        {
            // Arrange
            var value = "left";

            // Act
            Action ctor = () => { new EitherLeftHolder<string>(value); };

            // Assert
            ctor.Should().NotThrow();
        }

        [TestMethod]
        public void EitherLeftHolderShouldHaveExpectedValue()
        {
            // Arrange
            var value = "left";
            var eitherLeftHolder = new EitherLeftHolder<string>(value);

            // Act
            var result = eitherLeftHolder.Value;

            // Assert
            result.Should().Be(value);
        }

        [TestMethod]
        public void EitherLeftHolderToStringShouldProvideExpectedRepresentation()
        {
            // Arrange
            var value = "left";
            var expectedResult = $"Left({value})";
            var eitherLeftHolder = new EitherLeftHolder<string>(value);

            // Act
            var result = eitherLeftHolder.ToString();

            // Assert
            result.Should().Be(expectedResult);
        }

        #endregion

        #region EitherRightHolder<R>

        [TestMethod]
        public void EitherRightHolderCtorShouldSucceed()
        {
            // Arrange
            var value = "right";

            // Act
            Action ctor = () => { new EitherRightHolder<string>(value); };

            // Assert
            ctor.Should().NotThrow();
        }

        [TestMethod]
        public void EitherRightHolderShouldHaveExpectedValue()
        {
            // Arrange
            var value = "right";
            var eitherRightHolder = new EitherRightHolder<string>(value);

            // Act
            var result = eitherRightHolder.Value;

            // Assert
            result.Should().Be(value);
        }

        [TestMethod]
        public void EitherRightHolderToStringShouldProvideExpectedRepresentation()
        {
            // Arrange
            var value = "right";
            var expectedResult = $"Right({value})";
            var eitherRightHolder = new EitherRightHolder<string>(value);

            // Act
            var result = eitherRightHolder.ToString();

            // Assert
            result.Should().Be(expectedResult);
        }

        #endregion
    }
}
