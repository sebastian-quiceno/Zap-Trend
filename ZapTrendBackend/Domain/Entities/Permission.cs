using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.Domain.Entities
{
    public class Permission
    {
        public Guid Id { get; private set; }
        public Name Name { get; set; }

        private Permission(Guid id, Name name)
        {
            Id = id;
            Name = name;
        }

        public static Permission Create(Name name) => new Permission(Guid.NewGuid(), name);

        public static Permission Recreate(Guid id, Name name) => new Permission(id, name);
    }
}
