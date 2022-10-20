namespace FactoryMethod.Discount.Exceptions
{
    public class TheNumberOfProductsIsLessThanThreeException : Exception
    {
        public TheNumberOfProductsIsLessThanThreeException(string message) : base(message)
        {
        }
    }
}
