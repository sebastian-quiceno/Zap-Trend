using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.model.Entities
{
    public class Product
    {

        //Atributos de la clase
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        private Brand brand;
        private ProductType productType;

        //Constructor
        private Product(Guid id, Name name, Brand brand, ProductType productType)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));

            Id = id;
            Name = name;
            Brand = brand;
            ProductType = productType;
        }

        //Getters y Setters
        public Brand Brand{
            get => brand;
            private set{
                if (value is null)
                    throw new ArgumentException($"La marca del producto no puede ser null");
                brand = value;
            }
        }
        public ProductType ProductType { 
            get => productType; 
            private set{ 
                if(value is null)
                    throw new ArgumentException($"El tipo de producto de Producto no puede ser null");
                productType = value;
            }
        }

        //Metodos construcctores
        public static Product Create(Name name, Brand brand, ProductType productType) {
            return new Product(Guid.NewGuid(), name, brand, productType);
        }

        public static Product Recreate(Guid id, Name name, Brand brand, ProductType productType)
        {
            return new Product(id, name, brand, productType);
        }

        public void ChangeName(Name name) {
            Name = name;
        }
    }
}
