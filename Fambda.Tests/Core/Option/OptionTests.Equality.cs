using System;
using Fambda.Contracts;
using Fambda.Tests.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Fambda.F;

namespace Fambda.Tests
{
    public partial class OptionTests
    {
        [TestMethod]
        public void EqualsOptionSomeShouldReturnTrue()
        {
            // Arrange
            OptionSome<int> optionSome = new OptionSome<int>(1);
            Option<int> option = Some(1);

            // Act
            var result = option.Equals(optionSome);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void EqualsOptionSomeShouldReturnFalse()
        {
            // Arrange
            OptionSome<int> optionSome = new OptionSome<int>(2);
            Option<int> option = Some(1);

            // Act
            var result = option.Equals(optionSome);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void EqualsOptionNoneShouldReturnTrue()
        {
            // Arrange
            OptionNone optionNone = OptionNone.Default;
            Option<int> option = None;

            // Act
            var result = option.Equals(optionNone);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void EqualsOptionNoneShouldReturnFalse()
        {
            // Arrange
            OptionNone optionNone = OptionNone.Default;
            Option<int> option = Some(1);

            // Act
            var result = option.Equals(optionNone);

            // Assert
            result.Should().BeFalse();
        }
    }
}
