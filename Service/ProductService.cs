using Microsoft.Extensions.Logging;
using Models;
using Repository.Interfaces;
using Service.Interfaces;
using System.Threading.Tasks;

namespace Service;

public class ProductService(IProductRepository productRepository, ILogger logger) : IProductService
{
    public async Task<List<Product>> GetProducts()
    {
        var products = await productRepository.GetProducts();
        var tasks = products.Select(async p =>
        {
            try
            {
                p.Images = await productRepository.GetImages(p.Id);
                p.Materials = await productRepository.GetMaterials(p.Id);
                p.Items = (await productRepository.GetProductItems(p.Id)).OrderBy(i => i.Id).ToList();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
        }).ToList();

        await Task.WhenAll(tasks);

        return products.OrderBy(i => i.Id).ToList();
    }

    public async Task<List<Product>> GetProductByFactoryId(int id)
    {
        var products = await productRepository.GetProductByFactoryId(id);
        var tasks = products.Select(async p =>
        {
            try
            {
                p.Images = await productRepository.GetImages(p.Id);
                p.Materials = await productRepository.GetMaterials(p.Id);
                p.Items = (await productRepository.GetProductItems(p.Id)).OrderBy(i => i.Id).ToList();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
        }).ToList();

        await Task.WhenAll(tasks);

        return products.OrderBy(i => i.Id).ToList();
    }

    public async Task<bool> AddProduct(Product product)
    {
        product.Id = await productRepository.AddProduct(product);
        product.Items.ForEach(i => { i.ProductId = product.Id; });
        product.Images.ForEach(i => { i.ProductId = product.Id; });

        var addItemsTasks = product.Items.Select(productRepository.AddProductItem).ToList();
        var addImagesTasks = product.Images.Select(productRepository.AddImage).ToList();
        var addMaterialsTasks = product.Materials.Select(m => productRepository.AddMaterials(m, product.Id)).ToList();

        await Task.WhenAll(addItemsTasks);
        await Task.WhenAll(addImagesTasks);
        await Task.WhenAll(addMaterialsTasks);

        return true;
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        _ = await productRepository.UpdateProduct(product);
        
        var itemsForAdd = product.Items.Where(i => i.Id == 0).ToList();
        var itemsForUpdate = product.Items.Where(i => i.Id != 0).ToList();
        
        var imagesForAdd = product.Images.Where(i => i.Id == 0).ToList();
        var imagesForUpdate = product.Images.Where(i => i.Id != 0).ToList();
        
        itemsForAdd.ForEach(i => { i.ProductId = product.Id; });
        imagesForAdd.ForEach(i => { i.ProductId = product.Id; });

        var updateProductItemsTasks = itemsForUpdate.Select(productRepository.UpdateProductItem).ToList();
        var addProductItemsTasks = itemsForAdd.Select(productRepository.UpdateProductItem).ToList();
        
        var updateImagesTasks = imagesForUpdate.Select(productRepository.UpdateImage).ToList();
        var addImagesTasks = imagesForAdd.Select(productRepository.UpdateImage).ToList();

        await Task.WhenAll(addProductItemsTasks);
        await Task.WhenAll(updateProductItemsTasks);
        
        await Task.WhenAll(addImagesTasks);
        await Task.WhenAll(updateImagesTasks);

        var ok = await productRepository.DeleteProductMaterials(product.Id);

        var addMaterialsTasks = product.Materials.Select(m => productRepository.AddMaterials(m, product.Id)).ToList();
        await Task.WhenAll(addMaterialsTasks);

        return ok;
    }
}