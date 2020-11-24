using Ecommerce.Domain.StoreContext.Entities;
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

        public void Save(Customer customer)
        {
             
        }
    }
}
