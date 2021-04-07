using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Fambda.F;

namespace Fambda.Tests
{
    [TestClass]
    public class OptionNoneTests
    {
        [TestMethod]
        public void OptionNoneShouldEqualWithDefault()
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
        public void OptionNoneEqualsObjectShouldSucceed()
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
        public void OptionNoneEqualsOptionNoneShouldSucceed()
        {
            // Arrange
            var first = new OptionNone();
            var second = new OptionNone();

            // Act
            var result = first.Equals(second);

            // Assert
            result.Should().BeTrue();
        }
    }
}
