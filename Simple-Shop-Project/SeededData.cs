namespace SimpleShop;

static class SeedData
{
    public static void Seed(Shop shop)
    {
        if (shop is null)
            throw new ArgumentNullException(nameof(shop));

        shop.Products ??= new List<Product>();

        shop.Products.Add(new()
        {
            Id = 0,
            Name = "Apple",
            Description = "A juicy apple\nHealthy for everyone!",
            Price = 12d,
            Amount = 12
        });

        shop.Products.Add(new()
        {
            Id = 1,
            Name = "Another apple",
            Description = "Another apple?\nWhen the moon hits your eye, like a big pizza pie, that's...",
            Price = 11d,
            Amount = 3
        });

        shop.Products.Add(new()
        {
            Id = 2,
            Name = "Orange",
            Description = "Just a juicy orange\nThere's no more than that",
            Price = 10.5d,
            Amount = 20
        });

        shop.Products.Add(new()
        {
            Id = 3,
            Name = "Pants",
            Description = "Pants in a Fruit shop?\nJust if someone needs it",
            Price = 22.5d,
            Amount = 7
        });

        shop.Products.Add(new()
        {
            Id = 4,
            Name = "Mug",
            Description = "I don't know if someone will need this\nMaybe it will be Mug Root Beer or something",
            Price = 9999.99d,
            Amount = 1
        });
    }
}
