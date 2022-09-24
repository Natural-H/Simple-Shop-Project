using System.Globalization;

namespace SimpleShop;

class Product
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Amount { get; set; }

    public void ShowInfo(Product _Max, bool HideIndex = false, bool HideTotalPrice = false) =>
        Console.WriteLine((HideIndex ? string.Empty : $"Index: {Id.ToString().PadRight((int)Math.Floor(Math.Log10(_Max.Id) + 1))} | ") +
        $"Name: {Name.PadRight(_Max.Name.Length)} | " +
        $"Price by unit: {Price.ToString("C", CultureInfo.CurrentCulture).PadRight((int)Math.Floor(Math.Log10(_Max.Price) + 5 + (int)(Math.Floor(Math.Log10(_Max.Price)) / 3)))} | " +
        $"Amount: {Amount.ToString().PadRight((int)Math.Floor(Math.Log10(_Max.Amount) + 1))}" +
        (HideTotalPrice ? string.Empty : $" | Total Price: {(Price * Amount).ToString("C", CultureInfo.CurrentCulture)}"));

    public void ShowFullInfo() => Console.WriteLine($"\nId: {Id}\n" +
        $"Name: {Name}" +
        $"\nDescription: \n{Description}\n\n" +
        $"Price: {Price.ToString("C", CultureInfo.CurrentCulture)}\n" +
        $"Amount: {Amount}\n");
}
