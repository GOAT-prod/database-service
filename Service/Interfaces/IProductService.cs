using Models;

namespace Service.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetProducts();
    Task<bool> AddProduct(Product product);
    Task<bool> UpdateProduct(Product product);
}