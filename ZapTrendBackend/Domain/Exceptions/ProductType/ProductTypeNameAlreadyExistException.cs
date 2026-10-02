using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Domain.Exceptions.ProductType
{
    public class ProductTypeNameAlreadyExistException : DomainException
    {
        public ProductTypeNameAlreadyExistException(string message) : base(message)
        {
        }
    }
}
