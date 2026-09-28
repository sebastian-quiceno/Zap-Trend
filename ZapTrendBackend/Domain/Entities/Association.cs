using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using ZapTrendBackend.Model.ValueObjects;

namespace ZapTrendBackend.Model.Entities
{
    public class Association
    {

        //Atributos de clase
        private int id;
        public Name Name { get; }

        //Constructor
        public Association(int id, Name name)
        {
            Id = id;
            Name = name;
        }

        //Getters Setters
        public int Id { get => id; set => id = value; }
        

    }
}
