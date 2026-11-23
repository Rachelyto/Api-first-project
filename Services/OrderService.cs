using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;
        public OrderService(IOrderRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Order> AddOrder(Order order)
        {
            return await repository.AddOrder(order);
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await repository.GetOrderById(id);
        }
    }
}
