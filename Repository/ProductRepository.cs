using DataAccess.Intefaces;
using Models;
using Repository.Interfaces;

namespace Repository;

public class ProductRepository(IPostgresContext postgresContext) : IProductRepository
{
    public async Task<List<Product>> GetProducts() =>
        await postgresContext.Select<Product>(Scripts.Scripts.GetProducts);

    public async Task<List<Product>> GetProductByTopSell() => 
        await postgresContext.Select<Product>(Scripts.Scripts.GetProductsByTopSell);

    public async Task<List<Product>> GetProductByFactoryId(int id) =>
        await postgresContext.Select<Product>(Scripts.Scripts.GetProductsByFactoryId, new { id });

    public async Task<List<ProductItem>> GetProductItems(int id) =>
        await postgresContext.Select<ProductItem>(Scripts.Scripts.GetProductItemsByProductId, new { id });

    public async Task<List<ProductItem>> GetProductItemsByIds(IEnumerable<int> ids) =>
        await postgresContext.Select<ProductItem>(Scripts.Scripts.GetProductItemByIds, new { ids = ids.ToList() });

    public async Task<List<Material>> GetMaterials(int id) =>
        await postgresContext.Select<Material>(Scripts.Scripts.GetProductMaterials, new { id });

    public async Task<List<Image>> GetImages(int id) =>
        await postgresContext.Select<Image>(Scripts.Scripts.GetImagesByProductId, new { id });

    public async Task<List<Material>> GetAllMaterials() =>
        await postgresContext.Select<Material>(Scripts.Scripts.GetAllMaterials);

    public async Task<int> AddProduct(Product product) => await postgresContext.Get<int>(Scripts.Scripts.AddProduct, new
    {
        name = product.Name,
        brand = product.Brand,
        price = product.Price,
        status = product.Status.ToString(),
        factory_id = product.FactoryId,
    });

    public async Task<bool> AddProductItem(ProductItem productItem) => await postgresContext.Exec(
        Scripts.Scripts.AddProductItem, new
        {
            product_id = productItem.ProductId,
            color = productItem.Color,
            size = productItem.Size,
            weight = productItem.Weight,
            quantity = productItem.Count,
        });

    public async Task<bool> AddMaterials(Material material, int productId) => await postgresContext.Exec(
        Scripts.Scripts.AddProductMaterials, new
        {
            product_id = productId,
            material_id = material.Id
        });

    public async Task<bool> AddImage(Image image) => await postgresContext.Exec(Scripts.Scripts.AddImages, new
    {
        product_id = image.ProductId,
        url = image.Url,
    });

    public async Task<bool> UpdateProduct(Product product) => await postgresContext.Exec(Scripts.Scripts.UpdateProduct,
        new
        {
            name = product.Name,
            status = product.Status,
            price = product.Price,
            id = product.Id,
        });

    public async Task<bool> UpdateProductItem(ProductItem productItem) => await postgresContext.Exec(
        Scripts.Scripts.UpdateProductItem, new
        {
            color = productItem.Color,
            size = productItem.Size,
            weight = productItem.Weight,
            id = productItem.Id,
        });

    public async Task<bool> UpdateImage(Image image) => await postgresContext.Exec(Scripts.Scripts.UpdateImage, new
    {
        url = image.Url,
        id = image.Id
    });

    public async Task<bool> DeleteProductMaterials(int id) =>
        await postgresContext.Exec(Scripts.Scripts.DeleteProductMaterials, new { id });
}