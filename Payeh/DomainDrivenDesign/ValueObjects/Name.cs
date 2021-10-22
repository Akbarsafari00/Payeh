using Payeh.DomainDrivenDesign.Exceptions;

namespace Payeh.DomainDrivenDesign.ValueObjects
{
    public class Name : BaseValueObject<Name>
    {
        #region Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get; private set; }
        #endregion

        #region Constructors and Factories
        public static Name FromString(string firstName , string lastName) => new Name(firstName,lastName);
        public Name(string firstName , string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new InvalidValueObjectStateException("ValidationErrorFirstNameIsRequire", nameof(Name));
            }
            if (firstName.Length is < 2 or > 150)
            {
                throw new InvalidValueObjectStateException("ValidationErrorFirstNameLength", nameof(Name), "2", "250");
            }
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{firstName} {lastName}";
        }
        #endregion


        #region Equality Check
        public override int ObjectGetHashCode()
        {
            return FirstName.GetHashCode()+LastName.GetHashCode();
        }

        public override bool ObjectIsEqual(Name otherObject)
        {
            return FirstName == otherObject.FirstName & LastName == otherObject.LastName;
        }
        #endregion


        #region Operator Overloading
        public static explicit operator string(Name name) => name.FullName;
        #endregion

        #region Methods
        public override string ToString() => FullName; 
        #endregion
    }
}
