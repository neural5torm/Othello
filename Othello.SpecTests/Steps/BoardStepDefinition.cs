using FluentAssertions;
using Othello.RuleEngine;
using Othello.ValueObjects;
using Othello.ValueObjects.Players;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Othello.SpecTests.Steps
{
    [Binding]
    public sealed class BoardStepDefinition
    {
        private Game? CurrentGame;
        private Exception? ErrorIssued;

        [Given(@"a new game of Othello")]
        public void GivenANewOthelloGame()
        {
            StartOthelloGame();
        }

        [Given(@"a new game of Othello with a (\d+)x(\d+) board")]
        public void GivenANewGameOfOthelloWithADimensionBoard(int dimension1, int dimension2)
        {
            dimension2.Should()
                .Be(dimension1, "only square Othello boards are allowed.");

            StartOthelloGame((Dimension)dimension1);
        }

        [Given(@"I try a new game of Othello with (White|Black) playing first and (Black|White) playing second")]
        public void GivenITryANewGameOfOthelloWithPlayerPlayingFirstAndPlayerPlayingSecond(string firstPlayer, string secondPlayer)
        {
            try
            {
                StartOthelloGame(new HumanPlayer(GetColorFor(firstPlayer)), new HumanPlayer(GetColorFor(secondPlayer)));
            }
            catch (Exception e)
            {
                StoreError(e);
            }
        }

        [Given(@"(Black|White|player) placed a disc in square ([a-z]\d)")]
        public void GivenPlayerPlacedADiscInSquare(string expectedPlayer, string position)
        {
            var currentGame = GetCurrentGame();

            CheckPlayerIs(currentGame.CurrentPlayer, expectedPlayer);

            currentGame.CurrentPlayerMakesMoveAt((Position)position);
        }

        [When(@"(Black|White|player) places a disc in square ([a-z]\d)")]
        public void WhenPlayerPlacesADiscInSquarePosition(string expectedPlayer, string position)
        {
            var currentGame = GetCurrentGame();
            CheckPlayerIs(currentGame.CurrentPlayer, expectedPlayer);

            currentGame.CurrentPlayerMakesMoveAt((Position)position);
        }

        [When(@"(Black|White|player) tries to place a disc in square ([a-z]\d)")]
        public void WhenPlayerTriesToPlaceADiscInSquarePosition(string expectedPlayer, string position)
        {
            var currentGame = GetCurrentGame();

            CheckPlayerIs(currentGame.CurrentPlayer, expectedPlayer);

            var validatedPosition = (Position)position;

            try
            {
                currentGame.CurrentPlayerMakesMoveAt(validatedPosition);
            }
            catch (Exception e)
            {
                StoreError(e);
            }
        }


        [Then(@"the board should be like this")]
        public void ThenTheBoardShouldBeLikeThis(Table table)
        {
            var currentGame = GetCurrentGame();

            foreach (var row in table.Rows)
            {
                var rowHeader = row[0];

                foreach (var columnHeader in table.Header.Skip(1))
                {
                    var expectedSquareContents = row[columnHeader].Length > 0 ? row[columnHeader] : " ";
                    string position = columnHeader + rowHeader;

                    var squareContents = currentGame.ContentsOfSquareAt((Position)position);
                    squareContents
                        .Should()
                        .Be(expectedSquareContents,
                            $"there's a {expectedSquareContents.Replace(" ", "blank")} at {position}");
                }
            }

            CheckNoErrorIssued();
        }

        [Then(@"an error is issued saying ""(.*)""")]
        public void ThenAnErrorIsIssuedSaying(string errorMessage)
        {
            ErrorIssued.Should()
                .NotBeNull("an exception should have been raised (but wasn't)");

            ErrorIssued!.Message
                .Should()
                .Be(errorMessage);

            ResetError();
        }

        private void StartOthelloGame(Dimension? dimension = null)
        {
            StartOthelloGame(dimension ?? Dimension.Default, new HumanPlayer(ColorSide.Black), new HumanPlayer(ColorSide.White));
        }

        private void StartOthelloGame(Player firstPlayer, Player secondPlayer)
        {
            StartOthelloGame(Dimension.Default, firstPlayer, secondPlayer);
        }

        private void StartOthelloGame(Dimension dimension, Player firstPlayer, Player secondPlayer)
        {
            CurrentGame = new Game(dimension ?? Dimension.Default, firstPlayer, secondPlayer);
        }

        private static ColorSide GetColorFor(string player)
        {
            var color = TryGetColorFor(player);
            return color ?? throw new ArgumentException("Invalid color for player: use Black or White (case invariant).", nameof(player));
        }

        private static ColorSide? TryGetColorFor(string player)
        {
            return player.ToLower() switch
            {
                "black" => ColorSide.Black,
                "white" => ColorSide.White,
                _ => null
            };
        }

        private Game GetCurrentGame()
        {
            //TODO handle error when game setup step is missing
            return CurrentGame!;
        }

        private void ResetError()
        {
            ErrorIssued = null;
        }

        private void StoreError(Exception e)
        {
            if (ErrorIssued != null)
                throw new SpecFlowException("A previous exception was caught but not handled.");
            ErrorIssued = e;
        }

        private void CheckNoErrorIssued()
        {
            ErrorIssued.Should()
                .BeNull();
        }

        private static void CheckPlayerIs(Player currentPlayer, string expectedPlayer)
        {
            var expectedPlayerColor = TryGetColorFor(expectedPlayer);
            if (expectedPlayerColor.HasValue)
            {
                currentPlayer.Color
                    .Should()
                    .Be(expectedPlayerColor.Value, $"a {expectedPlayer} player was specified instead of the game state's {currentPlayer.Color} current player (");
            }
        }
    }
}
