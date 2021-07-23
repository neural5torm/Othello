Feature: Create Othello board
	
Background: none

Scenario: Creating an empty Othello board should display an 8x8 grid of empty squares
	When I create an empty Othello board
	Then the board should look like
	|   | A | B | C | D | E | F | G | H |
	| 1 |   |   |   |   |   |   |   |   |
	| 2 |   |   |   |   |   |   |   |   |
	| 3 |   |   |   |   |   |   |   |   |
	| 4 |   |   |   |   |   |   |   |   |
	| 5 |   |   |   |   |   |   |   |   |
	| 6 |   |   |   |   |   |   |   |   |
	| 7 |   |   |   |   |   |   |   |   |
	| 8 |   |   |   |   |   |   |   |   |