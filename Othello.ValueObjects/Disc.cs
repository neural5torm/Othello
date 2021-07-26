using System;

namespace Othello.ValueObjects
{
    public enum Disc : byte
    {
        None = 0,
        BlackSideUp = 1,
        WhiteSideUp = 2
    }

    public static class DiscExtensions
    {
        public static Disc Flipped(this Disc disc)
            => disc switch
            {
                Disc.BlackSideUp => Disc.WhiteSideUp,
                Disc.WhiteSideUp => Disc.BlackSideUp,

                _ => throw new NotSupportedException()
            };
    }
}