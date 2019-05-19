using System;

namespace Exception.Entities.Exceptions
{
    public class DomainException : ApplicationException
    {
        public DomainException(string message) :base(message)
        {
        }
    }
}
