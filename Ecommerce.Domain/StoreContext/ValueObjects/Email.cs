using FluentValidator;
using FluentValidator.Validation;

namespace Ecommerce.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(
              new ValidationContract()
              .Requires()
              .IsEmail(Address, "Address", "E-mail inválido"));
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
