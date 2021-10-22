using Payeh.DomainDrivenDesign.Exceptions;

namespace Payeh.DomainDrivenDesign.ValueObjects
{
    public class Email : BaseValueObject<Email>
    {
        #region Properties
        public string Value { get; private set; }
        #endregion

        #region Constructors and Factories
        public static Email FromString(string value) => new Email(value);
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException("VALIDATION_ERROR","value field is require", new {fields = new [] {nameof(value)}});
            }
            if (value.Length < 8 || value.Length > 150)
            {
                throw new DomainException("VALIDATION_ERROR","value field is length must between 8 - 150", new {maxLength = 150 , minLength=8});
            }
            Value = value;
        }
        private Email()
        {

        }
        #endregion


        #region Equality Check
        public override int ObjectGetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool ObjectIsEqual(Email otherObject)
        {
            return Value == otherObject.Value;
        }
        #endregion


        #region Operator Overloading
        public static explicit operator string(Email Email) => Email.Value;
        public static implicit operator Email(string value) => new(value);
        #endregion

        #region Methods
        public override string ToString() => Value; 
        #endregion
    }
}
