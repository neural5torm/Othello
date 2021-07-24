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
    /// </summary>
    public record Position(char Column, uint Row)
    {
        private char Column { get; } = Column.ToString().ToLower().Single() >= 'a' && Column.ToString().ToLower().Single() <= 'z'
            ? Column.ToString().ToLower().Single()
            : throw new ArgumentOutOfRangeException(nameof(Column));

        private uint Row { get; } = Row >= 1
            ? Row
            : throw new ArgumentOutOfRangeException(nameof(Row));


        public Position(string column, int row)
            : this(column.Trim().Single(),
                  (uint)row)
        {
            if (row < 1)
                throw new ArgumentOutOfRangeException(nameof(row));
        }

        private Position(int column, int row)
            : this((char)((short)'a' + column - 1), 
                  (uint)row)
        {
        }

        public override string ToString()
            => this;

        public static implicit operator string(Position position)
            => $"{position.Column}{position.Row}";

        public static implicit operator Position(string position)
        {
            var trimmed = position.Trim();
            var column = trimmed.First();
            var row = uint.Parse(trimmed[1..]);

            return new(column, row);
        }

        public static IEnumerable<Position> AllPositionsForBoardDimension(Dimension boardDimension)
        {
            foreach (var columnIndex in Enumerable.Range(1, boardDimension))
            {
                foreach (var rowIndex in Enumerable.Range(1, boardDimension))
                {
                    yield return new Position(columnIndex, rowIndex);
                }
            }
        }
    }
}
