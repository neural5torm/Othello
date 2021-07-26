Feature: Put a disc on the board

Background: 
	Given an initial board is created

#TODO use smaller 4x4 board
Scenario: Black places a disc in c4 on the initial board which should flip the sandwiched white disc in d4
	When Black places a disc in square c4 
	Then the board should look like
	|   | a | b | c | d | e | f | g | h |
	| 1 |   |   |   |   |   |   |   |   |
	| 2 |   |   |   |   |   |   |   |   |
	| 3 |   |   |   |   |   |   |   |   |
	| 4 |   |   | B | B | B |   |   |   |
	| 5 |   |   |   | B | W |   |   |   |
	| 6 |   |   |   |   |   |   |   |   |
	| 7 |   |   |   |   |   |   |   |   |
	| 8 |   |   |   |   |   |   |   |   |

#TODO make more moves (with more than one sandwiched disc)

Scenario: Placing a black disc anywhere in the central 2x2 grid of the initial board should issue an error saying that the square is already filled
#TODO 4 examples
	When Black tries to place a disc in square d4 
	Then an error is issued saying "You cannot put a disc in an already filled square."

#TODO check you cannot place a disc if it does not sandwich at least one disc of the opponent