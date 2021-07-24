using Othello.ValueObjects;
using System;

namespace Othello.SpecTests.Extensions
{
    public static class ExpectedValuesExtensions
    {
        public static Disc ToDisc(this string disc)
            => disc.ToUpper() switch
            {
                "" => Disc.None,
                "B" => Disc.BlackSideUp,
                "W" => Disc.WhiteSideUp,
                _ => throw new ArgumentOutOfRangeException(nameof(disc), "invalid expected disc value")
            };
    }
}
