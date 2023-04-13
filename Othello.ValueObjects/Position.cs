using Othello.ValueObjects.Exceptions;
using System;
using System.Collections.Generic;

namespace Othello.ValueObjects
{
    /// <summary>
    /// Represents the position of a square on the Othello board. 
    /// 
    /// Always of the form 'a1' where:
    /// * the first character (letter) identifies the column,
    /// * the second character (figure) identifies the row.
    ///     
    /// In standard Othello,
    /// columns go from a to h (left to right) and
    /// rows go from 1 to 8 (top to bottom).
    /// 
    /// Internally uses sbyte Column and Row indices for easy and efficient mathematical manipulation.
    /// </summary>
    public class Position
    {
        public sbyte ColumnIndex { get; private set; }
        public sbyte RowIndex { get; private set; }

        protected Position(sbyte columnIndex, sbyte rowIndex, bool checkValidIndices)
        {
            ColumnIndex = columnIndex;
            RowIndex = rowIndex;

            if (checkValidIndices && !AreIndicesValid)
                throw new InvalidPositionException($"Invalid position: c{columnIndex}:r{rowIndex}.");            
        }

        public Position(sbyte columnIndex, sbyte rowIndex)
            : this(columnIndex, rowIndex, checkValidIndices: true)
        { }

        public Position(string columnName, int rowName)
            : this(columnName.ToColumnIndex(), Convert.ToSByte(rowName))
        { }

        private bool AreIndicesValid
            =>  IndexExtensions.MinIndex <= ColumnIndex && ColumnIndex <= IndexExtensions.MaxIndex
                &&
                IndexExtensions.MinIndex <= RowIndex && RowIndex <= IndexExtensions.MaxIndex;        

        private bool IsValid
            => this is not InvalidPosition && AreIndicesValid;

        public bool IsWithinBoundsOfBoardDimension(Dimension dimension)
        {
            return IsValid &&
                ColumnIndex < IndexExtensions.MinIndex + dimension.Length &&
                RowIndex < IndexExtensions.MinIndex + dimension.Length;
        }

        public Position NextPositionInDirection(Direction direction)
        {
            var positionChange = direction.ToPositionChange();

            if (ColumnIndex == IndexExtensions.MinIndex &&
                (direction == Direction.NorthWest ||
                direction == Direction.West ||
                direction == Direction.SouthWest)
                ||
                RowIndex == IndexExtensions.MinIndex &&
                (direction == Direction.North ||
                direction == Direction.NorthEast ||
                direction == Direction.NorthWest))
                return new InvalidPosition(Convert.ToSByte(ColumnIndex + positionChange.VerticalDelta),
                Convert.ToSByte(RowIndex + positionChange.HorizontalDelta));


            return new(Convert.ToSByte(ColumnIndex + positionChange.VerticalDelta),
                Convert.ToSByte(RowIndex + positionChange.HorizontalDelta));
        }

        public static explicit operator string(Position position)
            => position.ToString();

        public override string ToString()
           => $"{ColumnIndex.ToColumnName()}{RowIndex}";

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
                   ColumnIndex == position.ColumnIndex &&
                   RowIndex == position.RowIndex;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ColumnIndex, RowIndex);
        }

        public static Position Origin => new(IndexExtensions.MinIndex, IndexExtensions.MinIndex);
    }
}
