using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Interfaces;

namespace database_service.Controllers;

[ApiController]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet("/products")]
    public async Task<List<Product>> GetProducts([FromQuery] bool byTopSell) => await productService.GetProducts(byTopSell);
    
    [HttpGet("/products/{id}")]
    public async Task<List<Product>> GetProductByFactoryId(int id) => await productService.GetProductByFactoryId(id);
    
    [HttpPost("/product")]
    public async Task<bool> AddProduct([FromBody] Product product) => await productService.AddProduct(product);
    
    /// <summary>
    /// УДАЛЯЙ ЧЕРЕЗ ЭТО, ПРОСТО ПРОКИДЫВАЯ ПОЛНУЮ МОДЕЛЬ ПРОДУКТА СО СТАТУСОМ Deleted
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    [HttpPut("/product")]
    public async Task<bool> UpdateProduct([FromBody] Product product) => await productService.UpdateProduct(product);
    
    [HttpGet("/materials")]
    public async Task<List<Material>> GetAllMaterials() => await productService.GetAllMaterials();
}