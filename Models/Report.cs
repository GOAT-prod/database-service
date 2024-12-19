namespace Models;

public class Report 
{
    public DateTime Date { get; set; }
    public decimal TotalPrice { get; set; }
    public List<ReportItem> Items { get; set; } = new List<ReportItem>();
}

public class DbReport
{
    public DateTime Date { get; set; }
    public decimal TotalPrice { get; set; }
    public string Items { get; set; } = string.Empty;
}