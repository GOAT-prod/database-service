using Models;

namespace Repository.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetAllOrders();
    Task<List<Order>> GetAllOrdersByUserId(int userId);
    Task<bool> AddOrder(Order order, int userId);
    Task<bool> AddOrderItem(Guid id, Guid orderId, int productItemId, int count);
    Task<bool> AddOperation(Guid id, Guid orderId);
    Task<bool> AddOperationDetail(Guid id, Guid operationId, decimal amount);
    Task<bool> UpdateOrder(Guid id, OrderStatus status);
}