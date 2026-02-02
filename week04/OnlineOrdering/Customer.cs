namespace OnlineOrdering;

public class Customer
{
    private string _name;
    // Composition: A Customer "has-an" Address, demonstrating object relationships.
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName() => _name;

    // Delegation: The Customer class does not try to validate address logic itself.
    // Instead, it delegates that responsibility to the Address object.
    public bool IsInUSA() => _address.IsInUSA();

    public string GetAddressString() => _address.GetFullAddress();
}