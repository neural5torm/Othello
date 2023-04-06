using FluentAssertions;
using Othello.RuleEngine;
using Othello.SpecTests.Extensions;
using Othello.ValueObjects;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Othello.SpecTests.Steps
{
    [Binding]
    public sealed class BoardStepDefinition
    {
        private const string BoardKey = "board";
        private const string ErrorKey = "error";

        private readonly ScenarioContext scenarioContext;

        public BoardStepDefinition(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [Given(@"an initial Othello board is created")]
        public void GivenAnInitialOthelloBoardIsCreated()
        {
            CreateInitialBoard();
        }

        [Given(@"an initial (.+)x(?:.+) board is created")]
        public void GivenAnInitialBoardIsCreated(string dimensionToParse)
        {
            int dimension = int.Parse(dimensionToParse);
            CreateInitialBoard(dimension);
        }

        [Given(@"(Black|White) placed a disc in square (.{2})")]
        public void GivenPlayerPlacedADiscInSquare(string player, string position)
        {
            var board = GetBoard();
            Disc disc = DiscOfPlayer(player);

            board.PlayMove(disc, position);
        }

        [When(@"I create an initial Othello board")]
        public void WhenICreateAnInitialOthelloBoard()
        {
            CreateInitialBoard();
        }

        [When(@"I create an initial (.+)x(?:.+) board")]
        public void WhenICreateAnInitialBoard(string dimensionToParse)
        {
            int dimension = int.Parse(dimensionToParse);
            CreateInitialBoard(dimension);
        }

        [When(@"(Black|White) places a disc in square (.{2})")]
        public void WhenPlayerPlacesADiscInSquare(string player, string position)
        {
            var board = GetBoard();
            Disc disc = DiscOfPlayer(player);

            board.PlayMove(disc, position);
        }

        [When(@"(.+) tries to place a disc in square (.+)")]
        public void WhenPlayerTriesToPlaceADiscInSquare(string player, string position)
        {
            var board = GetBoard();
            var disc = DiscOfPlayer(player);

            try
            {
                board.PlayMove(disc, position);
            }
            catch (Exception e)
            {
                StoreError(e);
            }
        }


        [Then(@"the board should look like")]
        public void ThenTheBoardShouldLookLike(Table table)
        {
            var board = GetBoard();

            foreach (var row in table.Rows)
            {
                var rowHeader = row[0];

                foreach (var columnHeader in table.Header.Skip(1))
                {
                    var expectedDisc = row[columnHeader].ToDisc();
                    string position = columnHeader + rowHeader;

                    board[position]
                        .Disc
                        .Should()
                        .Be(expectedDisc, $"{expectedDisc} disc is expected at {position}");
                }
            }

            CheckNoError();
        }

        [Then(@"an error is issued saying ""(.*)""")]
        public void ThenAnErrorIsIssuedSaying(string errorMessage)
        {
            var error = GetError();
            error.Message
                .Should()
                .Be(errorMessage);
        }


        private static Disc DiscOfPlayer(string player)
        {
            return player switch
            {
                "Black" => Disc.BlackSideUp,
                "White" => Disc.WhiteSideUp,
                _ => Disc.None
            };
        }

        private void CreateInitialBoard()
        {
            var board = new Board(Dimension.Default);
            scenarioContext.Add(BoardKey, board);
        }
        private void CreateInitialBoard(int dimension)
        {
            var board = new Board((Dimension)dimension);
            scenarioContext.Add(BoardKey, board);
        }
        private Board GetBoard()
        {
            return scenarioContext.Get<Board>(BoardKey);
        }

        private void StoreError(Exception e)
        {
            scenarioContext.Add(ErrorKey, e);
        }
        private Exception GetError()
        {
            if (!scenarioContext.ContainsKey(ErrorKey))
                throw new SpecFlowException("No error was raised.");

            return scenarioContext.Get<Exception>(ErrorKey);
        }
        private void CheckNoError()
        {
            scenarioContext.ContainsKey(ErrorKey)
                .Should()
                .BeFalse();
        }

    }
}
