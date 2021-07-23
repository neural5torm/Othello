namespace Othello.ValueObjects
{
    public class Dimensions
    {
        public int ColumnCount { get; }
        public int RowCount { get; }

        internal Dimensions(int columnCount, int rowCount)
        {
            ColumnCount = columnCount;
            RowCount = rowCount;
        }

        static public DimensionsBuilder WithColumns(int columnCount)
        {
            return new(columnCount);
        }
    }

    public class DimensionsBuilder
    {
        private readonly int columnCount;

        internal DimensionsBuilder(int columnCount)
        {
            this.columnCount = columnCount;
        }

        public Dimensions AndRows(int rowCount)
        {
            return new Dimensions(columnCount, rowCount);
        }
    }
}