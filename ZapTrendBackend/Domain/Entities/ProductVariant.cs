using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ZapTrendBackend.model.Entities;
using ZapTrendBackend.Model.ValueObjects;
using MiSize = ZapTrendBackend.model.Entities.Size;


namespace ZapTrendBackend.Model.Entities
{
    public class ProductVariant
    {

        //Atributos de clase
        public Guid Id { get; private set; }
        public Name Name { get; }
        private decimal price;
        private MiSize size;
        private Product product;

        //Constructor   
        private ProductVariant(Guid id, Name name, decimal price, MiSize size, Product product)
        {
            Id = id;
            Name = name;
            Price = price;
            Size = size;
            Product = product;
        }

        //Getters Setters
        public decimal Price {
            get => price;
            set 
            {
                if (value <= 0)
                    throw new ArgumentException("EL precio de la variante no puede ser negativo o 0");
                price = value;
            }
        }
        public MiSize Size { 
            get => size;
            set
            {
                if (value is null)
                    throw new ArgumentException($"La talla no puede ser nula en la variante de producto");
                size = value;
            }
        }
        public Product Product { 
            get => product;
            set
            {
                if (value is null)
                    throw new ArgumentException($"El producto no puede ser null en la variante de producto");
                product = value;
            }
        }

        //Metodos constructores

        public static ProductVariant Create(Name name, decimal price, MiSize size, Product product) {
            return new ProductVariant(Guid.NewGuid(), name, price, size, product);
        }

        public static ProductVariant Recreate(Guid id, Name name, decimal price, MiSize size, Product product)
        {
            return new ProductVariant(id, name, price, size, product);
        }
    }
}
