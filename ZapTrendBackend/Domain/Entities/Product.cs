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
        public Name Name { get; }
        private Brand brand;
        private ProductType productType;

        //Constructor
        private Product(Guid id, Name name, Brand brand, ProductType productType)
        {
            Id = id;
            Name = name;
            Brand = brand;
            ProductType = productType;
        }

        //Getters y Setters
        public Brand Brand
        {
            get; 
            set => field = value is null ? value :
                                  throw new ArgumentException($"La marca del producto no puede ser null");
        }
        public ProductType ProductType { get => productType; 
            set{ 
                if(value is null)
                    throw new ArgumentException($"El tipo de producto de Producto no puede ser null");
                ProductType = value;
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

    }
}
