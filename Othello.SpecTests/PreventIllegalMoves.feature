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

	Scenario: Cannot place a disc in a position that does not sandwich any opponent disc
		Given a new game of Othello
		When <player> tries to place a disc in square <non-sandwiching position>
		Then an error is issued saying "You must sandwich at least one of your opponent's discs when placing your disc."
		Examples:
			| non-sandwiching position | player |
			# | c3                       | White  |
			# | c4                       | White  |
			| c5                       | Black  |
			| c6                       | Black  |
			# | d3                       | White  |
			| d6                       | Black  |
			| e3                       | Black  |
			# | e6                       | White  |
			# | f3                       | White  |
			| f4                       | Black  |
			# | f5                       | White  |
			| f6                       | Black  |
	#TODO white cases

	Scenario: Cannot place a disc in a position that is not (8-way) adjacent to any disc
		Given a new game of Othello
		When <player> tries to place a disc in square <non-adjacent position>
		Then an error is issued saying "Your disc must be adjacent to another one (vertically, horizontally or diagonally)."
		Examples:
			| non-adjacent position | player |
			| a1                    | Black  |
			| b2                    | Black  |
			| c2                    | Black  |
	# | d2                    | White  |
	# | g4                    | White  |
	# | h8                    | White  |
	#TODO white cases


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