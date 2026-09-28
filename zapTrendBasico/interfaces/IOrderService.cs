using System;
using System.Collections.Generic;
using System.Text;
using zapTrendBasico.entities;

namespace zapTrendBasico.interfaces
{
    internal interface IOrderService
    {
        void procesarOrden(Order order);
    }
}
