using System;
using System.Collections.Generic;
using System.Text;

namespace ZapTrendBackend.Model.Primitives
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetEqualityComponents();

        public bool Equals(ValueObject? other) {
            return other is not null && ValuesAreEquals(other);
        }

        public override bool Equals(object? obj)
        {
            //Se hace un casteo de obj a ValueObject
            return obj is ValueObject other && ValuesAreEquals(other);
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents().Aggregate(
                default(int),
                HashCode.Combine
            );
        }

        private bool ValuesAreEquals(ValueObject other) {

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());

        }
    }
}
