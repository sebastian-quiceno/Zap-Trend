using System;
using System.Collections.Generic;
using System.Text;

namespace ZapTrendBackend.Model.ValueObjects
{
    public class Mail
    {
        private const int MinCharacters = 5;
        private const int MaxCharacters = 10;

        public string Value { get; }
        
        public Mail(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El correo de Usuario no puede estar vacío");
            if (!ValidMail(value))
                throw new ArgumentException("El correo de Usuario debe ser válido");
            if (value.Length < MinCharacters || value.Length > MaxCharacters)
                throw new ArgumentException($"El correo de Usuario debe tener una longitud entre {MinCharacters} y {MaxCharacters}");
            Value = value;
        }

        private bool ValidMail(string mail) => mail.Contains("@");
        
    }
}
