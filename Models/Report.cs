namespace Models;

public class Report 
{
    public DateTime Date { get; set; }
    public decimal TotalPrice { get; set; }
    public List<ReportItem> Items { get; set; } = new List<ReportItem>();
}