using Ecommerce.Domain.StoreContext.Services;

namespace Ecommerce.Tests.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
        }
    }
}
