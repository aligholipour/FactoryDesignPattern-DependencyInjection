using FactoryMethod.Domains;

namespace FactoryMethod.Discount
{
    public class OwnSystemDiscountService : DiscountProvider
    {
        public override string GenerateDiscountDispalyFor(Order order)
        {
            return $"Discount ";
        }
    }
}
