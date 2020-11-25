using Ecommerce.Domain.StoreContext.Entities;
using Ecommerce.Domain.StoreContext.Queries;
using Ecommerce.Domain.StoreContext.Repositories;

namespace Ecommerce.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return null;
        }

        public void Save(Customer customer)
        {
             
        }
    }
}
