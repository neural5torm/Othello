Feature: Create Othello board
	
Scenario: Creating a 10x10 initial Othello board should display a 10x10 grid of empty squares except for its 2x2 center containing the initial black and white discs
	When I create an initial 10x10 Othello board
	Then the board should look like
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

Scenario: Creating a standard initial Othello board should display an 8x8 grid of empty squares except for its 2x2 center containing the initial black and white discs
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

Scenario: Creating an initial 4x4 Othello board should display a 4x4 grid of empty squares except for its 2x2 center containing the initial black and white discs
	When I create an initial 4x4 Othello board
	Then the board should look like
	|   | a | b | c | d |
	| 1 |   |   |   |   |
	| 2 |   | W | B |   |
	| 3 |   | B | W |   |
	| 4 |   |   |   |   |

Scenario: Creating an initial 3x3 Othello board should display a 3x3 grid of empty squares except for its 2x2 top-left squares containing the initial black and white discs
	When I create an initial 3x3 Othello board
	Then the board should look like
	|   | a | b | c |
	| 1 | W | B |   |
	| 2 | B | W |   |
	| 3 |   |   |   |

Scenario: Creating an initial 2x2 Othello board should display a 2x2 grid containing the initial black and white discs
	When I create an initial 2x2 Othello board
	Then the board should look like
	|   | a | b | 
	| 1 | W | B | 
	| 2 | B | W | 
	