using Models;

namespace Service.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetProducts(bool byTopSell = false);
    Task<List<Product>> GetProductByFactoryId(int id);
    Task<bool> AddProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<List<Material>> GetAllMaterials();
}