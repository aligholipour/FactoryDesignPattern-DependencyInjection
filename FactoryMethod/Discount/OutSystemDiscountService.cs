using FactoryMethod.Discount.Exceptions;
using FactoryMethod.Domains;

namespace FactoryMethod.Discount
{
    public class OutSystemDiscountService : DiscountProvider
    {
        public OutSystemDiscountService(OrderCalculator discountCalculator)
        {
            OrderCalculator = discountCalculator;
        }

        public override string GenerateDiscountDispalyFor(Order order)
        {
            var identificationkey = Identificationkey();

            if (!Validationkey(identificationkey))
                throw new NotValidationException("Your identification key is not valid");

            var orderCalculate = OrderCalculator.Calcualtor(order);

            return $"Identification key: {identificationkey} {Environment.NewLine}" +
                $"Order total: {orderCalculate.OrderTotalAmount} {Environment.NewLine}" +
                $"Order count: {order.OrderItems.Count} {Environment.NewLine}" +
                $"Discount amount: {orderCalculate.DiscountAmount}";
        }
        private string Identificationkey()
        {
            // Call Api
            return $"Key-{Guid.NewGuid()}";
        }
        private bool Validationkey(string identificationkey)
        {
            // Check validation key
            return true;
        }
    }
}
