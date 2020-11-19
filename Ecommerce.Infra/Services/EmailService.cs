using Ecommerce.Domain.StoreContext.Services;
using System;

namespace Ecommerce.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
