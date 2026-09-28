using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Enums;

namespace ZapTrendBackend.model.Entities
{
    public class Size
    {
        //Reglas de negocio
        private static readonly float max_value_cm = 200;
        private static readonly float ratioInches = 0.4f;

        //Atributos de clase
        private int id;
        private float cm;
        private float inches;
        private SizeTypes commercia_size;
        private float min_cm;
        private float max_cm;

        //Constructor
        protected Size(int id, float cm, SizeTypes commercia_size, float min_cm, float max_cm)
        {
            Id = id;
            Cm = cm;
            Commercia_size = commercia_size;
            Min_cm = min_cm;
            Max_cm = max_cm;
        }

        //Getters Setters
        public int Id { get => id; set => id = value; }
        public float Cm { 
            get => cm;
            set
            {
                if (min_cm != 0.0 && max_cm != 0.0) {
                    if (value <= min_cm || value >= max_cm)
                        throw new ArgumentException($"La medida exacta no puede ser menor a la medida minima {min_cm} o mayor a la medida maxima {max_cm}");
                }
                if (value <= 0 || value >= max_value_cm)
                    throw new ArgumentException($"No se puede colocar mas de {max_value_cm} centimetros de medida");
                
                CalculateInches();
                cm = value;
            }
        }
        public float Inches { get => inches;}
        public SizeTypes Commercia_size { get => commercia_size; set => commercia_size = value; }
        public float Min_cm { get => min_cm; set => min_cm = value; }
        public float Max_cm { get => max_cm; set => max_cm = value; }

        //Metodos
        private void CalculateInches() {
            inches = cm * ratioInches;
        }
    }
}
