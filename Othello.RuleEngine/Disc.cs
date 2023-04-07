using Othello.ValueObjects;
using System;

namespace Othello.RuleEngine
{
    public class PlacedDisc
    {
        public PlacedDisc(Square inSquare, Side side)
        {
            InSquare = inSquare;
            Side = side;
        }
        public Square InSquare { get;init;}
        public Side Side { get; private set; }
        public bool IsBlackSideUp => Side == Side.Black;
        public bool IsWhiteSideUp => Side == Side.White;

        internal void Flip()
        {
            Side = Side.GetOppositeSide();
        }
    }
}
