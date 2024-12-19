namespace Models;

public class CartItem 
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductItemId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Color { get; set; } = string.Empty;
    public int Size { get; set; }
    public int SelectCount { get; set; }
    public bool IsSelected { get; set; }
}