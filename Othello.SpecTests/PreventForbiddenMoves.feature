Feature: Prevent forbidden moves

Background: 
	Given an initial Othello board is created

Scenario: Cannot place a disc in any of the already filled square of the central 2x2 grid
	When <player> tries to place a disc in square <central position>
	Then an error is issued saying "You cannot put a disc in an already filled square."
	Examples: 
	| central position | player |
	| d4               | Black  |
	| d5               | Black  |
	| e4               | White  |
	| e5               | White  |

Scenario: Cannot place a disc in a position that does not sandwich any opponent disc
	When <player> tries to place a disc in square <invalid position>
	Then an error is issued saying "Your disc must sandwich at least one of your opponent's discs."
	Examples: 
	| invalid position | player |
	| c5               | Black  |
	| f4               | Black  |
	| c4               | White  |
	| f5               | White  |

Scenario: Cannot place a disc in a position that is not (8-way) adjacent to any disc
	When <player> tries to place a disc in square <invalid position>
	Then an error is issued saying "You must place your disc directly next to another one (vertically, horizontally or diagonally)."
	Examples: 
	| invalid position | player |
	| a1               | Black  |
	| d2               | Black  |
	| g4               | White  |
	| h8               | White  |

#TODO Alternate players 
#- check the same player does not play twice
#- check the player has a valid move (or should pass)
#- check end of game

#TODO Keep scores
#- check scores
#- check winner/loser