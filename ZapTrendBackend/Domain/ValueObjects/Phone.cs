using System;
using System.Collections.Generic;
using System.Text;

namespace ZapTrendBackend.Model.ValueObjects
{
    public class Phone
    {
        private const int MinCharacters = 7;
        private const int MaxCharacters= 15;
        public string Value { get; }

        public Phone(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El teléfono de Usuario no puede estar vacío");
            if (!OnlyNumbers(value))
                throw new ArgumentException("El teléfono de Usuario solo puede tener números");
            if (value.Length < MinCharacters || value.Length > MaxCharacters)
                throw new ArgumentException($"El teléfono de Usuario debe tener una longitud entre {MinCharacters} y {MaxCharacters}");
            
            Value = value;
        }

        private bool OnlyNumbers(string text) => text.All(char.IsDigit);

    }
}
