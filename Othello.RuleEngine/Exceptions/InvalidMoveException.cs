using System;
using System.Runtime.Serialization;

namespace Othello.RuleEngine;

[Serializable]
public class InvalidMoveException : Exception
{
    public InvalidMoveException(string message) : base(message) { }
    public InvalidMoveException(string message, Exception inner) : base(message, inner) { }

    protected InvalidMoveException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
