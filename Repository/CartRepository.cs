using DataAccess.Intefaces;
using Models;
using Repository.Interfaces;

namespace Repository;

public class CartRepository(IPostgresContext postgresContext) : ICartRepository
{
    public async Task<Cart?> GetCart(int id) => await postgresContext.Get<Cart?>(Scripts.Scripts.GetCartByUserId, new
    {
        id
    });

    public async Task<List<CartItem>> GetCartItems(int id) =>
        await postgresContext.Select<CartItem>(Scripts.Scripts.GetCartItemByCartId, new { id });
    
    public async Task<int> CreateCart(int userId) => await postgresContext.Get<int>(Scripts.Scripts.CreateCart, new
    {
        user_id = userId,
        create_date = DateTime.Now
    });

    public async Task<bool> AddCartItem(CartItem cartItems) => await postgresContext.Exec(Scripts.Scripts.AddCartItem,
        new
        {
            cart_id = cartItems.CartId,
            product_item_id = cartItems.ProductItemId,
            quantity = cartItems.SelectCount
        });

    public async Task<bool> UpdateCartItem(CartItem cartItem) => await postgresContext.Exec(
        Scripts.Scripts.UpdateCartItem, new
        {
            quantity = cartItem.SelectCount,
            is_selected = cartItem.IsSelected,
            id = cartItem.Id
        });

    public async Task<bool> DeleteCartItems(List<int> ids) => await postgresContext.Exec(Scripts.Scripts.DeleteCartItem,
        new
        {
            ids
        });
}