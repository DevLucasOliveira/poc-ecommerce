using Ecommerce.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Ecommerce.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Ecommerce.Domain.StoreContext.Entities;
using Ecommerce.Domain.StoreContext.ValueObjects;
using Ecommerce.Shared.Commands;
using FluentValidator;
using System;

namespace Ecommerce.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {
        public ICommandResult Handler(CreateCustomerCommand command)
        {
            command.Valid();
            if (command.Invalid)
                return null;

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var customer = new Customer(name, document, email, command.Phone);


            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);


            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handler(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
