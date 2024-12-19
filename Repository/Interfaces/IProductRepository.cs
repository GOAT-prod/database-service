using Models;

namespace Repository.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetProducts();
    Task<List<ProductItem>> GetProductItems(int id);
    Task<List<Material>> GetMaterials(int id);
    Task<List<Image>> GetImages(int id);
    Task<List<Material>> GetAllMaterials();
    Task<int> AddProduct(Product product);
    Task<bool> AddProductItem(ProductItem productItem);
    Task<bool> AddMaterials(Material material, int productId);
    Task<bool> AddImage(Image image);
    Task<bool> UpdateProduct(Product product);
    Task<bool> UpdateProductItem(ProductItem productItem);
    Task<bool> UpdateImage(Image image);
    Task<bool> DeleteProductMaterials(int id);
}