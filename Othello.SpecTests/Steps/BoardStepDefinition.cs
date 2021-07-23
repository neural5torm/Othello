using FluentAssertions;
using Othello.RuleEngine;
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
            var board = new Board(Dimensions.WithColumns(8).AndRows(8));

            scenarioContext.Add(BoardKey, board);
        }

        [Then(@"the board should look like")]
        public void ThenTheBoardShouldLookLike(Table table)
        {
            var board = scenarioContext.Get<Board>(BoardKey);

            board.Dimensions
                .RowCount
                .Should().Be(table.RowCount);

            board.Dimensions
                .ColumnCount
                .Should().Be(table.Rows[0].Values.Count - 1);
        }

    }
}
