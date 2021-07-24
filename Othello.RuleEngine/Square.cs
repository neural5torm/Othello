using Othello.ValueObjects;
using System;

namespace Othello.RuleEngine
{
    public class Square
    {
        public Position Position { get; }
        public Disc Disc { get; private set; }

        public Square(Position position)
        {
            Position = position;
        }

        public void Put(Disc disc)
        {
            if (disc == Disc.None)
                throw new InvalidOperationException("Cannot remove a disc from a square.");
            if (IsFilled)
                throw new InvalidOperationException("Cannot put a disc in an already filled square.");

            Disc = disc;
        }

        public void FlipDisc()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Cannot flip the disc of an empty square.");

            Disc = (Disc == Disc.BlackSideUp)
                ? Disc.WhiteSideUp
                : Disc.BlackSideUp;
        }

        public bool IsEmpty => Disc == Disc.None;
        public bool IsFilled => !IsEmpty;

        public bool IsBlackFacingUp => Disc == Disc.BlackSideUp;
        public bool IsWhiteFacingUp => Disc == Disc.WhiteSideUp;
    }
}
