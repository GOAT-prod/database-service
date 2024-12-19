using Models;

namespace Service.Interfaces;

public interface IOrderService
{
    Task<List<Order>> GetAllOrders();
    Task<List<Order>> GetUserOrders(int userId);
    Task<bool> AddOrder(int userId);
    Task<bool> UpdateOrder(Guid orderId, OrderStatus status);
}