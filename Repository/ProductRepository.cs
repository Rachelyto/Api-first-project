using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        _216775882_MyStoreDBContext dbContext;
        public ProductRepository(_216775882_MyStoreDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {

            return await dbContext.Products.ToListAsync();
        }
    }
}
