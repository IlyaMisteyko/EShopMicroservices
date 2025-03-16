﻿namespace Ordering.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base($"Domain ex: \"{message}\" throws from Domain layer.")
        { }
    }
}
