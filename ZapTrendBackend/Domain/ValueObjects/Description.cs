using System;
using System.Collections.Generic;
using System.Text;
using ZapTrendBackend.Model.Primitives;

namespace ZapTrendBackend.Model.ValueObjects
{
    public class Description : ValueObject
    {
        private const int maxCharDescription = 40;

        public string Value { get; }

        public Description(string value) {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("La descripcion no puede estar vacia", nameof(value));
            if (value.Length > maxCharDescription)
                throw new ArgumentException($"La descripcion no puede superar los {maxCharDescription} caracteres", nameof(value));
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
