using System;
using System.Collections.Generic;

class Product
{
    private string _name, _id;
    private double _price;
    private int _quantity;

    public Product(string name, string id, double price, int quantity)
    {
        _name = name; _id = id; _price = price; _quantity = quantity;
    }

    public double TotalCost() => _price * _quantity;
    public string Name() => _name;
    public string ID() => _id;
}

class Address
{
    private string _street, _city, _state, _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street; _city = city; _state = state; _country = country;
    }

    public bool IsUSA() => _country == "USA";
    public string FullAddress() => $"{_street}\n{_city}, {_state}\n{_country}";
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name; _address = address;
    }

    public bool IsUSA() => _address.IsUSA();
    public string Name() => _name;
    public string Address() => _address.FullAddress();
}

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = products; _customer = customer;
    }

    public double TotalCost()
    {
        double total = 0;
        _products.ForEach(p => total += p.TotalCost());
        return total + (_customer.IsUSA() ? 5 : 35);
    }

    public string PackingLabel()
    {
        string label = "Packing Label:\n";
        _products.ForEach(p => label += $"{p.Name()} ({p.ID()})\n");
        return label;
    }

    public string ShippingLabel() => $"Shipping Label:\n{_customer.Name()}\n{_customer.Address()}";
}

class Program
{
    static void Main(string[] args)
    {
        var product1 = new Product("Laptop", "123ABC", 1200.50, 1);
        var product2 = new Product("Mouse", "456DEF", 25.99, 2);
        var product3 = new Product("Keyboard", "789GHI", 45.99, 1);

        var address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        var address2 = new Address("456 Elm St", "Vancouver", "BC", "Canada");

        var customer1 = new Customer("John Doe", address1);
        var customer2 = new Customer("Jane Smith", address2);

        var order1 = new Order(new List<Product> { product1, product2 }, customer1);
        var order2 = new Order(new List<Product> { product2, product3 }, customer2);

        Console.WriteLine(order1.PackingLabel());
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.TotalCost():0.00}\n");

        Console.WriteLine(order2.PackingLabel());
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.TotalCost():0.00}\n");
    }
}
