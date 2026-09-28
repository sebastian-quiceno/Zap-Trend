using System;
using System.Collections.Generic;
using System.Text;

namespace ZapTrendBackend.Model.Primitives
{
    public abstract class DomainException: Exception
    {
        public DomainException(string message) : base(message) {}
    }
}
