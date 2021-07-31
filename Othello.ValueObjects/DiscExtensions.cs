using System;

namespace Othello.ValueObjects
{
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