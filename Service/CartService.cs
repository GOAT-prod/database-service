using Models;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service;

public class CartService(ICartRepository cartRepository) : ICartService
{
    public async Task<Cart> GetCart(int userId)
    {
        var cart = await cartRepository.GetCart(userId);
        if (cart == null)
        {
            _ = await cartRepository.CreateCart(userId);
            
            cart = await cartRepository.GetCart(userId);
        }
        
        var cartItems = await cartRepository.GetCartItems(cart!.Id);
        cart.CartItems = cartItems.OrderBy(i => i.Id).ToList();
        
        return cart;
    }
    
    public async Task<bool> AddCartItem(CartItem cartItem) => await cartRepository.AddCartItem(cartItem);
    
    public async Task<bool> UpdateCartItem(CartItem cartItem) => await cartRepository.UpdateCartItem(cartItem);
    
    public async Task<bool> DeleteCartItem(int id) => await cartRepository.DeleteCartItems([id]);

    public async Task<bool> ClearCart(int userId)
    {
        var cart = await cartRepository.GetCart(userId);
        var cartItems = await cartRepository.GetCartItems(cart.Id);
        
        return await cartRepository.DeleteCartItems(cartItems.Select(i => i.Id).ToList());
    }
}