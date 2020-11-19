using Ecommerce.Domain.StoreContext.Entities;
using Ecommerce.Domain.StoreContext.Repositories;

namespace Ecommerce.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
