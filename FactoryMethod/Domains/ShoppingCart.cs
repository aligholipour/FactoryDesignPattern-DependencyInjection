using FactoryMethod.Discount.Factories;

namespace FactoryMethod.Domains
{
    public class ShoppingCart
    {
        private readonly Order order;
        private readonly DiscountProviderFactory discountProviderFactory;
        public ShoppingCart(Order order, DiscountProviderFactory discountProviderFactory)
        {
            this.order = order;
            this.discountProviderFactory = discountProviderFactory;
        }

        public string BuildShoppingCart()
        {
            var discountProvider = discountProviderFactory.CreateDiscountProvider();

            return discountProvider.GenerateDiscountDispalyFor(order);
        }
    }
}
