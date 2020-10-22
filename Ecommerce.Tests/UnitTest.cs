using Ecommerce.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecommerce.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer(
                "Lucas",
                "Oliveira",
                "12345678876",
                "lucas@silva.com",
                "13333333333333",
                "Rua devs, 1020"
                );

            var order = new Order(c);
        }


    }
}
