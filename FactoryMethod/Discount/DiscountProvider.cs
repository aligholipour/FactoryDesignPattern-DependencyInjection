using FactoryMethod.Domains;
using FactoryMethod.Models;
using System.Diagnostics.CodeAnalysis;

namespace FactoryMethod.Discount
{
    public abstract class DiscountProvider
    {
        public OrderCalculator OrderCalculator { get; protected set; }
        public abstract string GenerateDiscountDispalyFor(Order order);
    }
    public class OrderCalculator
    {
        private readonly decimal _discountAmount;
        private readonly decimal _weightFee;
        private readonly bool _freeDelivery;
        public ShippingType _shippingType;
        public OrderCalculator(decimal discountAmount, decimal weightFee, bool freeDelivery, ShippingType shippingType)
        {
            _weightFee = weightFee;
            _freeDelivery = freeDelivery;
            _shippingType = shippingType;
            _discountAmount = discountAmount;
        }

        public DiscountCalculatorResponse Calcualtor(Order order)
        {
            decimal totalCalculated = order.Amount;

            if (_weightFee > 50)
            {
                totalCalculated += 5;
            }

            if (!_freeDelivery)
            {
                switch (_shippingType)
                {
                    case ShippingType.Standard: totalCalculated += 10; break;
                    case ShippingType.Express: totalCalculated += 20; break;
                }
            }

            totalCalculated -= _discountAmount;

            return new DiscountCalculatorResponse
            {
                OrderTotalAmount = totalCalculated,
                DiscountAmount = _discountAmount
            };
        }
    }
    public enum ShippingType
    {
        Standard,
        Express
    }
}
