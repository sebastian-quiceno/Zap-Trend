using System;
using System.Collections.Generic;
using System.Text;
using zapTrendBasico.events;

namespace zapTrendBasico.services
{
    internal class EmailNotifier
    {
        public void notificarOrden(object sender, OrderEventArgs e)
        {
            Console.WriteLine($"[Email] Enviando recibo al cliente de la orden con ID: {e.CompletedOrder.Id}");
        }
    }
}
