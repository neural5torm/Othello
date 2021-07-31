using System;
using System.Collections.Immutable;

namespace Othello.ValueObjects
{
    public static class Directions
    {
        public static ImmutableArray<Direction> All()
        {
            return Enum.GetValues<Direction>()
                .ToImmutableArray();
        }
    }
}