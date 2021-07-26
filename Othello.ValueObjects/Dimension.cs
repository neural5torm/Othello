using System;

namespace Othello.ValueObjects
{
    public class Dimension
    {
        public const sbyte MinDimension = 2;
        public const sbyte MaxSideLength = 26;

        private readonly sbyte sideLength;

        public Dimension(int sideLength)
        {
            this.sideLength = MinDimension <= sideLength && sideLength <= MaxSideLength
                ? (sbyte)sideLength
                : throw new ArgumentOutOfRangeException(nameof(sideLength));
        }

        public static implicit operator int(Dimension dimension)
            => dimension.sideLength;

        public static implicit operator Dimension(sbyte sideLength)
            => new(sideLength);
    }
}
