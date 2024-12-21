namespace Models;

public class Cart 
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal TotalSelectedPrice { get; set; }
    public List<CartItem> CartItems { get; set; } = [];
}