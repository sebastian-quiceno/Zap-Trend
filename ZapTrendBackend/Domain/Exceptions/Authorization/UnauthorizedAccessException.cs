using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Domain.Exceptions.Authorization
{
    internal class UnauthorizedAccessException : DomainException
    {
        public UnauthorizedAccessException(string message) : base(message)
        {
        }
    }
}
