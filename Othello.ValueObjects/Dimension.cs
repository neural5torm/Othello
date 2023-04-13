using Othello.ValueObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Othello.ValueObjects
{
    public record Dimension
    {
        private const sbyte MinDimensionAllowed = 2;
        private const sbyte DefaultDimension = 8;
        private const sbyte MaxDimensionAllowed = 10;

        public sbyte Length { get; init; }
        public Dimension(sbyte length) 
        {
            if (length < MinDimensionAllowed || length > MaxDimensionAllowed) 
                throw new ArgumentOutOfRangeException(nameof(length));

            if (length % 2  != 0) 
                throw new UnevenDimensionException($"Othello board cannot be of uneven dimension: {length}.");

            Length = length;
        }

        private sbyte HalfLength => (sbyte)(Length / 2);
        
        public IEnumerable<int> Indices => Enumerable.Range(1, Length);

        public Position CenterTopLeftPosition => new(HalfLength, HalfLength);

        public static explicit operator Dimension(int length)
            => new(Convert.ToSByte(length));

        /// <summary>
        /// The default 8x8 Othello board dimension
        /// </summary>
        public static Dimension Default
            => new (DefaultDimension);
    }
}
