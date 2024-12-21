namespace Models;

public class Order 
{
    public Guid Id { get; set; } 
    public OrderType Type { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string Username { get; set; } = string.Empty;
    public decimal TotalWeight { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal AveragePrice { get; set; }
}