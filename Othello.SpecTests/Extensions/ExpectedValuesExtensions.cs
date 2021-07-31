using Othello.ValueObjects;
using System;

namespace Othello.SpecTests.Extensions
{
    public static class ExpectedValuesExtensions
    {
        public static Disc ToDisc(this string expectedDiscValue)
            => expectedDiscValue.ToUpper() switch
            {
                "" => Disc.None,
                "B" => Disc.BlackSideUp,
                "W" => Disc.WhiteSideUp,
                _ => throw new NotSupportedException("Unknown expected disc value.")
            };
    }
}
