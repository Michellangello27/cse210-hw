using System;

class Program
{
    static void Main()
    {
        // Address & Customer 1 (USA)
        Address address1 = new Address("123 Main St", "Provo", "UT", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        // Order 1
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P100", 1200.00m, 1));
        order1.AddProduct(new Product("Mouse", "P200", 25.00m, 2));

        // Address & Customer 2 (International)
        Address address2 = new Address("Av. El Sol 456", "Cusco", "Cusco", "Peru");
        Customer customer2 = new Customer("Miguel Ángel Cornejo", address2);

        // Order 2
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Tablet", "P300", 600.00m, 1));
        order2.AddProduct(new Product("Keyboard", "P400", 80.00m, 1));
        order2.AddProduct(new Product("Headphones", "P500", 150.00m, 1));

        // Display Order 1
        Console.WriteLine("■══════════════════════════════════════════■");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}");

        // Display Order 2
        Console.WriteLine("■══════════════════════════════════════════■");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
    }
}
