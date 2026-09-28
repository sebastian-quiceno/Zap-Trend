using System;
using System.Collections.Generic;
using System.Text;
using zapTrendBasico.events;

namespace zapTrendBasico.services
{
    internal class InventoryManager
    {
        // Este es el método que engancharemos al evento.
        // Nota que la firma coincide perfectamente con lo que envía Invoke(this, args)
        public void ActualizarInventario(object sender, OrderEventArgs e)
        {
            // TODO completado: Se sacan los parametros del e y se imprimen
            Console.WriteLine($"[Inventario] Se acaba de identificar una orden con el id {e.CompletedOrder.Id}, descontando stock...");
      
        }
    }
}
