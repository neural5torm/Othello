using System.Linq;

namespace Othello.ValueObjects
{
    internal static class Index
    {
        private const char MinColumnName = 'a';
        private const char MaxColumnName = 'z';

        public const sbyte MinIndex = 1;
        public const sbyte MaxIndex = MaxColumnName - MinColumnName + MinIndex;

        public static sbyte ToColumnIndex(this string columnName)
            => (sbyte)(columnName.Trim().ToLower().Single() - MinColumnName + MinIndex);

        public static string ToColumnName(this sbyte columnIndex)
            => ((char)(MinColumnName + columnIndex - MinIndex)).ToString();
    }
}
