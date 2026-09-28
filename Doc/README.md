# Requisitos y Alcance ***ZapTrend***

## Alcance del proyecto
**El sistema permitirá:**
- Administrar clientes.
- Administrar productos.
- Crear pedidos.
- Confirmar pedidos.
- Cancelar pedidos.
- Simular el procesamiento de un pago.
- Generar una factura simple.
- Notificar mediante eventos las acciones importantes del sistema.

**No se contempla:**
- Base de datos.
- Interfaz gráfica.
- Autenticación.
- Usuarios.
- Reportes.
- API REST.

> [!NOTE]
>
> Toda la información podrá almacenarse en memoria.

--- 

## Requisitos **Funcionales**

### 1. **RF-01** Registrar Cliente: 
El sistema deberá permitir registrar un cliente con la siguiente información:

- Id
- Nombre
- Correo electrónico

> [!NOTE]
>
>No deberán existir dos clientes con el mismo correo.

---

### 2. **RF-02** Registrar Producto: 
El sistema permitirá registrar productos indicando:

- Id
- Nombre
- Precio
- Stock

> [!NOTE]
>
>El precio no podrá ser negativo.
>
>El stock no podrá ser negativo.

---

### 3. **RF-03** Consultar Productos: 
El usuario podrá visualizar todos los productos registrados mostrando:

- Nombre
- Precio
- Stock disponible

---

### 4. **RF-04** Crear Pedido:
El sistema permitirá crear un pedido para un cliente existente.

- Un pedido iniciará con estado: `Pendiente`

---

### 5. **RF-05** Agregar Productos al Pedido: 
El usuario podrá agregar uno o más productos indicando la cantidad.
El sistema deberá validar:
    - Que exista el producto.
    - Que exista suficiente stock.

> [!NOTE]
>
>El total del pedido deberá calcularse automáticamente.

---

### 6. **RF-06** Confirmar Pedido: 
Al confirmar un pedido:

- El estado cambiará a Confirmado.
- Se descontará el stock.
- Se procesará el pago.
- Se generará una factura.
- Se notificará que el pedido fue confirmado.

> [!NOTE]
>
>Estas acciones deberán ejecutarse utilizando eventos.

---

### 7. **RF-07 Cancelar Pedido:** 
Solo podrán cancelarse pedidos que aún no hayan sido confirmados.
El estado cambiará a: `Cancelado`

---

### 8. **RF-08** Procesar Pago: 
El sistema simulará un pago exitoso.

- No será necesario conectarse a ninguna pasarela de pago.
- Al finalizar deberá lanzarse un evento indicando que el pago fue procesado.

---

### 9. **RF-09** Generar Factura: 
Una vez realizado el pago se generará una factura con:

- Número de factura
- Cliente
- Productos
- Cantidad
- Precio unitario
- Total
>[!NOTE]
>
>No será necesario guardar la factura.
>
>Bastará con imprimirla en consola.

---

### 10. **RF-10** Notificaciones: 
El sistema mostrará mensajes cuando ocurran los siguientes eventos:
    - Pedido creado.
    - Pedido confirmado.
    - Pago realizado.
    - Factura generada.
    - Stock bajo.

---

## Requisitos **No Funcionales**

### 1. **RNF-01** Arquitectura: 
El proyecto deberá implementarse siguiendo los principios de Arquitectura Limpia.
Como mínimo deberá existir separación entre:

- Dominio
- Aplicación
- Infraestructura
- Presentación

---

### 2. **RNF-02** Principios SOLID:
Las clases deberán respetar los principios SOLID siempre que sea posible.
Especialmente:
- Responsabilidad única.
- Inversión de dependencias.
- Abierto/Cerrado.

---

### 3. **RNF-03** Uso de Interfaces
Toda dependencia hacia servicios o repositorios deberá realizarse mediante interfaces.
Ejemplo:

```
   PedidoService
     
        ↓
    
IPedidoRepository
```

---

### 4. **RNF-04** Eventos:
Las acciones importantes del sistema deberán notificarse utilizando eventos de C#.
Como mínimo deberán existir eventos para:
- Pedido confirmado.
- Pago procesado.
- Factura generada.
- Stock bajo.

---

### 5. **RNF-05** Persistencia:
La información permanecerá únicamente en memoria durante la ejecución del programa.
No será obligatorio utilizar base de datos.

---

### 6. **RNF-06** Consola:
Toda la interacción con el usuario se realizará mediante una aplicación de consola.

---

### 7. **RNF-07** Validaciones:
El sistema deberá impedir:
- Crear clientes repetidos.
- Crear productos con precio negativo.
- Crear productos con stock negativo.
- Confirmar pedidos vacíos.
- Agregar productos sin stock suficiente.
- Confirmar dos veces un mismo pedido.

---

## Restricciones Técnicas

- Lenguaje: C# (.NET 8 o superior).
- Aplicación de consola.
- No utilizar frameworks externos para eventos (emplear event y delegados de C#).
- Utilizar inyección de dependencias para desacoplar servicios y repositorios.
- Mantener las reglas de negocio dentro de la capa de Dominio.

