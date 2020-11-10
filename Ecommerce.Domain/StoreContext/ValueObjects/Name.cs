using FluentValidator;
using FluentValidator.Validation;

namespace Ecommerce.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(
                new ValidationContract()
                .Requires()
                .HasMinLen(firstName, 3, "FirstName", "Nome inválido")
                .HasMinLen(lastName, 3, "LastName", "Nome inválido"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
