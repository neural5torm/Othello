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

        [Given(@"an initial (.+x.+) board is created")]
        public void GivenAnInitialBoardIsCreated(string dimensions)
        {
            int dimension = int.Parse(dimensions.Split("x").First());
            CreateInitialBoard(dimension);
        }


        [When(@"I create an initial Othello board")]
        public void WhenICreateAnInitialOthelloBoard()
        {
            CreateInitialBoard();
        }

        [When(@"I create an initial (.+x.+) board")]
        public void WhenICreateAnInitialBoard(string dimensions)
        {
            int dimension = int.Parse(dimensions.Split("x").First());
            CreateInitialBoard(dimension);
        }


        [When(@"(Black|White) places a disc in square (.{2})")]
        public void WhenBlackPlacesADiscInSquare(string player, string position)
        {
            var board = GetBoard();
            var disc = player switch
            {
                "Black" => Disc.BlackSideUp,
                "White" => Disc.WhiteSideUp,
                _ => Disc.None
            };

            board.PlayMove(disc, position);
        }

        [When(@"Black tries to place a disc in square (.{2})")]
        public void WhenBlackTriesToPlaceADiscInSquare(string position)
        {
            var board = GetBoard();

            try
            {
                board.PlayMove(Disc.BlackSideUp, position);
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


        private void CreateInitialBoard(int dimension = 8)
        {
            var board = new Board(dimension);
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
