﻿using System;
using Payeh.DomainDrivenDesign.Exceptions;

namespace Payeh.DomainDrivenDesign.ValueObjects
{
    public class Phone : BaseValueObject<Phone>
    {
        #region Properties

        public string Country { get; private set; }
        public string Number { get; private set; }
        public string FullNumber { get; private set; }

        #endregion

        #region Constructors and Factories

        public static Phone FromString(string country, string number) => new Phone(country, number);

        public Phone(string country, string number)
        {
            if (string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(country))
            {
                throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(Phone));
            }

            if (number.Length is < 10 or > 11)
            {
                throw new InvalidValueObjectStateException("ValidationErrorStringLengthForNumber", nameof(Phone), "10",
                    "11");
            }


            Country = country.Replace("+","").TrimStart(new Char[] { '0' } );;
            Number = number.TrimStart(new Char[] { '0' } );;
            FullNumber = Country + Number;
        }

        private Phone()
        {
        }

        #endregion


        #region Equality Check

        public override int ObjectGetHashCode()
        {
            return Country.GetHashCode()+Number.GetHashCode();
        }

        public override bool ObjectIsEqual(Phone otherObject)
        {
            return Country == otherObject.Country && Number == otherObject.Number;
        }

        #endregion


        #region Operator Overloading

        public static implicit operator string(Phone phone) => phone.FullNumber;

        #endregion

        #region Methods

        public override string ToString() => FullNumber;

        #endregion
    }
}