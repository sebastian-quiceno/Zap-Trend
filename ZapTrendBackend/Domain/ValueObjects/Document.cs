using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Model.ValueObjects
{
    public class Document : ValueObject
    {
        private const int DodumentLength = 10;
        public string Value { get; }

        public Document(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El documento de Usuario no puede estar vacío");
            if (!OnlyNumbers(value))
                throw new ArgumentException("El documento de Usuario solo puede tener números");
            if (value.Length > DodumentLength)
                throw new ArgumentException($"El documento de Usuario debe tener una longitud menor o igual a {DodumentLength}");

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

        private static bool OnlyNumbers(string text) => text.All(char.IsDigit);


    }
}
