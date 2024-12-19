namespace Models;

public class Product
{
    public int Id { get; set; }
    public int FactoryId { get; set; }
    public int FactoryName { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ProductStatus Status { get; set; }
    public List<Material> Materials { get; set; } = [];
    public List<Image> Images { get; set; } = [];
    public List<ProductItem> Items { get; set; } = [];
}