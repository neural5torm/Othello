using System;

namespace Othello.ValueObjects
{
    public class Dimension
    {
        public const uint MinDimension = 2;
        public const uint MaxDimension = 26;

        private readonly uint sideLength;

        public Dimension(int sideLength)
        {
            this.sideLength = MinDimension <= sideLength && sideLength <= MaxDimension
                ? (uint)sideLength
                : throw new ArgumentOutOfRangeException(nameof(sideLength));
        }

        public static implicit operator int(Dimension dimension)
            => (int)dimension.sideLength;

        public static implicit operator Dimension(int sideLength)
            => new(sideLength);
    }
}
