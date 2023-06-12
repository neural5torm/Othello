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
        private const string CurrentGameKey = "game";
        private const string ErrorKey = "error";

        private readonly ScenarioContext scenarioContext;

        public BoardStepDefinition(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [Given(@"a new game of Othello")]
        public void GivenANewOthelloGame()
        {
            StartOthelloGame();
        }

        [Given(@"a new game of Othello with a (\d+)x(\d+) board")]
        public void GivenANewOthelloGameWithADimensionBoard(int dimension1, int dimension2)
        {
            dimension2.Should()
                .Be(dimension1, "only square Othello boards are allowed.");

            StartOthelloGame((Dimension)dimension1);
        }

        [Given(@"(Black|White|player) placed a disc in square ([a-z]\d)")]
        public void GivenPlayerPlacedADiscInSquare(string expectedPlayer, string position)
        {
            var game = GetCurrentGame();
            CheckPlayerIs(game.CurrentPlayer, expectedPlayer);

            game.CurrentPlayerMakesMoveAt((Position)position);
        }

        [When(@"(Black|White|player) places a disc in square ([a-z]\d)")]
        public void WhenPlayerPlacesADiscInSquarePosition(string expectedPlayer, string position)
        {
            var game = GetCurrentGame();
            CheckPlayerIs(game.CurrentPlayer, expectedPlayer);

            game.CurrentPlayerMakesMoveAt((Position)position);
        }

        [When(@"(Black|White|player) tries to place a disc in square ([a-z]\d)")]
        public void WhenPlayerTriesToPlaceADiscInSquarePosition(string expectedPlayer, string position)
        {
            var game = GetCurrentGame();
            CheckPlayerIs(game.CurrentPlayer, expectedPlayer);

            var validatedPosition = (Position)position;

            try
            {
                game.CurrentPlayerMakesMoveAt(validatedPosition);
            }
            catch (Exception e)
            {
                StoreError(e);
            }
        }


        [Then(@"the board should be like this")]
        public void ThenTheBoardShouldBeLikeThis(Table table)
        {
            var game = GetCurrentGame();

            foreach (var row in table.Rows)
            {
                var rowHeader = row[0];

                foreach (var columnHeader in table.Header.Skip(1))
                {
                    var expectedSquareContents = row[columnHeader];
                    string position = columnHeader + rowHeader;

                    var squareContents = game.ContentsOfSquareAt((Position)position);
                    squareContents
                        .Should()
                        .Be(expectedSquareContents,
                            $"{expectedSquareContents} disc is expected at {position}, not {squareContents ?? "-"}.");
                }
            }

            CheckNoError();
        }

        [Then(@"an error is issued saying ""(.*)""")]
        public void ThenAnErrorIsIssuedSaying(string errorMessage)
        {
            var error = TryGetError();
            error.Should()
                .NotBeNull("the error was probably not raised.");

            error!.Message
                .Should()
                .Be(errorMessage);
        }

        private void StartOthelloGame(Dimension? dimension = null)
        {
            var game = new Game(dimension ?? Dimension.Default, new HumanPlayer(ColorSide.Black), new HumanPlayer(ColorSide.White));

            scenarioContext.Add(CurrentGameKey, game);
        }

        private Game GetCurrentGame()
        {
            return scenarioContext.Get<Game>(CurrentGameKey);
        }

        private static ColorSide? GetColorOf(string player)
        {
            return player.ToLower() switch
            {
                "black" => ColorSide.Black,
                "white" => ColorSide.White,
                _ => null
            };
        }

        private void StoreError(Exception e)
        {
            scenarioContext.Add(ErrorKey, e);
        }
        private Exception? TryGetError()
        {
            if (!scenarioContext.ContainsKey(ErrorKey))
                return null;

            return scenarioContext.Get<Exception>(ErrorKey);
        }

        private static void CheckPlayerIs(Player currentPlayer, string expectedPlayer)
        {
            var expectedPlayerColor = GetColorOf(expectedPlayer);
            if (expectedPlayerColor.HasValue)
            {
                currentPlayer.Color
                    .Should()
                    .Be(expectedPlayerColor.Value);
            }
        }

        private void CheckNoError()
        {
            scenarioContext.ContainsKey(ErrorKey)
                .Should()
                .BeFalse();
        }

    }
}
