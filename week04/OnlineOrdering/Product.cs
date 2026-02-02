namespace OnlineOrdering;

public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string id, double price, int qty)
    {
        _name = name;
        _productId = id;
        _price = price;
        _quantity = qty;
    }

    // Encapsulation: The calculation for total cost is kept inside the Product class.
    // This prevents external classes from having to know the formula (price * quantity).
    public double GetTotalCost() => _price * _quantity;

    public string GetLabelInfo() => $"{_name} (ID: {_productId})";
}