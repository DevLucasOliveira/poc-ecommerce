using Ecommerce.Domain.StoreContext.Enums;
using Ecommerce.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;

namespace Ecommerce.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class AddAddressCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }  
        public EAddressType Type { get; set; }

        public void Valid()
        {
            AddNotifications(
                new ValidationContract()
                .Requires()
                .HasMinLen(Street, 3, "Street", "Nome inválido"));
        }

    }
}
