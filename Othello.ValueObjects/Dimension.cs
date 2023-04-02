using Othello.ValueObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Othello.ValueObjects
{
    public record Dimension
    {
        public const sbyte MinDimensionAllowed = 2;
        public const sbyte DefaultDimension = 8;
        public const sbyte MaxDimensionAllowed = 10;

        public sbyte Length { get; init; }
        public Dimension(sbyte length = DefaultDimension) 
        {
            if (length < MinDimensionAllowed || length > MaxDimensionAllowed) throw new ArgumentOutOfRangeException(nameof(length));

            if (length % 2  != 0) throw new UnevenDimensionException();

            Length = length;
        }

        private sbyte HalfLength => (sbyte)(Length / 2);
        
        public IEnumerable<int> Indices => Enumerable.Range(1, Length);

        public Position CenterPosition => new(HalfLength, HalfLength);

        public static explicit operator Dimension(int length)
            => new(Convert.ToSByte(length));
    }
}
