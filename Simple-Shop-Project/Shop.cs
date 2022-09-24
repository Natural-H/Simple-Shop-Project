using AutoMapper;
using System.Globalization;

namespace SimpleShop;

class Shop
{
    //private Product _Max_Values = new();

    public List<Product> Products { get; set; } = new();
    public List<Product> CarShop { get; set; } = new();

    readonly Mapper Mapper = new(new MapperConfiguration(cfg => cfg.CreateMap<Product, Product>()));

    public Action GetUserEntry() => Console.ReadKey(intercept: true).Key switch
    {
        ConsoleKey.A => ShowProducts,
        ConsoleKey.B => ShowShppingCar,
        ConsoleKey.C => AddToCart,
        ConsoleKey.E => RemoveFromCar,
        ConsoleKey.D => ShowProductInfo,
        _ => GetUserEntry(),
    };

    public void ShowProducts()
    {
        Console.WriteLine(" - All products -\n");

        Products.ForEach(product => product.ShowInfo(GetMaxValues(Products), HideTotalPrice: true));
    }

    public void ShowShppingCar()
    {
        if (!CarShop.Any())
        {
            Console.WriteLine("Shopping car empty!");
            return;
        }

        Console.WriteLine(" - Shopping car -\n");

        CarShop.ForEach(product => product.ShowInfo(GetMaxValues(CarShop), HideIndex: true));

        Console.WriteLine($"\nTotal value: " +
            $"{CarShop.Sum(product => product.Amount * product.Price).ToString("C", CultureInfo.CurrentCulture)}");
    }

    public void AddToCart()
    {
        Console.WriteLine("What do you want to add?");

        if (int.TryParse(Console.ReadLine(), out int Id))
        {
            var product = Products.Find(x => x.Id.Equals(Id));

            if (product is null)
            {
                Console.WriteLine("That product does not exist!");
                return;
            }

            if (CarShop.Exists(x => x.Id.Equals(product.Id)))
            {
                if (product.Amount <= 0)
                {
                    Console.WriteLine("\nThere is no items left!");
                    return;
                }

                product.Amount--;
                CarShop[CarShop.FindIndex(x => x.Id.Equals(Id))].Amount++;
                Console.WriteLine("Added!");
                return;
            }
            else
            {
                var _product = Mapper.Map<Product>(product);
                _product.Amount = 1;

                if (product.Amount <= 0)
                {
                    Console.WriteLine("There is no items left!");
                    return;
                }

                product.Amount--;
                CarShop.Add(_product);
                Console.WriteLine("Added!");
                return;
            }
        }

        Console.WriteLine("That's not an index!");
    }

    void RemoveFromCar()
    {
        if (!CarShop.Any())
        {
            Console.WriteLine("Car shop is empty!");
            return;
        }

        Console.WriteLine("Which one?");

        if (int.TryParse(Console.ReadLine(), out int Id))
        {
            var Product = CarShop.Find(x => x.Id.Equals(Id));

            if (Product is null)
            {
                Console.WriteLine("The product was not found!");
                return;
            }

            Product.Amount--;
            Products[Products.FindIndex(x => x.Id.Equals(Product.Id))].Amount++;

            Console.WriteLine("Removed!");

            if (Product.Amount <= (0))
                CarShop.Remove(Product);

            return;
        }

        Console.WriteLine("That's not an index!");
    }
    
    void ShowProductInfo()
    {
        Console.WriteLine("Which one?");
        if (int.TryParse(Console.ReadLine(), out int Id))
        {
            var product = Products.Find(x => x.Id.Equals(Id));

            if (product is null)
            {
                Console.WriteLine("That product does not exist!\n");
                return;
            }

            product.ShowFullInfo();
            return;
        }

        Console.WriteLine("That's not an index!\n");
    }

    private static Product GetMaxValues(List<Product> list) => new()
    {
        Id = (int)list.Max(x => x.Id),
        Name = list.Aggregate(string.Empty, (Max, It) => Max.Length > It.Name.Length ? Max : It.Name),
        Price = list.Max(x => x.Price),
        Amount = list.Max(x => x.Amount)
    };
}
