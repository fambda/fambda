using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Fambda.Tests
{
    public class EnumerableTests
    {
        #region Map

        [Fact]
        public void MapShouldSucceed()
        {
            // Arrange
            IEnumerable<int> enumerable = new List<int> { 1, 2, 3 };
            Func<int, string> toString = i => i.ToString();

            // Act
            var result = enumerable.Map(toString);

            // Assert
            result.Should().HaveElementAt(0, "1");
            result.Should().HaveElementAt(1, "2");
            result.Should().HaveElementAt(2, "3");
        }

        [Fact]
        public void MapShouldReturnEmptyEnumerable()
        {
            // Arrange
            IEnumerable<int> enumerable = new List<int> ();
            Func<int, string> toString = i => i.ToString();

            // Act
            var result = enumerable.Map(toString);

            // Assert
            result.Should().HaveCount(0);
        }

        [Fact]
        public void MapShouldReturnNestedEnumerable()
        {
            // Arrange
            var family = new[]
            {
                new { Name = "Tom", Cars = new string[]{"Mazda", "Nissan"} },
                new { Name = "Kris", Cars = new string[]{} },
                new { Name = "Sven", Cars = new string[]{"Audi"} },
            };

            // Act
            var result = family.Map(x => x.Cars).ToList();

            // Assert
            result.Should().HaveCount(3);
            result[0][0].Should().Be("Mazda");
            result[0][1].Should().Be("Nissan");
            result[1].Should().BeEmpty();
            result[2][0].Should().Be("Audi");
        }

        #endregion

        #region Bind

        [Fact]
        public void BindShouldSucceed()
        {
            // Arrange
            var family = new[]
            {
                new { Name = "Tom", Cars = new string[]{"Mazda", "Nissan"} },
                new { Name = "Kris", Cars = new string[]{} },
                new { Name = "Sven", Cars = new string[]{"Audi"} },
            };

            // Act
            IEnumerable<string> result = family.Bind(x => x.Cars);


            // Assert
            result.Should().HaveElementAt(0, "Mazda");
            result.Should().HaveElementAt(1, "Nissan");
            result.Should().HaveElementAt(2, "Audi");
        }

 
        #endregion
    }
}
