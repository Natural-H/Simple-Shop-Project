using System.Globalization;

class Product
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Amount { get; set; }

    public void ShowInfo(bool HideIndex = false, bool HideTotalPrice = false) =>
        Console.WriteLine((HideIndex ? string.Empty : $"Index: {Id} | ") +
        $"Name: {Name} | " +
        $"Price by unit: {Price.ToString("C", CultureInfo.CurrentCulture)} | " +
        $"Amount: {Amount}" +
        (HideTotalPrice ? String.Empty : $" | Total Price: {(Price * Amount).ToString("C", CultureInfo.CurrentCulture)}"));

    public void ShowFullInfo() => Console.WriteLine($"\nId: {Id}\n" +
        $"Name: {Name}" +
        $"\nDescription: \n{Description}\n\n" +
        $"Price: {Price.ToString("C", CultureInfo.CurrentCulture)}\n" +
        $"Amount: {Amount}\n");
}
