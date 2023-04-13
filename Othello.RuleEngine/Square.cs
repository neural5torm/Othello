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

        public PlacedDisc PlaceADiscWith(ColorSide colorSideUp)
        {
            if (HasDisc)
                throw new InvalidOperationException("You cannot place a disc in an already filled square.");

            Disc = new (this, colorSideUp);
            return Disc;
        }

        public bool IsEmpty => Disc is null;
        public bool HasDisc => !IsEmpty;

        public bool HasDiscWithBlackSideUp => Disc is not null && Disc.IsBlackSideUp;
        public bool HasDiscWithWhiteSideUp => Disc is not null && Disc.IsWhiteSideUp;
        
        /// <summary>
        /// Represents the contents of the square: blank for empty, B for disc with Black side up, W for White side up.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this switch
            {
                var sq when sq.IsEmpty => " ",
                var sq when sq.HasDiscWithBlackSideUp => "B",
                var sq when sq.HasDiscWithWhiteSideUp => "W",

                _ => "?"
            };
        }

        internal bool HasDiscWith(ColorSide colorSideUp)
            => Disc is not null && Disc.ColorSideUp == colorSideUp;
    }
}
