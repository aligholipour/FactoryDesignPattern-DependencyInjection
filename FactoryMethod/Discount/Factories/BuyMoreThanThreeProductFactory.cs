using FactoryMethod.Discount.Exceptions;

namespace FactoryMethod.Discount.Factories
{
    public class BuyMoreThanThreeProductFactory : DiscountProviderFactory
    {
        private DiscountProvider _discountProvider;
        private readonly int _orderItemCount;
        public BuyMoreThanThreeProductFactory(int orderItemCount)
        {
            _orderItemCount = orderItemCount;
        }

        public override DiscountProvider CreateDiscountProvider()
        {
            if (_orderItemCount <= 3)
                throw new TheNumberOfProductsIsLessThanThreeException("The number of products is less than 3");

            var discountAmount = 10M;

            var orderCalculator = new OrderCalculator(discountAmount, 200, true, ShippingType.Express);

            _discountProvider = new OutSystemDiscountService(orderCalculator);

            return _discountProvider;
        }
    }
}
