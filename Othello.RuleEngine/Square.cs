using Othello.ValueObjects;
using System;

namespace Othello.RuleEngine
{
    public class Square
    {
        public Position Position { get; }
        public PlacedDisc? Disc { get; private set; }

        public Square(Position position)
        {
            Position = position;
        }

        public PlacedDisc PlaceADiscOnSide(Side discSide)
        {
            if (HasDisc)
                throw new InvalidOperationException("You cannot place a disc in an already filled square.");

            Disc = new (this, discSide);
            return Disc;
        }

        public bool IsEmpty => Disc is null;
        public bool HasDisc => !IsEmpty;
        public bool HasBlackDisc => Disc is not null && Disc.IsBlackSideUp;
        public bool HasWhiteDisc => Disc is not null && Disc.IsWhiteSideUp;
        
        public override string ToString()
        {
            return this switch
            {
                var sq when sq.IsEmpty => " ",
                var sq when sq.HasBlackDisc => "B",
                var sq when sq.HasWhiteDisc => "W",

                _ => "?"
            };
        }

        internal bool HasDiscWithSideUp(Side side)
            => Disc is not null && Disc.Side == side;
    }
}
