Feature: Create Othello board
	
Scenario: Creating an empty Othello board should display an 8x8 grid of empty squares
	When I create an empty Othello board
	Then the board should look like
	|   | a | b | c | d | e | f | g | h |
	| 1 |   |   |   |   |   |   |   |   |
	| 2 |   |   |   |   |   |   |   |   |
	| 3 |   |   |   |   |   |   |   |   |
	| 4 |   |   |   |   |   |   |   |   |
	| 5 |   |   |   |   |   |   |   |   |
	| 6 |   |   |   |   |   |   |   |   |
	| 7 |   |   |   |   |   |   |   |   |
	| 8 |   |   |   |   |   |   |   |   |

Scenario: Creating an initial Othello board should display an 8x8 grid of squares with its 2x2 center containing the initial black and white discs
	When I create an initial Othello board
	Then the board should look like
	|   | a | b | c | d | e | f | g | h |
	| 1 |   |   |   |   |   |   |   |   |
	| 2 |   |   |   |   |   |   |   |   |
	| 3 |   |   |   |   |   |   |   |   |
	| 4 |   |   |   | W | B |   |   |   |
	| 5 |   |   |   | B | W |   |   |   |
	| 6 |   |   |   |   |   |   |   |   |
	| 7 |   |   |   |   |   |   |   |   |
	| 8 |   |   |   |   |   |   |   |   |

