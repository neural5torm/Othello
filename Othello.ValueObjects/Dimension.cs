using System;

namespace Othello.ValueObjects
{
    public record Dimension(sbyte Length)
    {
        public const sbyte MinDimension = 2;
        public const sbyte MaxDimension = 20;

        private sbyte Length { get; }
            = MinDimension <= Length && Length <= MaxDimension
            ? Length
            : throw new ArgumentOutOfRangeException(nameof(Length));

        private sbyte HalfLength => (sbyte)(Length / 2);
        
        public Position CenterPosition => new(HalfLength, HalfLength);

        public static implicit operator int(Dimension dimension)
            => dimension.Length;

        public static implicit operator Dimension(int length)
            => new(Convert.ToSByte(length));
    }
}
