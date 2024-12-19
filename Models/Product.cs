namespace Models;

public class Product 
{
    public int Id { get; set; }
    public Factory FactoryInfo { get; set; } = new();
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ProductStatus Status { get; set; }
    public List<Material> Materials { get; set; } = [];
    public List<Image> Images { get; set; } = [];
    public List<ProductItem> Items { get; set; } = [];
}