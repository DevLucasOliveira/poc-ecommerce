using Ecommerce.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Ecommerce.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Ecommerce.Domain.StoreContext.Entities;
using Ecommerce.Domain.StoreContext.Handlers;
using Ecommerce.Domain.StoreContext.Queries;
using Ecommerce.Domain.StoreContext.Repositories;
using Ecommerce.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Ecommerce.Api.Controllers
{
    public class CustomerControlller : Controller
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerHandler _handler;

        public CustomerControlller(ICustomerRepository customerRepository, CustomerHandler handler)
        {
            _customerRepository = customerRepository;
            _handler = handler;
        }

        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _customerRepository.Get();
        }

        [HttpGet]  
        [Route("customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _customerRepository.Get(id);
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {   
            return _customerRepository.GetOrders(id);
        }

        [HttpPost]
        [Route("Customers")]
        public object Post([FromBody] CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handler(command);
            if (_handler.Invalid)
                return BadRequest(_handler.Notifications);

            return result;
        }



    }
}
