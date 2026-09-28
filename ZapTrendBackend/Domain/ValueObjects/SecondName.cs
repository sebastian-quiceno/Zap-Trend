using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Model.ValueObjects
{
    public class SecondName : ValueObject
    {

        private const int MaxCharacters = 20;
        public string Value { get; }

        public SecondName(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("El apellido no puede estar vacio", nameof(value));
            if (value.Length > MaxCharacters)
                throw new ArgumentException($"El appelido no puede superar los {MaxCharacters} caracteres", nameof(value));
            Value = value;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
