using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Othello.ValueObjects
{
    public static class Directions
    {
        public static IReadOnlyCollection<Direction> All()
        {
            return new Direction[]
            {
                Direction.North,
                Direction.NorthEast,

                Direction.East,
                Direction.SouthEast,

                Direction.South,
                Direction.SouthWest,

                Direction.West,
                Direction.NorthWest
            }
            .ToImmutableArray();
        }

        internal static PositionChange ToPositionChange(this Direction direction)
            => direction switch
            {
                Direction.North => new(0, -1),
                Direction.NorthEast => new(1, -1),

                Direction.East => new(1,0),
                Direction.SouthEast =>new(1,1),
                
                Direction.South => new(0,1),
                Direction.SouthWest => new(-1,1),
                
                Direction.West => new(-1,0),
                Direction.NorthWest => new(-1,-1),

                _ => throw new NotSupportedException()
            };
    }
}