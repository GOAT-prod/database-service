using Models;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service;

public class OrderService(IOrderRepository orderRepository, ICartRepository cartRepository, IUserRepository userRepository, IProductRepository productRepository) : IOrderService
{
    public async Task<List<Order>> GetAllOrders() => await orderRepository.GetAllOrders();
    
    public async Task<List<Order>> GetUserOrders(int userId) => await orderRepository.GetAllOrdersByUserId(userId);

    public async Task<bool> AddOrder(int userId)
    {
        var cart = await cartRepository.GetCart(userId);
        var cartItems = await cartRepository.GetCartItems(cart.Id);
        var user = await userRepository.GetUserById(userId);

        var orderingCartItems = cartItems.Where(i => i.IsSelected).ToList();
        var productItemsInfo = await productRepository.GetProductItemsByIds(orderingCartItems.Select(i => i.ProductItemId));
        
        var order = new Order
        {
            Id = Guid.NewGuid(),
            Type = OrderType.Order,
            Status = OrderStatus.Pending,
            CreateDate = DateTime.Now,
            DeliveryDate = default,
            Username = user.Username,
            TotalWeight = productItemsInfo.Select(i => i.Weight).Sum(),
            TotalPrice = orderingCartItems.Select(i => i.Price * i.SelectCount).Sum()
        };
        
        _ = await orderRepository.AddOrder(order, userId);

        foreach (var orderingCartItem in orderingCartItems)
        {
            _ = await orderRepository.AddOrderItem(Guid.NewGuid(), order.Id, orderingCartItem.ProductItemId, orderingCartItem.SelectCount);
        }
        
        var operationId = Guid.NewGuid();
        
        _ = await orderRepository.AddOperation(operationId, order.Id);
        _ = await orderRepository.AddOperationDetail(Guid.NewGuid(), operationId, order.TotalPrice);
        _ = await cartRepository.DeleteCartItems(orderingCartItems.Select(i => i.Id).ToList());
        
        return true;
    }

    public async Task<bool> AddSupply(Product product)
    {
        var user = await userRepository.GetUserByClientId(product.FactoryId);
        if (user == null)
        {
            return false;
        }
        
        var products = await productRepository.GetProductByFactoryId(product.FactoryId);
        product = products.LastOrDefault()!;
        
        var order = new Order
        {
            Id = Guid.NewGuid(),
            Type = OrderType.Supply,
            Status = OrderStatus.Pending,
            CreateDate = DateTime.Now,
            DeliveryDate = default,
            Username = user.Username
        };
        
        _ = await orderRepository.AddOrder(order, (int)user.Id!);
        foreach (var orderingCartItem in product.Items)
        {
            _ = await orderRepository.AddOrderItem(Guid.NewGuid(), order.Id, orderingCartItem.Id, orderingCartItem.Count);
        }
        
        return true;
    }

    public async Task<bool> UpdateOrder(Guid orderId, OrderStatus status) => await orderRepository.UpdateOrder(orderId, status);
}