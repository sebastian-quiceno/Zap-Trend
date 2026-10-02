using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Domain.Exceptions.Product
{
    public class ProductNotFoundException : DomainException
    {
        public ProductNotFoundException(string message) : base(message)
        {
        }
    }
}
