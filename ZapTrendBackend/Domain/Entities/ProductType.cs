using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.model.Entities
{
    public class ProductType
    {
        //Atributos clase
        public Guid Id { get; }
        public Name Name { get; }
        public Description Description { get; }

        //Constructor
        private ProductType(Guid id, Name name, Description description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static ProductType Create(Name name, Description description) {
            return new ProductType(Guid.NewGuid(), name, description);
        }

        public static ProductType Recreate(Guid id, Name name, Description description) {
            return new ProductType(id, name, description);
        }
    }
}


