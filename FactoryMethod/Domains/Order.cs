namespace FactoryMethod.Domains
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public int Id { get; set; }
        public int Total => OrderItems.Sum(x => x.Count);
        public decimal Amount => OrderItems.Sum(item => item.Price * item.Count);
        public Address Address { get; set; }
        public DateTime OrderRegistrationDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }


    }
    public class Address
    {
        public string To { get; set; }
        public string City { get; set; }
    }
}
