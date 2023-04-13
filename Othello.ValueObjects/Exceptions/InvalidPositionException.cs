using System;
using System.Runtime.Serialization;

namespace Othello.ValueObjects.Exceptions
{
    [Serializable]
    public class InvalidPositionException : Exception
    {
        public InvalidPosition? InvalidPosition { get; init; }

        public InvalidPositionException(InvalidPosition position): this($"This position is invalid: {position}.")
        {
            InvalidPosition = position;
        }

        public InvalidPositionException(string? message) : base(message)
        {
        }

        public InvalidPositionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidPositionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}