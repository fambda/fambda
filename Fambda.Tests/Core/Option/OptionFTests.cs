using System;
using FluentAssertions;
using Xunit;
using static Fambda.F;

namespace Fambda
{
    public class OptionFTests
    {
        [Fact]
        public void None_Succeeds()
        {
            // Arrange
            var none = None;

            // Act
            Option<string> option = none;

            // Assert
            option.ToString().Should().Be("None");
        }

        [Fact]
        public void Some_NotNull_Succeeds()
        {
            // Arrange
            var value = "value";

            // Act
            Option<string> option = Some(value);

            // Assert
            option.ToString().Should().Be("Some(value)");
        }

        [Fact]
        public void Some_NullableNotNull_Succeeds()
        {
            // Arrange
            Nullable<int> value = 1;

            // Act
            Option<Nullable<int>> option = Some(value);

            // Assert
            option.ToString().Should().Be("Some(1)");
        }

        [Fact]
        public void Some_NullableNull_Throws()
        {
            // Arrange
            Nullable<int> value = null;

            // Act
            Func<Option<Nullable<int>>> shouldThrow = () => Some(value);

            // Assert
            shouldThrow.Should().Throw<ArgumentNullException>();
        }
    }
}
