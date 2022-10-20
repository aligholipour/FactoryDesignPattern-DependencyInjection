using FactoryMethod.Discount.Exceptions;
using FactoryMethod.Domains;

namespace FactoryMethod.Discount.Factories
{
    public class WeekendDiscountFactory : DiscountProviderFactory
    {
        private DiscountProvider _discountProvider;
        private readonly DateTime _orderRegistrationDate;
        public WeekendDiscountFactory(DateTime orderRegistrationDate)
        {
            _orderRegistrationDate = orderRegistrationDate;
        }

        public override DiscountProvider CreateDiscountProvider()
        {
            if (!CheckValidDateTimeForWeeken(_orderRegistrationDate))
                throw new NotValidationDateWeekendException("Not validation date for weekend");

            var weekenDiscountAmount = 20M;

            var orderCalculator = new OrderCalculator(weekenDiscountAmount, 100, false, ShippingType.Standard);

            _discountProvider = new OutSystemDiscountService(orderCalculator);

            return _discountProvider;
        }

        private bool CheckValidDateTimeForWeeken(DateTime orderRegistrationDate) =>
             orderRegistrationDate.DayOfWeek == DayOfWeek.Thursday;
    }
}
