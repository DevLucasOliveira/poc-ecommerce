using Ecommerce.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace Ecommerce.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public void Valid()
        {
            AddNotifications(
                new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "Nome inválido")
                .HasMinLen(LastName, 3, "LastName", "Nome inválido")
                .IsEmail(Email, "Address", "E-mail inválido"));
        }

    }
}
