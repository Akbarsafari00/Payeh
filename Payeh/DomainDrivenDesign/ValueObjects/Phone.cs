using System;
using Payeh.DomainDrivenDesign.Exceptions;

namespace Payeh.DomainDrivenDesign.ValueObjects
{
    public class Phone : BaseValueObject<Phone>
    {
        #region Properties

        public string Country { get; private set; }
        public string Number { get; private set; }
        public string Value { get; private set; }

        public bool Verify { get; private set; }
        public DateTime? VerifyAt { get; private set; }
        public DateTime? VerifyAtUtc { get; private set; }

        #endregion

        #region Constructors and Factories

        public static Phone FromString(string country, string number, bool verify = false) =>
            new Phone(country, number, verify);

        public Phone(string country, string number, bool verify = false)
        {
            if (string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(country))
            {
                throw new DomainException("VALIDATION_ERROR", "country and number field is require",
                    new {fields = new String[] {nameof(country), nameof(number)}});
            }

            if (number.Length is < 10 or > 11)
            {
                throw new DomainException("VALIDATION_ERROR", "number field is length must between 10 - 11",
                    new {maxLength = 11, minLength = 10});
            }

            if (country.Length < 1)
            {
                throw new DomainException("VALIDATION_ERROR", "country field is length must be greater then equal 1",
                    new {minLength = 1});
            }

            Country = country.Replace("+", "").TrimStart(new Char[] {'0'});
            Number = number.TrimStart(new Char[] {'0'});
            Value = Country + Number;
            
            UpdateVerify(verify);
        }

        private Phone()
        {
        }

        #endregion


        #region Equality Check

        public override int ObjectGetHashCode()
        {
            return Country.GetHashCode() + Number.GetHashCode();
        }

        public override bool ObjectIsEqual(Phone otherObject)
        {
            return Country == otherObject.Country && Number == otherObject.Number;
        }

        #endregion


        #region Operator Overloading

        public static implicit operator string(Phone phone) => phone.Value;

        #endregion

        #region Methods

        public override string ToString() => Value;

        public void UpdateVerify(bool isVerify)
        {
            if (isVerify)
            {
                Verify = true;
                VerifyAt = DateTime.Now;
                VerifyAtUtc = DateTime.UtcNow;
            }
            else
            {
                Verify = false;
                VerifyAt = null;
                VerifyAtUtc = null;
            }
        }

        #endregion
    }
}