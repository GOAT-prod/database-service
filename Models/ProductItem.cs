namespace Models;

public class ProductItem 
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Color { get; set; } = string.Empty;
    public int Size { get; set; }
    public decimal Weight { get; set; }
    public int Count { get; set; }
}