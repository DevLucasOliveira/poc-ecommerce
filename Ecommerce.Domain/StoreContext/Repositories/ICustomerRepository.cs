using Ecommerce.Domain.StoreContext.Entities;

namespace Ecommerce.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {

        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);

    }
}
