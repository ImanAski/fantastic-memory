using Miro.Models;

namespace miro.Services.Interface;

public interface IOrderService
{
    Task<Order> CreateOrder(Order order);
    Task<Order> GetOrderById(int id);
    Task<Order> GetOrderByAuthority(string authority);
    Task UpdateOrder(Order order);
    Task<List<Order>> GetOrdersByUserId(int userId);
    Task<List<Order>> GetOrdersByStatus(OrderStatus orderStatus);
}