using System;

namespace DDD.Domain.Exceptions
{
    public sealed class InputException : ExceptionBase
    {
        public InputException(string message) : base(message)
        {
            
        }

        public override ExceptionKind Kind => ExceptionKind.Info;
    }
}
