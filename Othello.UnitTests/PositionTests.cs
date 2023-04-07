using FluentAssertions;
using Othello.ValueObjects;
using System;
using System.Linq;
using Xunit;

namespace Othello.UnitTests
{
    public class PositionTests
    {      
        [Theory]
        [InlineData("a", 1, "a1")]
        [InlineData("A ", 18, "a18")]
        [InlineData(" Z  ", 26, "z26")]
        public void CreatePositionWithValidStringColumnAndIntegerRow(string column, int row, string expected)
        {
            // Act
            var position = new Position(column, row);
            
            // Assert
            position.ToString()
                .Should()
                .Be(expected);
        }

        [Theory]
        [InlineData("A:", 1)]
        [InlineData("AA", 1)]
        [InlineData("A", 0)]
        [InlineData("A", 27)]
        [InlineData("A", -255)]
        [InlineData("A", 257)]
        public void CreatePositionWithInvalidStringColumnOrIntegerRow(string column, int row)
        {
            // Act
            Action create = () => _ = new Position(column, row);

            // Assert
            create
                .Should()
                .Throw<Exception>();
        }

        [Theory]
        [InlineData("a1", "a1")]
        [InlineData("A01", "a1")]
        [InlineData("A 10", "a10")]
        [InlineData(" h8  ", "h8")]
        public void ConvertValidStringToPosition(string stringPosition, string expected)
        {
            // Act
            Position position = stringPosition;

            // Assert
            position.ToString()
                .Should()
                .Be(expected);
        }

        [Theory]
        [InlineData("aa1")]
        [InlineData("a0")]
        [InlineData("a27")]
        [InlineData("a-255")]
        [InlineData("a257")]
        [InlineData("a-1")]
        [InlineData("h:8")]
        public void ConvertInvalidStringToPosition(string stringPosition)
        {
            // Act
            Action convert = () => _ = (Position)stringPosition;

            // Assert
            convert
                .Should()
                .Throw<Exception>();
        }

        [Theory]
        [InlineData(2, new string[] { "a1", "a2", "b1", "b2" })]
        [InlineData(4, new string[] { "a1", "a2", "a3", "a4", "b1", "b2", "b3", "b4", "c1", "c2", "c3", "c4", "d1", "d2", "d3", "d4" })]
        public void EnumerateAllPositionsForBoardDimension(sbyte dimension, string[] expectedPositions)
        {
            // Act
            var positions = Position.AllPositionsForBoardDimension((Dimension)dimension);

            // Assert
            positions.Should()
                .BeEquivalentTo(expectedPositions.Select(e => (Position)e));
        }

        [Theory]
        [InlineData("b2", Direction.North, "b1")]
        [InlineData("b2", Direction.NorthEast, "c1")]
        [InlineData("a1", Direction.East, "b1")]
        [InlineData("a1", Direction.SouthEast, "b2")]
        [InlineData("a1", Direction.South, "a2")]
        [InlineData("b2", Direction.SouthWest, "a3")]
        [InlineData("b2", Direction.West, "a2")]
        [InlineData("b2", Direction.NorthWest, "a1")]
        public void GetNextPositionWithValidDirection(string from, Direction direction, string expectedNextPosition)
        {
            // Arrange
            Position fromPosition = from;

            // Act
            var nextPosition = fromPosition.NextPositionInDirection(direction);

            // Assert
            nextPosition.Should()
                .Be((Position)expectedNextPosition);
        }

        [Theory]
        [InlineData(Direction.North, "h1")]
        [InlineData(Direction.NorthEast, "h1")]
        [InlineData(Direction.NorthWest, "h1")]
        [InlineData(Direction.NorthWest, "a8")]
        [InlineData(Direction.West, "a8")]
        [InlineData(Direction.SouthWest, "a8")]
        public void GetNextPositionWithInvalidDirection(Direction direction, string from)
        {
            // Arrange
            Position fromPosition = from;
            
            // Act
            var nextPosition = fromPosition.NextPositionInDirection(direction);

            // Assert
            nextPosition.Should()
                .BeOfType<InvalidPosition>();
        }
    }
}
