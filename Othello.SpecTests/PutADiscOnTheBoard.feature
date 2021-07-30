Feature: Put a disc on the board (4x4)

Background: 
	Given an initial 4x4 board is created

Scenario: Black places a disc in a2 on the initial board which should flip the sandwiched white disc in b2
	When Black places a disc in square a2 
	Then the board should look like
	|   | a | b | c | d |
	| 1 |   |   |   |   |
	| 2 | B | B | B |   |
	| 3 |   | B | W |   |
	| 4 |   |   |   |   |

Scenario: Second move by White on the initial 4x4 board 
	When Black places a disc in square a2 
	And White places a disc in square c1 
	Then the board should look like
	|   | a | b | c | d |
	| 1 |   |   | W |   |
	| 2 | B | B | W |   |
	| 3 |   | B | W |   |
	| 4 |   |   |   |   |
	
Scenario: Third move by Black on the initial 4x4 board 
	When Black places a disc in square a2 
	And White places a disc in square c1 
	And Black places a disc in square d2 
	Then the board should look like
	|   | a | b | c | d |
	| 1 |   |   | W |   |
	| 2 | B | B | B | B |
	| 3 |   | B | W |   |
	| 4 |   |   |   |   |
	
Scenario: Fourth move by White on the initial 4x4 board 
	When Black places a disc in square a2 
	And White places a disc in square c1 
	And Black places a disc in square d2 
	And White places a disc in square a3
	Then the board should look like
	|   | a | b | c | d |
	| 1 |   |   | W |   |
	| 2 | B | W | B | B |
	| 3 | W | W | W |   |
	| 4 |   |   |   |   |

Scenario: Fifth move by Black on the initial 4x4 board 
	When Black places a disc in square a2 
	And White places a disc in square c1 
	And Black places a disc in square d2 
	And White places a disc in square a3
	And Black places a disc in square a4
	Then the board should look like
	|   | a | b | c | d |
	| 1 |   |   | W |   |
	| 2 | B | W | B | B |
	| 3 | B | B | W |   |
	| 4 | B |   |   |   |

Scenario: Sixth move by White on the initial 4x4 board 
	When Black places a disc in square a2 
	And White places a disc in square c1 
	And Black places a disc in square d2 
	And White places a disc in square a3
	And Black places a disc in square a4
	And White places a disc in square b4
	Then the board should look like
	|   | a | b | c | d |
	| 1 |   |   | W |   |
	| 2 | B | W | B | B |
	| 3 | B | W | W |   |
	| 4 | B | W |   |   |

Scenario: 7th move by Black on the initial 4x4 board 
	When Black places a disc in square a2 
	And White places a disc in square c1 
	And Black places a disc in square d2 
	And White places a disc in square a3
	And Black places a disc in square a4
	And White places a disc in square b4
	And Black places a disc in square c4
	Then the board should look like
	|   | a | b | c | d |
	| 1 |   |   | W |   |
	| 2 | B | W | B | B |
	| 3 | B | B | B |   |
	| 4 | B | B | B |   |

Scenario: 8th move by White on the initial 4x4 board 
	When Black places a disc in square a2 
	And White places a disc in square c1 
	And Black places a disc in square d2 
	And White places a disc in square a3
	And Black places a disc in square a4
	And White places a disc in square b4
	And Black places a disc in square c4
	And White places a disc in square d4
	Then the board should look like
	|   | a | b | c | d |
	| 1 |   |   | W |   |
	| 2 | B | W | B | B |
	| 3 | B | B | W |   |
	| 4 | B | B | B | W |

Scenario: 9th move by Black on the initial 4x4 board 
	When Black places a disc in square a2 
	And White places a disc in square c1 
	And Black places a disc in square d2 
	And White places a disc in square a3
	And Black places a disc in square a4
	And White places a disc in square b4
	And Black places a disc in square c4
	And White places a disc in square d4
	And Black places a disc in square d3
	Then the board should look like
	|   | a | b | c | d |
	| 1 |   |   | W |   |
	| 2 | B | W | B | B |
	| 3 | B | B | B | B |
	| 4 | B | B | B | W |

Scenario: 10th move by White on the initial 4x4 board 
	When Black places a disc in square a2 
	And White places a disc in square c1 
	And Black places a disc in square d2 
	And White places a disc in square a3
	And Black places a disc in square a4
	And White places a disc in square b4
	And Black places a disc in square c4
	And White places a disc in square d4
	And Black places a disc in square d3
	And White places a disc in square d1
	Then the board should look like
	|   | a | b | c | d |
	| 1 |   |   | W | W |
	| 2 | B | W | B | W |
	| 3 | B | B | B | W |
	| 4 | B | B | B | W |

Scenario: 11th move by Black on the initial 4x4 board 
	When Black places a disc in square a2 
	And White places a disc in square c1 
	And Black places a disc in square d2 
	And White places a disc in square a3
	And Black places a disc in square a4
	And White places a disc in square b4
	And Black places a disc in square c4
	And White places a disc in square d4
	And Black places a disc in square d3
	And White places a disc in square d1
	And Black places a disc in square a1
	Then the board should look like
	|   | a | b | c | d |
	| 1 | B |   | W | W |
	| 2 | B | B | B | W |
	| 3 | B | B | B | W |
	| 4 | B | B | B | W |

Scenario: 12th move by White on the initial 4x4 board 
	When Black places a disc in square a2 
	And White places a disc in square c1 
	And Black places a disc in square d2 
	And White places a disc in square a3
	And Black places a disc in square a4
	And White places a disc in square b4
	And Black places a disc in square c4
	And White places a disc in square d4
	And Black places a disc in square d3
	And White places a disc in square d1
	And Black places a disc in square a1
	And White places a disc in square b1
	Then the board should look like
	|   | a | b | c | d |
	| 1 | B | W | W | W |
	| 2 | B | B | W | W |
	| 3 | B | B | B | W |
	| 4 | B | B | B | W |

Scenario: Placing a disc anywhere in the central 2x2 grid of the initial board should issue an error saying that the square is already filled
	When <player> tries to place a disc in square <central position>
	Then an error is issued saying "You cannot put a disc in an already filled square."
	Examples: 
	| central position | player |
	| b2               | Black  |
	| b3               | Black  |
	| c2               | White  |
	| c3               | White  |

#TODO check you cannot place a disc if it does not sandwich at least one disc of the opponent