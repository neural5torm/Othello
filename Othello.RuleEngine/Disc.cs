using Othello.ValueObjects;

namespace Othello.RuleEngine
{
    public class Disc
    {
        public Color ColorFacingUp { get; private set; }

        public Disc(Color initialColorFacingUp)
        {
            ColorFacingUp = initialColorFacingUp;
        }

        public void Flip()
        {
            ColorFacingUp = ColorFacingUp == Color.Black
                ? Color.White
                : Color.Black;
        }
    }
}