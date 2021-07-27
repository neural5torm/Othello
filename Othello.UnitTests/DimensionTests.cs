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
        [InlineData(20)]
        public void CreateValidDimension(int length)
        {
            // Act
            Dimension dimension = length;

            // Assert
            ((int)dimension)
                .Should()
                .Be(length);
        }

        [Theory]
        [InlineData(-255)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(21)]
        [InlineData(257)]
        public void CreateInvalidDimension(int length)
        {
            // Act
            Action create = () => _ = (Dimension)length;

            // Assert
            create
                .Should()
                .Throw<Exception>();
        }
    }
}
