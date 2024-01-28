using HangryHub.DeliveryService.Domain.DeliveryAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Domain.Common
{
    public abstract class IdValueObject<T> : EntityValueObject
    {

        public Guid Id { get; private set; }


        public IdValueObject(Guid id){
            Id = id;
        }

        public override bool Equals(object? obj) => obj is IdValueObject<T> o && this.Equals(o);

        public bool Equals(IdValueObject<T> other) => this.Id == other.Id;

        public override int GetHashCode() =>
            HashCode.Combine(this.Id);

        public static bool operator ==(IdValueObject<T> left, IdValueObject<T> right) => left.Equals(right);

        public static bool operator !=(IdValueObject<T> left, IdValueObject<T> right) => !(left == right);

        public override string ToString() => this.Id.ToString();


    }
}
