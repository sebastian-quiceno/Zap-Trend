using zapTrendBasico.entities;
using zapTrendBasico.interfaces;
using zapTrendBasico.patterns;
using zapTrendBasico.services;

namespace zapTrendBasico
{
    public class Program
    {
        static void Main(string[] args)
        {
            // A. Instanciamos la entidad
            Order miPedido = new Order(101, 5500.00m);

            // B. Instanciamos el servicio CORE (Lógica de negocio pura)
            OrderService coreService = new OrderService();

            // C. Instanciamos los suscriptores
            InventoryManager inventario = new InventoryManager();
            EmailNotifier notificador = new EmailNotifier();

            // D. SUSCRIPCIÓN A EVENTOS (¡La magia del desacoplamiento!)
            coreService.ordenProcesada += inventario.ActualizarInventario;
            coreService.ordenProcesada += notificador.notificarOrden;

            // E. ENSAMBLAJE AOP (Envolvemos el core con nuestro aspecto)
            IOrderService servicioFinal = new OrderServiceLoggingDecorator(coreService);

            // F. Ejecutamos el caso de uso
            Console.WriteLine("--- INICIANDO SISTEMA ---");
            servicioFinal.procesarOrden(miPedido);

            Console.ReadLine();
        }
    }
}
