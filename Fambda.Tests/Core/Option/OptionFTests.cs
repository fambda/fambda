using System;
using Fambda.Contracts;
using FluentAssertions;
using Xunit;
using static Fambda.F;

namespace Fambda
{
    public class OptionFTests
    {
        [Fact]
        public void SomeShouldSucceed()
        {
            // Arrange
            var value = "value";

            // Act
            Option<string> option = Some(value);

            // Assert
            option.ToString().Should().Be("Some(value)");
        }

        [Fact]
        public void SomeShouldFail()
        {
            // Arrange
            string value = null;

            // Act
            Action act = () => { Option<string> option = Some(value); };

            // Assert
            act.Should().Throw<OptionSomeValueMustNotBeNullException>();
        }

        [Fact]
        public void NoneShouldSucceed()
        {
            // Arrange
            var none = None;

            // Act
            Option<string> option = none;

            // Assert
            option.ToString().Should().Be("None");
        }
    }
}
