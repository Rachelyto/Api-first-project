using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(int id);
        Task<Order> AddOrder(Order order);
    }
}
