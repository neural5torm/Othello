using System;

namespace Othello.ValueObjects.Players;

public abstract class Player
{
    public ColorSide Color { get; set; }
    public virtual string Name => Color.ToString();

    public Player(ColorSide color)
    {
        Color = color;
    }
}
