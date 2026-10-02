using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Domain.Exceptions.ProductType
{
    public class ProductTypeNotFoundException : DomainException
    {
        public ProductTypeNotFoundException(string message) : base(message)
        {
        }
    }
}
