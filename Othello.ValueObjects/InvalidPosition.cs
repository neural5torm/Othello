namespace Othello.ValueObjects
{
    public class InvalidPosition : Position
    {
        public InvalidPosition(sbyte column, sbyte row) : base(column, row, checkValidIndices: false)
        { }
        public override string ToString()
           => $"c{Column}:r{Row}";

        public static explicit operator string(InvalidPosition position)
            => position.ToString();
    }
}
