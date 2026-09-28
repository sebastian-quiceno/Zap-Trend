using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.Domain.Entities
{
    //Revisar si es mejor hacerlo internal
    public class Rol
    {
        private Guid id;
        public Name Name { get; }
        private List<string> permisos;

        private Rol(Guid id, Name name, List<string> permisos)
        {
            this.id = id;
            Name = name;
            this.permisos = permisos;
        }


    }
}
