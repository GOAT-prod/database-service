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
    
    public async Task<bool> AddCartItem(CartItem cartItem)
    {
        var cartItems = await cartRepository.GetCartItems(cartItem.CartId);

        if (!cartItems.Exists(i => i.ProductItemId == cartItem.ProductItemId))
        {
            return await cartRepository.AddCartItem(cartItem);
        }
        
        var updatedCartItem = cartItems.FirstOrDefault(i => i.ProductItemId == cartItem.ProductItemId);
        updatedCartItem!.SelectCount += cartItem.SelectCount;
            
        return await cartRepository.UpdateCartItem(updatedCartItem);
    }

    public async Task<bool> UpdateCartItem(CartItem cartItem) => await cartRepository.UpdateCartItem(cartItem);
    
    public async Task<bool> DeleteCartItem(int id) => await cartRepository.DeleteCartItems([id]);

    public async Task<bool> ClearCart(int userId)
    {
        var cart = await cartRepository.GetCart(userId);
        var cartItems = await cartRepository.GetCartItems(cart.Id);
        
        return await cartRepository.DeleteCartItems(cartItems.Select(i => i.Id).ToList());
    }
}