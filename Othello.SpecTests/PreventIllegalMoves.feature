Feature: Prevent illegal moves
	# NB: initial 8x8 Othello board
	# |   | a | b | c | d | e | f | g | h |
	# | 1 |   |   |   |   |   |   |   |   |
	# | 2 |   |   |   |   |   |   |   |   |
	# | 3 |   |   |   |   |   |   |   |   |
	# | 4 |   |   |   | W | B |   |   |   |
	# | 5 |   |   |   | B | W |   |   |   |
	# | 6 |   |   |   |   |   |   |   |   |
	# | 7 |   |   |   |   |   |   |   |   |
	# | 8 |   |   |   |   |   |   |   |   |

	Scenario: Cannot place a Black disc in any of the already filled square of the central 2x2 grid
		Given a new game of Othello
		When Black tries to place a disc in square <central position>
		Then an error is issued saying "You cannot place a disc in an already filled square."
		Examples:
			| central position |
			| d4               |
			| d5               |
			| e4               |

	Scenario: Cannot place a White disc in any of the already filled square of the central 2x2 grid
		Given a new game of Othello
		And Black placed a disc in square e6
		When White tries to place a disc in square <central position>
		Then an error is issued saying "You cannot place a disc in an already filled square."
		Examples:
			| central position |
			| d4               |
			| d5               |
			| e5               |

	Scenario: Cannot place a Black disc in a position that does not sandwich any opponent disc
		Given a new game of Othello
		When Black tries to place a disc in square <non-sandwiching position>
		Then an error is issued saying "You must sandwich at least one of your opponent's discs when placing your disc."
		Examples:
			| non-sandwiching position |
			| c5                       |
			| c6                       |
			| d6                       |
			| e3                       |
			| f4                       |
			| f6                       |

	Scenario: Cannot place a White disc in a position that does not sandwich any opponent disc
		Given a new game of Othello
		And Black placed a disc in square c4
		When White tries to place a disc in square <non-sandwiching position>
		Then an error is issued saying "You must sandwich at least one of your opponent's discs when placing your disc."
		Examples:
			| non-sandwiching position |
			| b4                       |
			| d3                       |
			| e6                       |
			| f3                       |
			| f5                       |
			| f6                       |

	Scenario: Cannot place a Black disc in a position that is not (8-way) adjacent to any disc
		Given a new game of Othello
		When Black tries to place a disc in square <non-adjacent position>
		Then an error is issued saying "Your disc must be adjacent to another one (vertically, horizontally or diagonally)."
		Examples:
			| non-adjacent position |
			| a1                    |
			| b2                    |
			| c2                    |

	Scenario: Cannot place a White disc in a position that is not (8-way) adjacent to any disc
		Given a new game of Othello
		And Black placed a disc in square c4
		When White tries to place a disc in square <non-adjacent position>
		Then an error is issued saying "Your disc must be adjacent to another one (vertically, horizontally or diagonally)."
		Examples:
			| non-adjacent position |
			| d2                    |
			| g4                    |
			| h8                    |

	Scenario: White cannot make a valid move first (Black always plays first in Othello)
		Given I try a new game of Othello with White playing first and Black playing second
		Then an error is issued saying "Black must play first."

# Scenario: Current player cannot pass if he has at least one legal move

# Scenario: Current player can only play once if opponent has at least one legal move (exchange White+Black in test)

# Scenario: Player cannot place a disc if he has no legal move

#TODO Pass / Game over
# check player can pass and opponent can thus play twice
# check game is over if both players must pass twice in a row (+players can no longer place any disk)
# check game is over if board is full (+players can no longer place any disk)

#TODO Keeping scores
# check scores are updated after each move accordingly
# check winner has the most points, loser the least and tie is equal (+handicap? +add points for all remaining empty squares)