using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Model.Exceptions.User
{
    public class DocumentAlreadyExistsException : DomainException
    {
        public DocumentAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
