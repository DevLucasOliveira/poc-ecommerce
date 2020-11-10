using Ecommerce.Domain.StoreContext.Entities;
using Ecommerce.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ecommerce.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Lucas", "Oliveira");
            var document = new Document("123456789");
            var email = new Email("lucasoliveira.si@outlook.com");

            var c = new Customer(
                name,
                document,
                email,
                "11983367829"
                );

            var mouse = new Product("Mouse", "Rato", "image.png", 49.90m, 10);

            var order = new Order(c);
            //order.AddItem(new OrderItem(mouse, 2));

            order.Place();

            // Verificar se o pedido é valid
            var valid = order.Valid;

            order.Pay();

            order.Ship();

            order.Cancel();
        }


    }
}
