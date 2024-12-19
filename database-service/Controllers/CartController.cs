using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Interfaces;

namespace database_service.Controllers;

[ApiController]
public class CartController(ICartService cartService) : ControllerBase
{ 
    [HttpGet("/cart/{userId}")]
    public async Task<Cart> GetCart(int userId) => await cartService.GetCart(userId);
    
    [HttpPost("/cart/item")]
    public async Task<bool> AddCartItem(CartItem cartItem) => await cartService.AddCartItem(cartItem);
    
    [HttpPut("/cart/item")]
    public async Task<bool> UpdateCartItem(CartItem cartItem) => await cartService.UpdateCartItem(cartItem);
    
    [HttpDelete("/cart/item/{id}")]
    public async Task<bool> DeleteCartItem(int id) => await cartService.DeleteCartItem(id);
    
    [HttpDelete("/cart/clear/{userId}")]
    public async Task<bool> ClearCart(int userId) => await cartService.ClearCart(userId);
}