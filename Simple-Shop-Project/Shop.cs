using AutoMapper;
using System.Globalization;

class Shop
{
    public List<Product> Products { get; set; } = new();
    public List<Product> CarShop { get; set; } = new();

    readonly Mapper Mapper = new(new MapperConfiguration(cfg => cfg.CreateMap<Product, Product>()));

    public Action GetUserEntry() => Console.ReadKey(intercept: true).KeyChar switch
    {
        'a' => ShowProducts,
        'b' => ShowShppingCar,
        'c' => AddToCart,
        'd' => ShowProductInfo,
        _ => GetUserEntry(),
    };

    public void ShowProducts()
    {
        Console.WriteLine(" - All products -\n");

        Products.ForEach(product => product.ShowInfo());

        //foreach (var product in Products)
        //    product.ShowInfo();
    }

    public void ShowShppingCar()
    {
        if (!CarShop.Any())
        {
            Console.WriteLine("Shopping car empty!");
            return;
        }

        Console.WriteLine(" - Shopping car -\n");

        //foreach (var product in Products)
        //    product.ShowInfo(ForCustomer: true);

        CarShop.ForEach(product => product.ShowInfo(ForCustomer: true));

        Console.WriteLine($"\nTotal value: " +
            $"{CarShop.Sum(product => product.Amount * product.Price).ToString("C", CultureInfo.CurrentCulture)}");
    }

    public void AddToCart()
    {
        Console.WriteLine("What do you want to add?");

        if (int.TryParse(Console.ReadLine(), out int index))
        {
            var product = Products.Find(x => x.Id.Equals(index));

            if (product is null)
            {
                Console.WriteLine("That product does not exists!");
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
                CarShop[CarShop.FindIndex(x => x.Id.Equals(index))].Amount++;
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

        Console.WriteLine("That's not an index");
    }
    
    void ShowProductInfo()
    {
        Console.WriteLine("Which one?");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            var product = Products.Find(x => x.Id.Equals(index));

            if (product is null)
            {
                Console.WriteLine("That product does not exists!\n");
                return;
            }

            product.ShowFullInfo();
            return;
        }

        Console.WriteLine("That's not a number!\n");
    }
}
