using Ecommerce.Shared.Entities;

namespace Ecommerce.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;


            if (product.QuantityOnHand > quantity)
                AddNotification("Quantity", "Produto fora de estoque");

                //Notifications.Add("Quantidade", "Produto fora de estoque");
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        //public IDictionary<string, string> Notifications { get; set; }
    }
}
