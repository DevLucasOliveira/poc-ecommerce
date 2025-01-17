﻿using Dapper;
using Ecommerce.Domain.StoreContext.Entities;
using Ecommerce.Domain.StoreContext.Queries;
using Ecommerce.Domain.StoreContext.Repositories;
using Ecommerce.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Ecommerce.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document)
        {
            return _context.Connection.Query<bool>("spCheckDocument", new { Document = document }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context.Connection.Query<bool>("spCheckEmail", new { Email = email }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _context.Connection.Query<ListCustomerQueryResult>("spListCustomerQueryResult", commandType: CommandType.StoredProcedure);
        }

        public GetCustomerQueryResult Get(Guid id)
        {
            return _context.Connection.Query<GetCustomerQueryResult>("spGetCustomerById", new { Id = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return _context.Connection.Query<CustomerOrdersCountResult>("spGetCustomerOrdersCount", new { Document = document }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _context.Connection.Query<ListCustomerOrdersQueryResult>("spListCustomerOrdersQueryResult", new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute(
                "spCreateCustomer",
                new
                {
                    Id = customer.Id,
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    Document = customer.Document.Number,
                    Emaiil = customer.Email.Address,
                    Phone = customer.Phone
                }, commandType: CommandType.StoredProcedure);  

            CreateAddress(customer);
        }


        private void CreateAddress(Customer customer)
        {
            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute(
                    "spCreateAddress",
                    new
                    {
                        Id = address.Id,
                        CustomerId = customer.Id,
                        Number = address.Number,
                        Complement = address.Complement,
                        District = address.District,
                        City = address.City,
                        State = address.State,
                        Country = address.Country,
                        ZipCode = address.ZipCode,
                        Type = address.Type
                    }, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
