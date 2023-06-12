using System;

namespace Othello.ValueObjects.Players;

public class HumanPlayer : Player
{
    public HumanPlayer(ColorSide color) : base(color) { }
}
