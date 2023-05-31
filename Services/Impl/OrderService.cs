using Microsoft.EntityFrameworkCore;
using Miro.Models;
using miro.Services.Interface;

namespace miro.Services.Impl;

public class OrderService : IOrderService
{
    private readonly MiroDbContext _dbContext;

    public OrderService(MiroDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Order> CreateOrder(Order order)
    {
        _dbContext.Order.Add(order);
        await _dbContext.SaveChangesAsync();
        return order;
    }

    public async Task<Order> GetOrderById(int id)
    {
        return await _dbContext.Order.FindAsync(id);
    }

    public async Task<Order> GetOrderByAuthority(string authority)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateOrder(Order order)
    {
        _dbContext.Order.Update(order);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Order>> GetOrdersByUserId(int userId)
    {
        return await _dbContext.Order.Where(o => o.UserId == userId).ToListAsync();
    }

    public async Task<List<Order>> GetOrdersByStatus(OrderStatus orderStatus)
    {
        return await _dbContext.Order.Where(o => o.Status == orderStatus).ToListAsync();
    }
}