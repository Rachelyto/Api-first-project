using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
   
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await repository.GetAllProducts();
        }
    }
}
