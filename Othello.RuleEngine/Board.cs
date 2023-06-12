using Othello.ValueObjects;
using Othello.ValueObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Othello.RuleEngine
{
    public class Board
    {
        private readonly Dictionary<Position, Square> squares = new();
        public Dimension Dimension { get; init; }

        public Board(Dimension dimension)
        {
            Dimension = dimension;
            CreateEmptySquares();
            SetInitialState();
        }

        public Square this[Position position]
        {
            get
            {
                if (position is InvalidPosition invalid)
                    throw new InvalidPositionException(invalid);

                return squares[position];
            }
            private set
            {
                squares[position] = value;
            }
        }

        public void PlayerMakesMoveAt(ColorSide playerColor/*TODO: use player to determine side*/, Position position)
        {
            if (CountFilledSquaresAdjacentTo(position) == 0)
                throw new InvalidMoveException("Your disc must be adjacent to another one (vertically, horizontally or diagonally).");//TODO: create specific exception

            var square = this[position];
            var playerDisc = square.PlaceADiscWith(playerColor);

            var sandwichedOpponentDiscs = SearchOpponentDiscsSandwichedBy(playerDisc);
            if (sandwichedOpponentDiscs.Count == 0)
                throw new InvalidMoveException("You must sandwich at least one of your opponent's discs when placing your disc.");//TODO: create specific exception
            Flip(sandwichedOpponentDiscs);
        }

        private int CountFilledSquaresAdjacentTo(Position centralPosition)
        {
            var adjacentFilledPositions = Directions.All()
                .Select(centralPosition.NextPositionInDirection)       //
                .Where(position => IsPositionWithinBounds(position) && // TODO: create a simpler helper                                                                                                         
                    IsSquareFilledAt(position));                       //

            return adjacentFilledPositions.Count();
        }

        private bool IsSquareFilledAt(Position position)
            => this[position].HasDisc;

        private void Flip(IEnumerable<PlacedDisc> discs)
        {
            foreach (var disc in discs)
            {
                disc.Flip();
            }
        }

        private List<PlacedDisc> SearchOpponentDiscsSandwichedBy(PlacedDisc playerDisc)
        {
            return Directions.All()
                .Select(direction => SearchOpponentDiscsSandwichedInDirection(playerDisc, direction))
                .SelectMany(discs => discs)
                .ToList();
        }

        private IEnumerable<PlacedDisc> SearchOpponentDiscsSandwichedInDirection(PlacedDisc playerDisc, Direction direction)
        {
            var playerColor = playerDisc.ColorSideUp;
            var opponentColor = playerColor.GetOtherSide();

            var sandwichedOpponentDiscs = new List<PlacedDisc>();
            for (var position = playerDisc.InSquare.Position.NextPositionInDirection(direction); //TODO: simplify with a helper method
                IsPositionWithinBounds(position);
                position = position.NextPositionInDirection(direction))
            {
                var currentSquare = this[position];
                if (currentSquare.HasDiscWith(opponentColor))
                {
                    sandwichedOpponentDiscs.Add(currentSquare.Disc!);
                }
                else if (currentSquare.HasDiscWith(playerColor))
                {
                    return sandwichedOpponentDiscs;
                }
                else if (currentSquare.IsEmpty)
                {
                    return Enumerable.Empty<PlacedDisc>();
                }
            }

            return Enumerable.Empty<PlacedDisc>();
        }

        private bool IsPositionWithinBounds(Position position)
            => position.IsWithinBoundsOfBoardDimension(Dimension);

        private void CreateEmptySquares()
        {
            var squares = Position.AllPositionsForBoardDimension(Dimension)
                .Select(position => new Square(position));

            foreach (var square in squares)
            {
                this[square.Position] = square;
            }
        }

        private IEnumerable<Square> CenterWhiteSquares
        {
            get
            {
                yield return this[Dimension.CenterTopLeftPosition];
                yield return this[Dimension.CenterTopLeftPosition.NextPositionInDirection(Direction.SouthEast)];
            }
        }

        private IEnumerable<Square> CenterBlackSquares
        {
            get
            {
                yield return this[Dimension.CenterTopLeftPosition.NextPositionInDirection(Direction.East)];
                yield return this[Dimension.CenterTopLeftPosition.NextPositionInDirection(Direction.South)];
            }
        }

        private void SetInitialState()
        {
            foreach (var centerWhiteSquare in CenterWhiteSquares)
            {
                centerWhiteSquare.PlaceADiscWith(ColorSide.White);
            }

            foreach (var centerBlackSquare in CenterBlackSquares)
            {
                centerBlackSquare.PlaceADiscWith(ColorSide.Black);
            }
        }
    }
}
