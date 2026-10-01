using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Domain.Exceptions.Authorization
{
    internal class ForbiddenException : DomainException
    {
        public ForbiddenException(string message) : base(message)
        {
        }
    }
}
