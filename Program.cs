using Figgle;

Shop Shop = new();
SeededData.SeedData(Shop);
Console.WriteLine(FiggleFonts.Standard.Render("Welcome  !"));

while (true)
{
    Console.WriteLine("Press A to Show Products\n" +
                      "Press B to Show your Shopping Car\n" +
                      "Press C to Add Something to you Shopping Car\n" +
                      "Press D to Show product Info\n");

    Shop.GetUserEntry().Invoke();

    Console.WriteLine("Press a key to continue...");
    Console.ReadKey(true);
    Console.Clear();
}
