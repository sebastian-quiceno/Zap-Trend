using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.Domain.Entities
{
    //Revisar si es mejor hacerlo internal
    public class Role
    {
        public Guid Id { get; private set; }
        public Name Name { get; }
        public List<Permission> Permissions { get; set; }

        private Role(Guid id, Name name, List<Permission> permisos)
        {
            Id = id;
            Name = name;
            Permissions = permisos;
        }

        public static Role Create(Name name) {
            return new Role(Guid.NewGuid(), name, new List<Permission>());
        }

        public static Role Recreate(Guid id, Name name, List<Permission> permisos)
        {
            return new Role(id, name, permisos);
        }

        public void AddPermission(Permission permission)
        {
            ArgumentNullException.ThrowIfNull(permission);

            if (Permissions.Any(p => p.Id == permission.Id))
                return;

            Permissions.Add(permission);
        }

        public void RemovePermission(Permission permission)
        {
            ArgumentNullException.ThrowIfNull(permission);

            if (Permissions.Any(p => p.Id == permission.Id))
                throw new ArgumentException("El Rol no tiene el permiso a quitar");
            
            Permissions.Remove(permission);
        }

    }
}
