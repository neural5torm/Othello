using System;
using Othello.ValueObjects;
using Othello.ValueObjects.Players;

namespace Othello.RuleEngine;

public class Game
{
    private readonly Board board;
    public Dimension BoardDimension =>
        board.Dimension;

    public Player FirstPlayer { get; }
    public Player SecondPlayer { get; }

    public Player CurrentPlayer { get; private set; }
    public Player CurrentOpponent =>
        CurrentPlayer == FirstPlayer ? SecondPlayer : FirstPlayer;

    public Game(Dimension dimension, Player firstPlayer, Player secondPlayer)
    {
        this.board = new Board(dimension);

        CurrentPlayer =
            FirstPlayer = firstPlayer;
        SecondPlayer = secondPlayer;
    }

    public void CurrentPlayerMakesMoveAt(Position position)
    {
        board.MakeMove(CurrentPlayer, position);
        ToggleCurrentPlayer();
    }

    public void CurrentPlayerPasses()
    {
        board.CheckPlayerCanPass(CurrentPlayer);
        ToggleCurrentPlayer();
    }

    public string ContentsOfSquareAt(Position position) =>
        board[position].ToString().Trim();

    private void ToggleCurrentPlayer()
    {
        CurrentPlayer = CurrentOpponent;
    }
}
