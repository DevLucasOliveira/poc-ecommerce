using Ecommerce.Domain.StoreContext.Entities;
using Ecommerce.Domain.StoreContext.Queries;

namespace Ecommerce.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {

        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCount(string document);

    }
}
