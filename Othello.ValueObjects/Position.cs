using System;
using System.Collections.Generic;
using System.Linq;

namespace Othello.ValueObjects
{
    /// <summary>
    /// Represents the position of a square on the Othello board. 
    /// 
    /// Always of the form 'a1' where:
    /// * the first character (letter) indexes the column,
    /// * the second character (figure) indexes the row.
    ///     
    /// In standard Othello,
    /// columns go from a to h (left to right) and
    /// rows go from 1 to 8 (top to bottom).
    /// 
    /// Internally uses sbyte Column and Row indices for easy, memory-efficient mathematical manipulation.
    /// </summary>
    public sealed record Position(sbyte Column, sbyte Row)
    {
        sbyte Column { get; } 
            = Index.MinIndex <= Column && Column <= Index.MaxIndex
            ? Column
            : throw new ArgumentOutOfRangeException(nameof(Column));

        sbyte Row { get; } 
            = Index.MinIndex <= Row && Row <= Index.MaxIndex
            ? Row
            : throw new ArgumentOutOfRangeException(nameof(Row));

        public Position(string column, int row)
            : this(column.ToColumnIndex(), Convert.ToSByte(row))
        {
        }

        public bool IsValidForDimension(Dimension dimension)
        {
            return Column < Index.MinIndex + dimension &&
                Row < Index.MinIndex + dimension;
        }

        public Position? NextPosition(Direction direction)
        {
            if (this == Origin &&
                (direction == Direction.North ||
                direction == Direction.NorthEast ||
                direction == Direction.SouthWest ||
                direction == Direction.West ||
                direction == Direction.NorthWest))
                return null;

            var change = direction.ToPositionChange();

            return new(Convert.ToSByte(Column + change.ColumnDelta), 
                Convert.ToSByte(Row + change.RowDelta));
        }

        public static implicit operator string(Position position)
            => $"{position.Column.ToColumnName()}{position.Row}";
        
        public override string ToString()
           => this;

        public static implicit operator Position(string position)
        {
            var trimmed = position.Trim();

            var column = trimmed[..1];
            var row = int.Parse(trimmed[1..]);

            return new(column, row);
        }

        public static IEnumerable<Position> AllPositionsForBoardDimension(Dimension boardDimension)
        {
            foreach (var columnIndex in Enumerable.Range(Index.MinIndex, boardDimension))
            {
                foreach (var rowIndex in Enumerable.Range(Index.MinIndex, boardDimension))
                {
                    yield return new(Convert.ToSByte(columnIndex), Convert.ToSByte(rowIndex));
                }
            }
        }

        public static Position Origin => new(Index.MinIndex, Index.MinIndex);
    }
}
