using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Model.Exceptions.User
{
    public class IncorrectPasswordException : DomainException
    {
        public IncorrectPasswordException(string message) : base(message)
        {
        }
    }
}
