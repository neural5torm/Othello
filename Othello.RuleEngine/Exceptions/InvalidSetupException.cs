using System;
using System.Runtime.Serialization;

namespace Othello.RuleEngine;

public class InvalidSetupException : Exception
{
    public InvalidSetupException(string message) : base(message) { }
    public InvalidSetupException(string message, Exception inner) : base(message, inner) { }

    protected InvalidSetupException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
