using System;
using System.Runtime.Serialization;

namespace CursorPos.Exceptions
{
    internal class UnsuccessException : Exception
    {
        public UnsuccessException()
        {
        }

        protected UnsuccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnsuccessException(string? message) : base(message)
        {
        }

        public UnsuccessException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}