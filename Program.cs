// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Price = 15.00M,
        Sold = false,
        Color = "Classic Brown",
        StockDate = new DateTime(2022, 10, 20),
        ManufactureYear = 2010,
        Condition = 4.2
    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 12.00M,
        Sold = false,
        Color = "Black and Silver",
        StockDate = new DateTime(2024, 5, 14),
        ManufactureYear = 2019,
        Condition = 5
    },
    new Product()
    {
        Name = "Frisbee",
        Price = 3.00M,
        Sold = false,
        Color = "Neon Yellow",
        StockDate = new DateTime(2022, 9, 10),
        ManufactureYear = 2020,
        Condition = 3.7
    },
    new Product()
    {
        Name = "Camp Hammock",
        Price = 58.75M,
        Sold = false,
        Color = "Safety Orange",
        StockDate = new DateTime(2024, 3, 4),
        ManufactureYear = 2023,
        Condition = 4.5
    },
    new Product()
    {
        Name = "Bicycle",
        Price = 100.00M,
        Sold = false,
        Color = "Cherry Red",
        StockDate = new DateTime(2023, 7, 25),
        ManufactureYear = 2021,
        Condition = 4.1
    },
    new Product()
    {
        Name = "Running Shoes",
        Price = 30.25M,
        Sold = false,
        Color = "Pink and Teal",
        StockDate = new DateTime(2024, 1, 5),
        ManufactureYear = 2023,
        Condition = 3.5
    }
};

string greeting = @"Welcome to Thrown For a Loop
Your one-stop shop for used sporting equipment";

Console.WriteLine(greeting);

// OPTION TO VIEW PRODUCT DETAILS OR EXIT APP
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
}

// VIEW AND SELECT PRODUCT DETAILS
void ViewProductDetails()
{
    ListProducts(); 

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }

    DateTime now = DateTime.Now;

    TimeSpan timeInStock = now - chosenProduct.StockDate;

    Console.WriteLine(@$"You chose: 
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old. 
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}