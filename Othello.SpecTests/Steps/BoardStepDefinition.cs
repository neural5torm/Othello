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


        [Given(@"an initial board is created")]
        public void GivenAnInitialBoardIsCreated()
        {
            CreateInitialOthelloBoard();
        }


        [When(@"I create an initial Othello board")]
        public void WhenICreateAnInitialOthelloBoard()
        {
            CreateInitialOthelloBoard();
        }

        [When(@"Black places a disc in square (.{2})")]
        public void WhenBlackPlacesADiscInSquare(string position)
        {
            var board = GetBoard();
            board.PlaceDiscInSquareForPlayer(Disc.BlackSideUp, position);
        }

        [When(@"Black tries to place a disc in square (.{2})")]
        public void WhenBlackTriesToPlaceADiscInSquare(string position)
        {
            var board = GetBoard();

            try
            {
                board.PlaceDiscInSquareForPlayer(Disc.BlackSideUp, position);
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


        private void CreateInitialOthelloBoard()
        {
            var board = new Board(8);
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
