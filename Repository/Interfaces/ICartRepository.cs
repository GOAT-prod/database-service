using Models;

namespace Repository.Interfaces;

public interface ICartRepository
{
    Task<Cart?> GetCart(int id);
    Task<List<CartItem>> GetCartItems(int id);
    Task<bool> AddCartItem(CartItem cartItems);
    Task<bool> UpdateCartItem(CartItem cartItem);
    Task<bool> DeleteCartItems(List<int> ids);
    Task<int> CreateCart(int userId);
}