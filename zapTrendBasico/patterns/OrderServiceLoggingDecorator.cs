using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using zapTrendBasico.entities;
using zapTrendBasico.interfaces;

namespace zapTrendBasico.patterns
{
    internal class OrderServiceLoggingDecorator: IOrderService
    {
        private readonly IOrderService ordenServiceInterno;

        public OrderServiceLoggingDecorator(IOrderService ordenServiceInterno)
        {
            this.ordenServiceInterno = ordenServiceInterno;
        }

        public void procesarOrden(Order order)
        {

            // TODO 1: Inicia un cronómetro
            var sw = Stopwatch.StartNew();

            // TODO 2: Imprime mensaje de inicio
            Console.WriteLine("[Auditoría] Iniciando procesamiento...");

            // TODO 3: Delegar la lógica de negocio al servicio interno
            ordenServiceInterno.procesarOrden(order);

            // TODO 4: Detener el cronómetro
            sw.Stop();

            // TODO 5: Imprimir el tiempo de procesamiento
            Console.WriteLine($"[Auditoría] Procesamiento finalizado en {sw.ElapsedMilliseconds} ms.");
        }
    }
}
