using System;
using Payeh.DomainDrivenDesign.Exceptions;

namespace Payeh.DomainDrivenDesign.ValueObjects
{
    public class BusinessId : BaseValueObject<BusinessId>
    {
        public static BusinessId FromString(string value) => new(value);
        public static BusinessId FromGuid(Guid value) => new() { Value = value };
        
        public BusinessId(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException("VALIDATION_ERROR","value field is require", new {fields = new [] {nameof(value)}});
            }
            if (Guid.TryParse(value, out Guid tempValue))
            {
                Value = tempValue;
            }
            else
            {
                throw new DomainException("VALIDATION_ERROR","cannot parse value to guid", new {id = value});
            }
        }
        private BusinessId()
        {

        }

        public Guid Value { get; private set; }

        public override int ObjectGetHashCode()
        {

            return Value.GetHashCode();
        }

        public override bool ObjectIsEqual(BusinessId otherObject)
        {
            return Value == otherObject.Value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }

        public static explicit operator string(BusinessId title) => title.Value.ToString();
        public static implicit operator BusinessId(string value) => new(value);


        public static explicit operator Guid(BusinessId title) => title.Value;
        //Create BusinessId From Guid
        public static implicit operator BusinessId(Guid value) => new() { Value = value };

    }
}

