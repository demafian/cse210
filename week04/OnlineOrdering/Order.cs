namespace OnlineOrdering;

public class Order
{
    // A list of Product objects, demonstrating a one-to-many relationship.
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product) => _products.Add(product);

    // Business Logic: Encapsulated within the Order class to manage shipping rules.
    public double CalculateTotal()
    {
        double subtotal = 0;
        // The Order asks each Product for its own subtotal (Abstraction).
        foreach (var p in _products) subtotal += p.GetTotalCost();

        // One-time shipping logic based on customer location.
        double shipping = _customer.IsInUSA() ? 5 : 35;

        return subtotal + shipping;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var p in _products) label += $"- {p.GetLabelInfo()}\n";
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddressString()}\n";
    }
}