namespace OnlineOrdering;

public class Address
{
    // Encapsulation: Private member variables protect the internal data from external interference.
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    // Abstraction: This method hides the complex logic of identifying if a location is in the USA.
    // The rest of the program simply calls this method without needing to know the specific strings used.
    public bool IsInUSA() => _country.ToLower() == "usa" || _country.ToLower() == "united states";

    // Returns the address formatted with newlines for professional display.
    public string GetFullAddress() => $"{_street}\n{_city}, {_state}\n{_country}";
}