using Ecommerce.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Ecommerce.Domain.StoreContext.Commands.CustomerCommands.Outputs;
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
        [Route("v1/customers")]
        // [ResponseCache(Duration = 60)]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        // Cache-Control: public, max-age=60
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _customerRepository.Get();
        }

        [HttpGet]  
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _customerRepository.Get(id);
        }

        [HttpGet]
        [Route("v2/customers/{document}")]
        public GetCustomerQueryResult GetByDocument(Guid document)
        {
            return _customerRepository.Get(document);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {   
            return _customerRepository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post([FromBody] CreateCustomerCommand command)
        {
            return (CreateCustomerCommandResult)_handler.Handler(command);
        }



    }
}
