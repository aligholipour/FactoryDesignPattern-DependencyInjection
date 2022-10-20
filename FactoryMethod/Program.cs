using FactoryMethod.Discount.Factories;
using FactoryMethod.Domains;

Console.Write("Recipient Address: ");
var address = Console.ReadLine().Trim();

Console.Write("Recipient City: ");
var city = Console.ReadLine().Trim();


var order = new Order
{
    Id = 1,
    OrderRegistrationDate = DateTime.Now,
    Address = new Address
    {
        To = address,
        City = city,
    }
};

order.OrderItems.Add(new OrderItem { Id = 1, Name = "Laptop", Price = 100M, Count = 2, OrderId = 1 });
order.OrderItems.Add(new OrderItem { Id = 2, Name = "Mobile", Price = 60M, Count = 2, OrderId = 1 });

var weekend = new ShoppingCart(order, new WeekendDiscountFactory(order.OrderRegistrationDate));
var BuildShoppingCart = weekend.BuildShoppingCart();

Console.WriteLine(BuildShoppingCart);
