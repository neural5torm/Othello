namespace Othello.ValueObjects
{
    public class InvalidPosition : Position
    {
        public InvalidPosition(sbyte invalidColumnIndex, sbyte invalidRowIndex) 
            : base(invalidColumnIndex, invalidRowIndex, checkValidIndices: false)
        { }
        public override string ToString()
           => $"c{ColumnIndex}:r{RowIndex}";

        public static explicit operator string(InvalidPosition position)
            => position.ToString();
    }
}
