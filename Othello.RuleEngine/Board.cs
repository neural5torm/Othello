﻿using Othello.ValueObjects;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Othello.RuleEngine
{
    public class Board
    {
        private readonly Dimension dimension;
        private readonly Dictionary<Position, Square> squares = new();

        public Board(Dimension dimension)
        {
            this.dimension = dimension;
            CreateEmptySquares();
            SetInitialState();
        }

        public Square this[Position position]
        {
            get
            {
                return squares[position];
            }
            private set
            {
                squares[position] = value;
            }
        }

        // TODO pass the player (for scores and turns)
        public void PlaceDiscInSquareForPlayer(Disc disc, Position squarePosition)
        {
            Square square = PlaceDiscInSquare(disc, squarePosition);
            FlipDiscsSandwichedByNewDisc(square);
        }

        private Square PlaceDiscInSquare(Disc disc, Position squarePosition)
        {
            var square = this[squarePosition];
            square.PlaceDisc(disc);
            return square;
        }

        private void FlipDiscsSandwichedByNewDisc(Square newDiscSquare)
        {
            List<Square> squaresOfSandwichedDiscs = SearchSquaresOfSandwichedDiscs(newDiscSquare);

            squaresOfSandwichedDiscs.ForEach(square =>
            {
                square.FlipDisc();
            });
        }

        private List<Square> SearchSquaresOfSandwichedDiscs(Square newDiscSquare)
        {
            var squaresOfSandwichedDiscs = new List<Square>();
            foreach (var direction in Directions.All())
            {
                squaresOfSandwichedDiscs.AddRange(
                    SearchSquaresOfSandwichedDiscs(newDiscSquare, direction));
            }

            return squaresOfSandwichedDiscs;
        }

        private IReadOnlyCollection<Square> SearchSquaresOfSandwichedDiscs(Square newDiscSquare, Direction direction)
        {
            var opponentDisc = newDiscSquare.Disc.Flipped();
            var squaresOfSandwichedDiscs = new List<Square>();

            for (var position = newDiscSquare.Position.NextPosition(direction); 
                position is not null && IsPositionValidOnBoard(position); 
                position = position.NextPosition(direction))
            {
                var evaluatedSquare = this[position];
                if (evaluatedSquare.HasDisc(opponentDisc))
                {
                    squaresOfSandwichedDiscs.Add(evaluatedSquare);
                }
                else
                {
                    return squaresOfSandwichedDiscs.ToImmutableArray();
                }
            }

            return new ImmutableArray<Square>();
        }

        private bool IsPositionValidOnBoard(Position? position)
            => position is not null && position.IsValidForDimension(dimension);

        private void CreateEmptySquares()
        {
            Position.AllPositionsForBoardDimension(dimension)
                .Select(position => new Square(position))
                .ToList()
                .ForEach(square =>
                {
                    squares[square.Position] = square;
                });
        }

        private void SetInitialState()
        {
            PlaceDiscInSquare(Disc.WhiteSideUp, "d4");
            PlaceDiscInSquare(Disc.BlackSideUp, "d5");

            PlaceDiscInSquare(Disc.BlackSideUp, "e4");
            PlaceDiscInSquare(Disc.WhiteSideUp, "e5");
        }
    }
}
