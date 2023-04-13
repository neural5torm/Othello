using Othello.ValueObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;

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
    /// Internally uses sbyte Column and Row indexes for easy and efficient mathematical manipulation.
    /// </summary>
    public class Position
    {
        public sbyte Column { get; private set; }
        public sbyte Row { get; private set; }

        protected Position(sbyte column, sbyte row, bool checkValidIndices)
        {
            Column = column;
            Row = row;

            if (checkValidIndices && !AreIndicesValid)
                throw new InvalidPositionException($"Invalid position: c{column}:r{row}.");            
        }

        public Position(sbyte column, sbyte row)
            : this(column, row, true)
        { }

        public Position(string column, int row)
            : this(column.ToColumnIndex(), Convert.ToSByte(row))
        { }

        private bool AreIndicesValid
            =>  IndexExtensions.MinIndex <= Column && Column <= IndexExtensions.MaxIndex
                &&
                IndexExtensions.MinIndex <= Row && Row <= IndexExtensions.MaxIndex;        

        private bool IsValid
            => this is not InvalidPosition && AreIndicesValid;

        public bool IsWithinBoundsOfDimension(Dimension dimension)
        {
            return IsValid &&
                Column < IndexExtensions.MinIndex + dimension.Length &&
                Row < IndexExtensions.MinIndex + dimension.Length;
        }

        public Position NextPositionInDirection(Direction direction)
        {
            var positionChange = direction.ToPositionChange();

            if (Column == IndexExtensions.MinIndex &&
                (direction == Direction.NorthWest ||
                direction == Direction.West ||
                direction == Direction.SouthWest)
                ||
                Row == IndexExtensions.MinIndex &&
                (direction == Direction.North ||
                direction == Direction.NorthEast ||
                direction == Direction.NorthWest))
                return new InvalidPosition(Convert.ToSByte(Column + positionChange.VerticalDelta),
                Convert.ToSByte(Row + positionChange.HorizontalDelta));


            return new(Convert.ToSByte(Column + positionChange.VerticalDelta),
                Convert.ToSByte(Row + positionChange.HorizontalDelta));
        }

        public static explicit operator string(Position position)
            => position.ToString();

        public override string ToString()
           => $"{Column.ToColumnName()}{Row}";

        public static explicit operator Position(string position)
        {
            var trimmed = position.Trim();

            var column = trimmed[..1];
            var row = int.Parse(trimmed[1..]);

            return new(column, row);
        }

        public static IEnumerable<Position> AllPositionsForBoardDimension(Dimension boardDimension)
        {
            foreach (var columnIndex in boardDimension.Indices)
            {
                foreach (var rowIndex in boardDimension.Indices)
                {
                    yield return new(Convert.ToSByte(columnIndex), Convert.ToSByte(rowIndex));
                }
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Position position &&
                   Column == position.Column &&
                   Row == position.Row;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Column, Row);
        }

        public static Position Origin => new(IndexExtensions.MinIndex, IndexExtensions.MinIndex);
    }
}
