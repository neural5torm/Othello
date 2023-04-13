using System;
using System.Runtime.Serialization;

namespace Othello.ValueObjects.Exceptions
{
    [Serializable]
    public class UnevenDimensionException : Exception
    {
        public UnevenDimensionException(string? message) : base(message)
        {
        }

        public UnevenDimensionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnevenDimensionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
