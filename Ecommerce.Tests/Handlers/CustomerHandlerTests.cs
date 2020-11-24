using Ecommerce.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Ecommerce.Domain.StoreContext.Handlers;
using Ecommerce.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecommerce.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {

        [TestMethod]
        public void ShouldRegistrCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "André";
            command.LastName = "Baltiere";
            command.Document = "48971819847";
            command.Email = "andrebaltie@ok.com";
            command.Phone = "11222889398";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handler(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.Valid);
        }

    }
}
