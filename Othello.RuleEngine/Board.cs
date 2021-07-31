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

        public void PlayMove(Disc disc, Position squarePosition)
        {
            if (CountAdjacentFilledSquares(squarePosition) == 0)
                throw new InvalidOperationException("You must place your disc directly next to another one (vertically, horizontally or diagonally).");

            var square = PlaceDisc(disc, squarePosition);

            if (FlipDiscsSandwichedByNewDisc(square) == 0)
                throw new InvalidOperationException("Your disc must sandwich at least one of your opponent's discs.");
        }

        private int CountAdjacentFilledSquares(Position squarePosition)
        {
            var adjacentFilledPositions = Directions.All()
                .Select(direction => squarePosition.NextPosition(direction))
                .Where(position => IsPositionValidOnBoard(position) &&
                    this[position!].IsFilled);

            return adjacentFilledPositions.Count();
        }

        private Square PlaceDisc(Disc disc, Position squarePosition)
        {
            var square = this[squarePosition];
            square.PlaceADisc(disc);
            return square;
        }

        private int FlipDiscsSandwichedByNewDisc(Square newDiscSquare)
        {
            var squaresOfSandwichedDiscs = SearchSquaresOfSandwichedDiscs(newDiscSquare);

            squaresOfSandwichedDiscs.ForEach(square =>
            {
                square.FlipDisc();
            });

            return squaresOfSandwichedDiscs.Count;
        }

        private List<Square> SearchSquaresOfSandwichedDiscs(Square newDiscSquare)
        {
            return Directions.All()
                .Select(direction => SearchSquaresOfSandwichedDiscs(newDiscSquare, direction))
                .SelectMany(squares => squares)
                .ToList();
        }

        private IEnumerable<Square> SearchSquaresOfSandwichedDiscs(Square newDiscSquare, Direction direction)
        {
            var playerDisc = newDiscSquare.Disc;
            var opponentDisc = playerDisc.Flipped();

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
                else if (evaluatedSquare.HasDisc(playerDisc))
                {
                    return squaresOfSandwichedDiscs;
                }
                else if (evaluatedSquare.IsEmpty)
                {
                    return Enumerable.Empty<Square>();
                }
            }

            return Enumerable.Empty<Square>();
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

        private IEnumerable<Square> CenterWhiteSquares
        {
            get
            {
                yield return this[dimension.CenterPosition];
                yield return this[dimension.CenterPosition.NextPosition(Direction.SouthEast)!];                
            }
        }

        private IEnumerable<Square> CenterBlackSquares
        {
            get
            {
                yield return this[dimension.CenterPosition.NextPosition(Direction.South)!];
                yield return this[dimension.CenterPosition.NextPosition(Direction.East)!];
            }
        }

        private void SetInitialState()
        {
            foreach (var centerWhiteSquare in CenterWhiteSquares)
            {
                centerWhiteSquare.PlaceADisc(Disc.WhiteSideUp);
            }

            foreach (var centerBlackSquare in CenterBlackSquares)
            {
                centerBlackSquare.PlaceADisc(Disc.BlackSideUp);
            }
        }
    }
}
