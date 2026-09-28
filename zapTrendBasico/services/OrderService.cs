using System;
using System.Collections.Generic;
using System.Text;
using zapTrendBasico.entities;
using zapTrendBasico.events;
using zapTrendBasico.interfaces;

namespace zapTrendBasico.services
{
    internal class OrderService : IOrderService
    {
        //Creacion del evento, el cual va a devolver el objeto (trhis) junto a los Args que es OrderEventArgs
        public event EventHandler<OrderEventArgs> ordenProcesada;

        public void procesarOrden(Order order)
        {
            Console.WriteLine($"[Procesador Core] Procesando pedido {order.Id} por ${order.Monto}...");

            // Simulacion de procesamiento de 5 segundo
            Thread.Sleep(5000);

            // 2. Empaquetar la información, se crea un OrderEventArgs para pasarlos al disparar el evento
            // TODO COMPLETADO: Creamos la instancia de tus argumentos personalizados pasándole el objeto 'order'
            OrderEventArgs args = new OrderEventArgs(order);

            // 3. Disparar (publicar) el evento, se usa Invoke para 
            // TODO COMPLETADO: Invocamos de forma segura pasando el emisor (this) y los datos (args)
            ordenProcesada?.Invoke(this, args);
        }
    }
}
