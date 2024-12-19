namespace Models;

public class ReportItem 
{
    public string ProductName { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public int Size { get; set; }
    public int TotalCount { get; set; }
    public decimal TotalPrice { get; set; }
}