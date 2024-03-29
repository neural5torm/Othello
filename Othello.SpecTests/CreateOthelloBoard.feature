﻿Feature: Create Othello board
	
Scenario: Creating a standard initial Othello board should display an 8x8 grid of empty squares except for its 2x2 center containing the initial black and white discs
	Given a new game of Othello
	Then the board should be like this
	|   | a | b | c | d | e | f | g | h |
	| 1 |   |   |   |   |   |   |   |   |
	| 2 |   |   |   |   |   |   |   |   |
	| 3 |   |   |   |   |   |   |   |   |
	| 4 |   |   |   | W | B |   |   |   |
	| 5 |   |   |   | B | W |   |   |   |
	| 6 |   |   |   |   |   |   |   |   |
	| 7 |   |   |   |   |   |   |   |   |
	| 8 |   |   |   |   |   |   |   |   |

Scenario: Creating an initial 4x4 Othello board should display a 4x4 grid of empty squares except for its 2x2 center containing the initial black and white discs
	Given a new game of Othello with a 4x4 board
	Then the board should be like this
	|   | a | b | c | d |
	| 1 |   |   |   |   |
	| 2 |   | W | B |   |
	| 3 |   | B | W |   |
	| 4 |   |   |   |   |

Scenario: Creating an initial 2x2 Othello board should display a 2x2 grid containing the initial black and white discs
	Given a new game of Othello with a 2x2 board
	Then the board should be like this
	|   | a | b | 
	| 1 | W | B | 
	| 2 | B | W | 
	
Scenario: Creating a 10x10 initial Othello board should display a 10x10 grid of empty squares except for its 2x2 center containing the initial black and white discs
	Given a new game of Othello with a 10x10 board
	Then the board should be like this
	|    | a | b | c | d | e | f | g | h | i | j |
	| 1  |   |   |   |   |   |   |   |   |   |   |
	| 2  |   |   |   |   |   |   |   |   |   |   |
	| 3  |   |   |   |   |   |   |   |   |   |   |
	| 4  |   |   |   |   |   |   |   |   |   |   |
	| 5  |   |   |   |   | W | B |   |   |   |   |
	| 6  |   |   |   |   | B | W |   |   |   |   |
	| 7  |   |   |   |   |   |   |   |   |   |   |
	| 8  |   |   |   |   |   |   |   |   |   |   |
	| 9  |   |   |   |   |   |   |   |   |   |   |
	| 10 |   |   |   |   |   |   |   |   |   |   |
