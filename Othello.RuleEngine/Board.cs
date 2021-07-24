using Othello.ValueObjects;
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
        }

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

        public void SetInitialState()
        {
            this["d4"].Put(Disc.WhiteSideUp);
            this["d5"].Put(Disc.BlackSideUp);

            this["e4"].Put(Disc.BlackSideUp);
            this["e5"].Put(Disc.WhiteSideUp);
        }
    }
}
