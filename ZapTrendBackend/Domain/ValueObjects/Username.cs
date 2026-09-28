using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Model.ValueObjects
{
    public class UserName : ValueObject
    {
        private const int MaxCharacters = 20;

        public string Value { get; }

        public UserName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre de usuario no puede estar vacío.", nameof(value));

            if (value.Length > MaxCharacters)
                throw new ArgumentException($"El nombre de usuario no puede superar los {MaxCharacters} caracteres.", nameof(value));

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
