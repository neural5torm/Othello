using Othello.ValueObjects;

namespace Othello.RuleEngine
{
    public class PlacedDisc
    {
        public Square InSquare { get; init; }
        public ColorSide ColorSideUp { get; private set; }

        public PlacedDisc(Square inSquare, ColorSide colorSideUp)
        {
            InSquare = inSquare;
            ColorSideUp = colorSideUp;
        }

        public bool IsBlackSideUp => ColorSideUp == ColorSide.Black;
        public bool IsWhiteSideUp => ColorSideUp == ColorSide.White;

        internal void Flip()
        {
            ColorSideUp = ColorSideUp.GetOtherSide();
        }
    }
}
