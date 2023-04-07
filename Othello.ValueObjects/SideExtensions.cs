using System;

namespace Othello.ValueObjects
{
    public static class SideExtensions
    {
        public static Side GetOppositeSide(this Side side)
            => side switch
            {
                Side.Black => Side.White,
                Side.White => Side.Black,

                _ => throw new NotSupportedException()
            };
    }
}