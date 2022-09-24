using SimpleShop;
using Figgle;

Shop Shop = new();
SeedData.Seed(Shop);

while (true)
{
    Console.WriteLine(FiggleFonts.Epic.Render("Title  shop."));
    Console.WriteLine("Press A to Show Products\n" +
                      "Press B to Show your Shopping Car\n" +
                      "Press C to Add something to you Shopping Car\n" +
                      "Press E to Remove something from you Shopping Car\n" +
                      "Press D to Show product Info\n");

    Shop.GetUserEntry().Invoke();

    Console.WriteLine("Press a key to continue...");
    Console.ReadKey(true);
    Console.Clear();
}
