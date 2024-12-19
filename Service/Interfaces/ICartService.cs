using Models;

namespace Service.Interfaces;

public interface ICartService
{
    Task<Cart> GetCart(int userId);
    Task<bool> AddCartItem(CartItem cartItem);
    Task<bool> UpdateCartItem(CartItem cartItem);
    Task<bool> DeleteCartItem(int id);
    Task<bool> ClearCart(int userId);
}