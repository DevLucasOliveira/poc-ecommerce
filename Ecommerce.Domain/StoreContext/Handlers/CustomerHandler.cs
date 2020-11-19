using Ecommerce.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Ecommerce.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Ecommerce.Domain.StoreContext.Entities;
using Ecommerce.Domain.StoreContext.Repositories;
using Ecommerce.Domain.StoreContext.Services;
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
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handler(CreateCustomerCommand command)
        {
            command.Valid();
            if (command.Invalid)
                return null;

            if (_customerRepository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            if (_customerRepository.CheckEmail(command.Email))
                AddNotification("Email", "Este Email já está em uso");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return null;

            _customerRepository.Save(customer);
            _emailService.Send(email.Address, "lucasoliveira.si@outlook.com", "Seja bem vindo ao Balta Store", "Olá");

            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handler(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
