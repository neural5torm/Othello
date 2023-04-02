using FluentAssertions;
using Othello.ValueObjects;
using Othello.ValueObjects.Exceptions;
using System;
using Xunit;

namespace Othello.UnitTests
{
    public class DimensionTests
    {
        [Theory]
        [InlineData(8)]
        [InlineData(2)]
        [InlineData(10)]
        public void CreateValidDimension(sbyte sideLength)
        {
            // Act
            Dimension dimension = (Dimension)sideLength;

            // Assert
            dimension.Length
                .Should()
                .Be(sideLength);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(11)]
        public void CreateOutOfRangeDimension(sbyte length)
        {
            // Act
            Action create = () => _ = new Dimension(length);

            // Assert
            create
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(3)]
        [InlineData(7)]
        public void CreateUnevenDimension(int length)
        {
            // Act
            Action create = () => _ = (Dimension)length;

            // Assert
            create
                .Should()
                .Throw<UnevenDimensionException>();
        }
    }
}
