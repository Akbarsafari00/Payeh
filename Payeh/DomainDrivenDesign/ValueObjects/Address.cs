using Payeh.DomainDrivenDesign.Exceptions;
using Payeh.DomainDrivenDesign.ValueObjects;

namespace Payeh.DomainDrivenDesign.ValueObjects
{
    public class Address : BaseValueObject<Address>
    {
        #region Properties

        public string Path { get; private set; }
        public string Description { get; private set; }
        public string BuildingNumber { get; private set; }
        public string ApartmentNumber { get; private set; }
        public string Floor { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Value { get; private set; }

        #endregion

        #region Constructors and Factories

        public static Address FromString(string path, string city = "", string state = "", string postalCode = "",
            string apartmentNumber = "", string floor = "",
            string buildingNumber = "", string description = "") => new Address(path, city, state, postalCode,
            apartmentNumber, buildingNumber, floor, description);

        public Address(string path, string city = "", string state = "", string postalCode = "",
            string apartmentNumber = "",
            string buildingNumber = "", string floor = "", string description = "")
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new InvalidValueObjectStateException("ValidationErrorFirstAddressIsRequire", nameof(Address));
            }

            if (path.Length < 10)
            {
                throw new InvalidValueObjectStateException("ValidationErrorFirstAddressLength", nameof(Address), "2");
            }

            Path = path;
            BuildingNumber = buildingNumber;
            Description = description;
            City = city;
            State = state;
            ApartmentNumber = apartmentNumber;
            Floor = floor;
            PostalCode = postalCode;
            Value =
                $"[{city}]-[{state}]-[{path}:{description}]-[{buildingNumber}]-[{apartmentNumber}]-[{postalCode}]";
        }

        #endregion


        #region Equality Check

        public override int ObjectGetHashCode()
        {
            return Path.GetHashCode() + City.GetHashCode()+State.GetHashCode()+PostalCode.GetHashCode();
        }

        public override bool ObjectIsEqual(Address otherObject)
        {
            return
                Path == otherObject.Path &
                City == otherObject.City &
                City == otherObject.State &
                City == otherObject.PostalCode &
                City == otherObject.BuildingNumber &
                City == otherObject.ApartmentNumber &
                City == otherObject.Floor;
        }

        #endregion


        #region Operator Overloading

        public static explicit operator string(Address Address) => Address.Value;

        #endregion

        #region Methods

        public override string ToString() => Value;

        #endregion
    }
}