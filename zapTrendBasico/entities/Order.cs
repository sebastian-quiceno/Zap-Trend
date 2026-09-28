using System;
using System.Collections.Generic;
using System.Text;

namespace zapTrendBasico.entities
{
    public class Order
    {
        private int id;
        private decimal monto;

        public Order(int id, decimal monto)
        {
            Id = id;
            Monto = monto;
        }

        public int Id { get => id; set => id = value; }
        public decimal Monto { get => monto; set => monto = value; }
    }
}
