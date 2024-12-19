using DataAccess.Intefaces;
using Models;
using Repository.Interfaces;

namespace Repository;

public class OrderRepository(IPostgresContext postgresContext) : IOrderRepository
{
    public async Task<List<Order>> GetAllOrders() => await postgresContext.Select<Order>(Scripts.Scripts.GetAllOrders);

    public async Task<List<Order>> GetAllOrdersByUserId(int userId) =>
        await postgresContext.Select<Order>(Scripts.Scripts.GetOrdersByUserId, new { id = userId });

    public async Task<bool> AddOrder(Order order, int userId) => await postgresContext.Exec(Scripts.Scripts.AddOrder,
        new
        {
            id = order.Id,
            user_id = userId,
            create_date = order.CreateDate,
            delivery_date = order.DeliveryDate,
            status = order.Status.ToString(),
            type = order.Type,
        });

    public async Task<bool> AddOrderItem(Guid id, Guid orderId, int productItemId, int count) =>
        await postgresContext.Exec(Scripts.Scripts.AddOrderItem, new
        {
            id,
            order_id = orderId,
            product_item_id = productItemId,
            quantity = count,
        });

    public async Task<bool> AddOperation(Guid id, Guid orderId) => await postgresContext.Exec(
        Scripts.Scripts.AddOperation, new
        {
            id,
            date = DateTime.Now,
            order_id = orderId,
            description = "Заказ поставки кроссовок"
        });

    public async Task<bool> AddOperationDetail(Guid id, Guid operationId, decimal amount) => await postgresContext.Exec(
        Scripts.Scripts.AddOperationDetail, new
        {
            id,
            operation_id = operationId,
            type = "delivery",
            amount
        });
    
    public async Task<bool> UpdateOrder(Guid id, OrderStatus status) => await postgresContext.Exec(Scripts.Scripts.UpdateOrder, new
    {
        status,
        id
    });
}