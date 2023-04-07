Feature: Prevent forbidden moves

Background: 
	Given an initial Othello board is created
	#|   | a | b | c | d | e | f | g | h |
	#| 1 |   |   |   |   |   |   |   |   |
	#| 2 |   |   |   |   |   |   |   |   |
	#| 3 |   |   |   |   |   |   |   |   |
	#| 4 |   |   |   | W | B |   |   |   |
	#| 5 |   |   |   | B | W |   |   |   |
	#| 6 |   |   |   |   |   |   |   |   |
	#| 7 |   |   |   |   |   |   |   |   |
	#| 8 |   |   |   |   |   |   |   |   |

Scenario: Cannot place a disc in any of the already filled square of the central 2x2 grid
	When <player> tries to place a disc in square <central position>
	Then an error is issued saying "You cannot place a disc in an already filled square."
	Examples: 
	| central position | player |
	| d4               | Black  |
	| d4               | White  |
	| d5               | Black  |
	| d5               | White  |
	| e4               | Black  |
	| e5               | White  |

Scenario: Cannot place a disc in a position that does not sandwich any opponent disc
	When <player> tries to place a disc in square <non-sandwiching position>
	Then an error is issued saying "You must sandwich at least one of your opponent's discs when placing your disc."
	Examples: 
	| non-sandwiching position | player |
	| c3                       | White  |
	| c4                       | White  |
	| c5                       | Black  |
	| c6                       | Black  |
	| d3                       | White  |
	| d6                       | Black  |
	| e3                       | Black  |
	| e6                       | White  |
	| f3                       | White  |
	| f4                       | Black  |
	| f5                       | White  |
	| f6                       | Black  |

Scenario: Cannot place a disc in a position that is not (8-way) adjacent to any disc
	When <player> tries to place a disc in square <non-adjacent position>
	Then an error is issued saying "You must place your disc adjacent to another one (vertically, horizontally or diagonally)."
	Examples: 
	| non-adjacent position | player |
	| a1                    | Black  |
	| b2                    | Black  |
	| c2                    | Black  |
	| d2                    | White  |
	| g4                    | White  |
	| h8                    | White  |

#TODO Alternate players 
#- check the same player does not play twice
#- check the player has a valid move (or should pass)
#- check end of game

#TODO Keep scores
#- check scores
#- check winner/loser