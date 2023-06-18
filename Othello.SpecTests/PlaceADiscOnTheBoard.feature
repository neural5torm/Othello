Feature: Place a disc on the board (4x4)

	Background:
		Given a new game of Othello with a 4x4 board

	Scenario: First move: Black places a disc in a2 on the initial board which should flip the sandwiched white disc in b2
		When Black places a disc in square a2
		Then the board should be like this
			|   | a | b | c | d |
			| 1 |   |   |   |   |
			| 2 | B | B | B |   |
			| 3 |   | B | W |   |
			| 4 |   |   |   |   |

	Scenario: Second move by White on the previous 4x4 board
		Given Black placed a disc in square a2
		When White places a disc in square c1
		Then the board should be like this
			|   | a | b | c | d |
			| 1 |   |   | W |   |
			| 2 | B | B | W |   |
			| 3 |   | B | W |   |
			| 4 |   |   |   |   |

	Scenario: Third move by Black on the previous 4x4 board
		Given Black placed a disc in square a2
		And White placed a disc in square c1
		When Black places a disc in square d2
		Then the board should be like this
			|   | a | b | c | d |
			| 1 |   |   | W |   |
			| 2 | B | B | B | B |
			| 3 |   | B | W |   |
			| 4 |   |   |   |   |

	Scenario: 4th move by White on the previous 4x4 board
		Given Black placed a disc in square a2
		And White placed a disc in square c1
		And Black placed a disc in square d2
		When White places a disc in square a3
		Then the board should be like this
			|   | a | b | c | d |
			| 1 |   |   | W |   |
			| 2 | B | W | B | B |
			| 3 | W | W | W |   |
			| 4 |   |   |   |   |

	Scenario: 5th move by Black on the previous 4x4 board
		Given Black placed a disc in square a2
		And White placed a disc in square c1
		And Black placed a disc in square d2
		And White placed a disc in square a3
		When Black places a disc in square a4
		Then the board should be like this
			|   | a | b | c | d |
			| 1 |   |   | W |   |
			| 2 | B | W | B | B |
			| 3 | B | B | W |   |
			| 4 | B |   |   |   |

	Scenario: 6th move by White on the previous 4x4 board
		Given Black placed a disc in square a2
		And White placed a disc in square c1
		And Black placed a disc in square d2
		And White placed a disc in square a3
		And Black placed a disc in square a4
		When White places a disc in square b4
		Then the board should be like this
			|   | a | b | c | d |
			| 1 |   |   | W |   |
			| 2 | B | W | B | B |
			| 3 | B | W | W |   |
			| 4 | B | W |   |   |

	Scenario: 7th move by Black on the previous 4x4 board
		Given Black placed a disc in square a2
		And White placed a disc in square c1
		And Black placed a disc in square d2
		And White placed a disc in square a3
		And Black placed a disc in square a4
		And White placed a disc in square b4
		When Black places a disc in square c4
		Then the board should be like this
			|   | a | b | c | d |
			| 1 |   |   | W |   |
			| 2 | B | W | B | B |
			| 3 | B | B | B |   |
			| 4 | B | B | B |   |

	Scenario: 8th move by White on the previous 4x4 board
		Given Black placed a disc in square a2
		And White placed a disc in square c1
		And Black placed a disc in square d2
		And White placed a disc in square a3
		And Black placed a disc in square a4
		And White placed a disc in square b4
		And Black placed a disc in square c4
		When White places a disc in square d4
		Then the board should be like this
			|   | a | b | c | d |
			| 1 |   |   | W |   |
			| 2 | B | W | B | B |
			| 3 | B | B | W |   |
			| 4 | B | B | B | W |

	Scenario: 9th move by Black on the previous 4x4 board
		Given Black placed a disc in square a2
		And White placed a disc in square c1
		And Black placed a disc in square d2
		And White placed a disc in square a3
		And Black placed a disc in square a4
		And White placed a disc in square b4
		And Black placed a disc in square c4
		And White placed a disc in square d4
		When Black places a disc in square d3
		Then the board should be like this
			|   | a | b | c | d |
			| 1 |   |   | W |   |
			| 2 | B | W | B | B |
			| 3 | B | B | B | B |
			| 4 | B | B | B | W |

	Scenario: 10th move by White on the previous 4x4 board
		Given Black placed a disc in square a2
		And White placed a disc in square c1
		And Black placed a disc in square d2
		And White placed a disc in square a3
		And Black placed a disc in square a4
		And White placed a disc in square b4
		And Black placed a disc in square c4
		And White placed a disc in square d4
		And Black placed a disc in square d3
		When White places a disc in square d1
		Then the board should be like this
			|   | a | b | c | d |
			| 1 |   |   | W | W |
			| 2 | B | W | B | W |
			| 3 | B | B | B | W |
			| 4 | B | B | B | W |

	Scenario: 11th move by Black on the previous 4x4 board
		Given Black placed a disc in square a2
		And White placed a disc in square c1
		And Black placed a disc in square d2
		And White placed a disc in square a3
		And Black placed a disc in square a4
		And White placed a disc in square b4
		And Black placed a disc in square c4
		And White placed a disc in square d4
		And Black placed a disc in square d3
		And White placed a disc in square d1
		When Black places a disc in square a1
		Then the board should be like this
			|   | a | b | c | d |
			| 1 | B |   | W | W |
			| 2 | B | B | B | W |
			| 3 | B | B | B | W |
			| 4 | B | B | B | W |

	Scenario: Last (12th) move by White on the previous 4x4 board
		Given Black placed a disc in square a2
		And White placed a disc in square c1
		And Black placed a disc in square d2
		And White placed a disc in square a3
		And Black placed a disc in square a4
		And White placed a disc in square b4
		And Black placed a disc in square c4
		And White placed a disc in square d4
		And Black placed a disc in square d3
		And White placed a disc in square d1
		And Black placed a disc in square a1
		When White places a disc in square b1
		Then the board should be like this
			|   | a | b | c | d |
			| 1 | B | W | W | W |
			| 2 | B | B | W | W |
			| 3 | B | B | B | W |
			| 4 | B | B | B | W |



