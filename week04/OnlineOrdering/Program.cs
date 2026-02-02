using OnlineOrdering;

// Setup Data

// Order 1: Domestic (USA) address to test $5 shipping logic.
Address addr1 = new Address("123 Maple St", "Rexburg", "ID", "USA");
Customer cust1 = new Customer("John Doe", addr1);
Order order1 = new Order(cust1);
order1.AddProduct(new Product("Laptop", "L44", 999.99, 1));
order1.AddProduct(new Product("Mouse", "M01", 25.50, 1));

// Order 2: International address to test $35 shipping logic.
Address addr2 = new Address("456 Sakura Ln", "Tokyo", "Kanto", "Japan");
Customer cust2 = new Customer("Hiroshi Tanaka", addr2);
Order order2 = new Order(cust2);
order2.AddProduct(new Product("Headphones", "H-9", 150.00, 2));
order2.AddProduct(new Product("Keyboard", "K-RGB", 85.00, 1));

List<Order> orders = new List<Order> { order1, order2 };

// Display Results
// The main loop treats every order the same, illustrating the power of Abstraction.
foreach (var order in orders)
{
    Console.WriteLine(order.GetPackingLabel());
    Console.WriteLine(order.GetShippingLabel());
    Console.WriteLine($"Total Price: ${order.CalculateTotal():0.00}");
    Console.WriteLine(new string('=', 30));
}