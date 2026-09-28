using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Model.Exceptions.User
{
    public class UsernameAlreadyExistsException : DomainException
    {
        public UsernameAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
