using System;
using System.Linq;

namespace Othello.ValueObjects
{
    internal static class IndexExtensions
    {
        private const char MinColumnName = 'a';
        private const char MaxColumnName = 'z';

        internal const sbyte MinIndex = 1;
        internal const sbyte MaxIndex = MaxColumnName - MinColumnName + MinIndex;

        internal static sbyte ToColumnIndex(this string columnName)
            => Convert.ToSByte(columnName
                .Trim()
                .ToLower()
                .Single() - MinColumnName + MinIndex);

        internal static string ToColumnName(this sbyte columnIndex)
            => Convert.ToChar(MinColumnName + columnIndex - MinIndex)
                .ToString();
    }
}
