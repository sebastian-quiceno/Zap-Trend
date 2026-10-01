using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.model.Entities
{
    public class Brand
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }

        private Brand(Guid id, Name name)
        {
            Id = id;
            Name = name;
        }

        public static Brand Create(Name name) {
            return new Brand(Guid.NewGuid(), name);
        }

        public static Brand Recreate(Guid id, Name name) {
            return new Brand(id, name);
        }

        public void ChangeName(Name name) {
            Name = name;
        }
    }
}
