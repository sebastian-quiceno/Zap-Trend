using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Model.Exceptions.Brand
{
    public class BrandNameAlreadyExistException : DomainException
    {
        public BrandNameAlreadyExistException(string message) : base(message)
        {
        }
    }
}
