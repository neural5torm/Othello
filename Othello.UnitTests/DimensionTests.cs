using FluentAssertions;
using Othello.ValueObjects;
using System;
using Xunit;

namespace Othello.UnitTests
{
    public class DimensionTests
    {
        [Theory]
        [InlineData(8)]
        [InlineData(2)]
        [InlineData(26)]
        public void CreateValidDimension(int sideLength)
        {
            // Act
            int dimension = new Dimension(sideLength);

            // Assert
            dimension
                .Should().Be(sideLength);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(27)]
        public void CreateInvalidDimension(int length)
        {
            // Act
            Action create = () => _ = new Dimension(length);

            // Assert
            create
                .Should()
                .Throw<Exception>();
        }
    }
}
