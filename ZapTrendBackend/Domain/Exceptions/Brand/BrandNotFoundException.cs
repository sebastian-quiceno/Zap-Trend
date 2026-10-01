using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Domain.Exceptions.Brand
{
    public class BrandNotFoundException : DomainException
    {
        public BrandNotFoundException(string message) : base(message)
        {
        }
    }
}
