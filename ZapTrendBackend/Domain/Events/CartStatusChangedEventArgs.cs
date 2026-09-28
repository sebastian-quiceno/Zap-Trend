using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Enums;

namespace ZapTrendBackend.Model.Events
{
    public class CartStatusChangedEventArgs
    {
        public Guid CartId { get; }
        public CartStatus NewStatus { get; }

        public CartStatusChangedEventArgs(Guid cartId, CartStatus newStatus)
        {
            CartId = cartId;
            NewStatus = newStatus;
        }
    }
}
