﻿using Othello.ValueObjects;
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

        public void PlaceADisc(Disc disc)
        {
            if (disc == Disc.None)
                throw new InvalidOperationException("You cannot remove a disc from a square.");
            if (IsFilled)
                throw new InvalidOperationException("You cannot put a disc in an already filled square.");

            Disc = disc;
        }

        public void FlipDisc()
        {
            if (IsEmpty)
                throw new InvalidOperationException("You cannot flip the disc of an empty square.");

            Disc = Disc.Flipped();
        }

        public bool IsEmpty => Disc == Disc.None;
        public bool IsFilled => !IsEmpty;

        public bool IsBlackFacingUp => Disc == Disc.BlackSideUp;
        public bool IsWhiteFacingUp => Disc == Disc.WhiteSideUp;

        public override string ToString()
        {
            return this switch
            {
                var s when s.IsEmpty => " ",
                var s when s.IsBlackFacingUp => "B",
                var s when s.IsWhiteFacingUp => "W",
                _ => "?"
            };
        }

        internal bool HasDisc(Disc disc)
            => Disc == disc;
    }
}
