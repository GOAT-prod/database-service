using Microsoft.Extensions.Logging;
using Models;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service;

public class ProductService(IProductRepository productRepository, ILogger logger) : IProductService
{
    public async Task<List<Product>> GetProducts()
    {
        var products = await productRepository.GetProducts();
        products.ForEach(async void (p) =>
        {
            try
            {
                p.Images = await productRepository.GetImages(p.Id);
                p.Materials = await productRepository.GetMaterials(p.Id);
                p.Items = await productRepository.GetProductItems(p.Id);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
        });
        
        return products;
    }

    public async Task<bool> AddProduct(Product product)
    {
        
    }
}