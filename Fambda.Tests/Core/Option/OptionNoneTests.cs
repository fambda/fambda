using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fambda.Tests
{
    [TestClass]
    public class OptionNoneTests
    {
        [TestMethod]
        public void CtorShouldEqualWithDefault()
        {
            // Arrange
            var first = new OptionNone();
            var second = default(OptionNone);


            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void EqualsObjectShouldSucceed()
        {
            // Arrange
            var first = new OptionNone();
            var second = new OptionNone();

            // Act
            var result = Equals(first, second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void EqualsOptionNoneShouldSucceed()
        {
            // Arrange
            var first = new OptionNone();
            var second = new OptionNone();

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ToStringShouldProvideExpectedRepresentation()
        {
            // Arrange
            var expectedResult = "None";
            var optionNone = new OptionNone();

            // Act
            var result = optionNone.ToString();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
