using System;

namespace ApplicationLayer.Domain.Exceptions
{
    public class TransactionException : DomainException
    {
        public TransactionException(string message) : base(message)
        {
            StatusCode = 400;
        }
    }
}
