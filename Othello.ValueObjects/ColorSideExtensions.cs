using System;

namespace Othello.ValueObjects
{
    public static class ColorSideExtensions
    {
        public static ColorSide GetOtherSide(this ColorSide colorSide)
            => colorSide switch
            {
                ColorSide.Black => ColorSide.White,
                ColorSide.White => ColorSide.Black,

                _ => throw new NotSupportedException(colorSide.ToString())
            };
    }
}