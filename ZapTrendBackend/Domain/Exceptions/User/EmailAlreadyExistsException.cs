using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Model.Exceptions.User
{
    public class EmailAlreadyExistsException : DomainException
    {
        public EmailAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
