using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Interfaces;

namespace database_service.Controllers;

[ApiController]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpGet("orders")]
    public async Task<List<Order>> GetAllOrders() => await orderService.GetAllOrders();
    
    [HttpGet("orders/{userId}")]
    public async Task<List<Order>> GetUserOrders(int userId) => await orderService.GetUserOrders(userId);
    
    [HttpPost("order/{userId}")]
    public async Task<bool> AddOrder(int userId) => await orderService.AddOrder(userId);
    
    [HttpPut("order/{orderId}/status/{status}")]
    public async Task<bool> UpdateOrder(Guid orderId, OrderStatus status) => await orderService.UpdateOrder(orderId, status);
}