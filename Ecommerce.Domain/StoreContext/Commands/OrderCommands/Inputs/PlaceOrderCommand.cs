using Ecommerce.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;

namespace Ecommerce.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }

        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public void Valid()
        {
            AddNotifications(
             new ValidationContract()
             .Requires()
             .IsNullOrEmpty(Customer.ToString(), "Customer", "Customer inválido"));
        }
    }

    public class OrderItemCommand
{
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}
