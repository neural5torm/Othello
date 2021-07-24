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
        [InlineData('a', 1, 'a')]
        [InlineData('A', 8, 'a')]
        [InlineData('z', 2, 'z')]
        public void CreatePositionWithValidCharColumnAndUIntRow(char column, uint row, char expectedColumn)
        {
            // Act
            var position = new Position(column, row);

            // Assert
            position
                .Should()
                .BeEquivalentTo(new
                {
                    Column = expectedColumn,
                    Row = row
                });
        }

        [Theory]
        [InlineData(' ', 1)]
        [InlineData('é', 1)]
        [InlineData('A', 0)]
        public void CreatePositionWithInvalidCharColumnOrUIntRow(char column, uint row)
        {
            // Act
            Action create = () => _ = new Position(column, row);

            // Assert
            create
                .Should()
                .Throw<Exception>();
        }

        [Theory]
        [InlineData("a", 1, 'a')]
        [InlineData("A", 8, 'a')]
        [InlineData(" A  ", 2, 'a')]
        public void CreatePositionWithValidStringColumnAndIntegerRow(string column, int row, char expectedColumn)
        {
            // Act
            var position = new Position(column, row);

            // Assert
            position
                .Should()
                .BeEquivalentTo(new
                {
                    Column = expectedColumn,
                    Row = row
                });
        }

        [Theory]
        [InlineData("AA", 1)]
        [InlineData("A", 0)]
        [InlineData("A", -1)]
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
        [InlineData("a1", 'a', 1u)]
        [InlineData("A01", 'a', 1u)]
        [InlineData("A 10", 'a', 10u)]
        [InlineData(" h8  ", 'h', 8u)]
        public void ConvertValidStringToPosition(string stringPosition, char expectedColumn, uint expectedRow)
        {
            // Act
            Position position = stringPosition;

            // Assert
            position
                .Should()
                .BeEquivalentTo(new
                {
                    Column = expectedColumn,
                    Row = expectedRow
                });
        }

        [Theory]
        [InlineData("aa1")]
        [InlineData("a0")]
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
        public void EnumerateAllPositionOnBoard(int dimension, string[] expectedPositions)
        {
            // Act
            var positions = Position.AllPositionsForBoardDimension(dimension);

            // Assert
            positions.Should()
                .BeEquivalentTo(expectedPositions.Select(e => (Position)e));
        }
    }
}
