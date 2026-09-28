using System;
using System.Collections.Generic;
using System.Text;
using zapTrendBasico.entities;

namespace zapTrendBasico.events
{
    internal class OrderEventArgs : EventArgs
    {
        public Order CompletedOrder { get; }

        public OrderEventArgs(Order order)
        {
            CompletedOrder = order;
        }
    }
}
