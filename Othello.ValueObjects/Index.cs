﻿using System;
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
            => Convert.ToSByte(columnName
                .Trim()
                .ToLower()
                .Single() - MinColumnName + MinIndex);

        public static string ToColumnName(this sbyte columnIndex)
            => Convert.ToChar(MinColumnName + columnIndex - MinIndex)
                .ToString();
    }
}