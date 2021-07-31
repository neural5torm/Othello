using System;

namespace Othello.ValueObjects
{
    public static class DirectionExtensions
    {
        internal static PositionChange ToPositionChange(this Direction direction)
            => direction switch
            {
                Direction.North => new(0, -1),
                Direction.NorthEast => new(1, -1),

                Direction.East => new(1, 0),
                Direction.SouthEast => new(1, 1),

                Direction.South => new(0, 1),
                Direction.SouthWest => new(-1, 1),

                Direction.West => new(-1, 0),
                Direction.NorthWest => new(-1, -1),

                _ => throw new NotSupportedException()
            };
    }
}