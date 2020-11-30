using Ecommerce.Domain.StoreContext.Entities;
using Ecommerce.Domain.StoreContext.Queries;
using System;
using System.Collections.Generic;

namespace Ecommerce.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {

        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult Get(Guid id);
        IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);

    }
}
