using Othello.ValueObjects;
using System;
using System.Collections.Generic;
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

        public void PlayerMakesMoveAt(Side playerSide/*TODO: use player to determine side*/, Position position)
        {
            if (CountFilledSquaresAdjacentTo(position) == 0)
                throw new InvalidOperationException("You must place your disc directly next to another one (vertically, horizontally or diagonally).");

            var square = this[position];
            var playerDisc = square.PlaceADiscOnSide(playerSide);

            var sandwichedOpponentDiscs = SearchOpponentDiscsSandwichedBy(playerDisc);
            if (sandwichedOpponentDiscs.Count == 0)
                throw new InvalidOperationException("You must sandwich at least one of your opponent's discs when placing your disc.");
            Flip(sandwichedOpponentDiscs);
        }

        private int CountFilledSquaresAdjacentTo(Position centralPosition)
        {
            var adjacentFilledPositions = Directions.All()
                .Select(centralPosition.NextPositionInDirection)      //
                .Where(position => position is not InvalidPosition && // TODO: create a simpler helper
                    IsPositionWithinBounds(position) &&               // 
                    IsSquareFilledAt(position));

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
            var playerSide = playerDisc.Side;
            var opponentSide = playerSide.GetOppositeSide();

            var sandwichedOpponentDiscs = new List<PlacedDisc>();
            for (var position = playerDisc.InSquare.Position.NextPositionInDirection(direction);//TODO: simplify with a helper method
                position is not InvalidPosition && IsPositionWithinBounds(position);//TODO: idem
                position = position.NextPositionInDirection(direction))
            {
                var currentSquare = this[position];
                if (currentSquare.HasDiscWithSideUp(opponentSide))
                {
                    sandwichedOpponentDiscs.Add(currentSquare.Disc!);
                }
                else if (currentSquare.HasDiscWithSideUp(playerSide))
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
            => position.IsValidForDimension(dimension);

        private void CreateEmptySquares()
        {
            var squares = Position.AllPositionsForBoardDimension(dimension)
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
                yield return this[dimension.CenterPosition];
                yield return this[dimension.CenterPosition.NextPositionInDirection(Direction.SouthEast)];
            }
        }

        private IEnumerable<Square> CenterBlackSquares
        {
            get
            {
                yield return this[dimension.CenterPosition.NextPositionInDirection(Direction.South)];
                yield return this[dimension.CenterPosition.NextPositionInDirection(Direction.East)];
            }
        }

        private void SetInitialState()
        {
            foreach (var centerWhiteSquare in CenterWhiteSquares)
            {
                centerWhiteSquare.PlaceADiscOnSide(Side.White);
            }

            foreach (var centerBlackSquare in CenterBlackSquares)
            {
                centerBlackSquare.PlaceADiscOnSide(Side.Black);
            }
        }
    }
}
