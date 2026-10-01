using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Domain.Exceptions.Authorization
{
    internal class NotAuthenticatedException : DomainException
    {
        public NotAuthenticatedException(string message) : base(message)
        {
        }
    }
}
