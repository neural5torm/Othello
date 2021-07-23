using Othello.ValueObjects;

namespace Othello.RuleEngine
{
    public class Board
    {
        public Dimensions Dimensions { get; }

        public Board(Dimensions dimensions)
        {
            Dimensions = dimensions;
        }
    }
}
