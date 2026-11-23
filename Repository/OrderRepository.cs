using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        _216775882_MyStoreDBContext dbContext;
        public OrderRepository(_216775882_MyStoreDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Order> AddOrder(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
            
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await dbContext.Orders.FindAsync(id);
        }
    }
}
