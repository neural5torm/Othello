using FluentAssertions;
using Othello.RuleEngine;
using Othello.SpecTests.Extensions;
using Othello.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Othello.SpecTests.Steps
{
    [Binding]
    public sealed class BoardStepDefinition
    {
        private const string BoardKey = "board";

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext scenarioContext;

        public BoardStepDefinition(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [When(@"I create an empty Othello board")]
        public void WhenICreateAnEmptyOthelloBoard()
        {
            var board = new Board(8);

            scenarioContext.Add(BoardKey, board);
        }

        [When(@"I create an initial Othello board")]
        public void WhenICreateAnInitialOthelloBoard()
        {
            var board = new Board(8);

            board.SetInitialState();

            scenarioContext.Add(BoardKey, board);
        }

        [Then(@"the board should look like")]
        public void ThenTheBoardShouldLookLike(Table table)
        {
            var board = scenarioContext.Get<Board>(BoardKey);

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
        }
    }
}
