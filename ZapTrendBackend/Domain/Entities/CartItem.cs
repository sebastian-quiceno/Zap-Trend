using System;
using System.Collections.Generic;
using System.Text;

namespace ZapTrendBackend.Model.Entities
{
    public class CartItem
    {
        private int id;
        private uint quantity;
        private ProductVariant productVariant;

        public CartItem(int id, uint quantity, ProductVariant productVariant)
        {
            this.id = id;
            this.quantity = quantity;
            this.productVariant = productVariant;
        }

        public int Id { get => id;}
        public uint Quantity { get => quantity; set => quantity = value; }
        public ProductVariant ProductVariant { get => productVariant; set => productVariant = value; }

        //metodos
        public decimal CalculateTotal() {
            return productVariant.Price * quantity;
        }
    }
}
