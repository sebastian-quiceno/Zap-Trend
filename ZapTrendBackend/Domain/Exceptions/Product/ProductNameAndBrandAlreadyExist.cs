using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Domain.Exceptions.Product
{
    internal class ProductNameAndBrandAlreadyExist : DomainException
    {
        public ProductNameAndBrandAlreadyExist(string message) : base(message)
        {
        }
    }
}
