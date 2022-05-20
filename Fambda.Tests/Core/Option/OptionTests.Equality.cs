using Fambda.Helpers;
using FluentAssertions;
using Xunit;

using static Fambda.F;

namespace Fambda
{
    public partial class OptionTests
    {
        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_NullWhenOptionInNone_DoesPass()
        {
            // Arrange
            Option<int> option = None;

            // Act
            var result = new Equable().Null(option);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_NullWhenOptionInSome_DoesPass()
        {
            // Arrange
            Option<int> option = Some(1);

            // Act
            var result = new Equable().Null(option);

            // Assert
            result.Should().Pass();
        }


        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_EqualWhenOptionInNoneAndOptionInNone_DoesPass()
        {
            // Arrange
            Option<int> first = None;
            Option<int> second = None;

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_EqualWhenOptionInSomeAndOptionInSome_DoesPass()
        {
            // Arrange
            Option<int> first = Some(1);
            Option<int> second = Some(1);

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_EqualWhenOptionInNoneAndOptionNone_DoesPass()
        {
            // Arrange
            Option<int> first = None;
            OptionNone second = OptionNone.Default;

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_EqualWhenOptionInSomeAndOptionSome_DoesPass()
        {
            // Arrange
            // Arrange
            var value = "value";
            Option<string> first = Some(value);
            var second = new OptionSome<string>(value);

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_UnequalWhenOptionInSomeAndOptionInSome_DoesPass()
        {
            // Arrange
            Option<int> first = Some(1);
            Option<int> second = Some(2);

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_UnequalWhenOptionInNoneAndOptionInSome_DoesPass()
        {
            // Arrange
            Option<int> first = None;
            Option<int> second = Some(1);

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().Pass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_UnequalWhenOptionInNoneAndOptionNone_DoesNotPass()
        {
            // Arrange
            Option<int> first = None;
            OptionNone second = OptionNone.Default;

            // Act
            var result = new Equable().Unequal(first, second);

            // Assert
            result.Should().NotPass();
        }

        [Fact]
        [Trait("Category", "Equable")]
        public void Equable_UnequalWhenOptionInSomeAndOptionSome_DoesPass()
        {
            // Arrange
            // Arrange
            var value = "value";
            Option<string> first = Some(value);
            var second = new OptionSome<string>(value);

            // Act
            var result = new Equable().Equal(first, second);

            // Assert
            result.Should().Pass();
        }
    }
}
