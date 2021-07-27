Feature: Put a disc on the board

Scenario: Black places a disc in c4 on the initial board which should flip the sandwiched white disc in d4
	Given an initial 4x4 board is created
	When Black places a disc in square a2 
	Then the board should look like
	|   | a | b | c | d |
	| 1 |   |   |   |   |
	| 2 | B | B | B |   |
	| 3 |   | B | W |   |
	| 4 |   |   |   |   |

Scenario: Black in a2, White in c1 on the initial 4x4 board 
	Given an initial 4x4 board is created
	When Black places a disc in square a2 
	And White places a disc in square c1 
	Then the board should look like
	|   | a | b | c | d |
	| 1 |   |   | W |   |
	| 2 | B | B | W |   |
	| 3 |   | B | W |   |
	| 4 |   |   |   |   |
	
#TODO make more moves (with more than one sandwiched disc)

Scenario: Placing a black disc anywhere in the central 2x2 grid of the initial board should issue an error saying that the square is already filled
#TODO 4 examples
	Given an initial Othello board is created
	When Black tries to place a disc in square d4 
	Then an error is issued saying "You cannot put a disc in an already filled square."

#TODO check you cannot place a disc if it does not sandwich at least one disc of the opponent